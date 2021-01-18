using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4V2
{

    public partial class Form1 : Form
    {
        Stopwatch stopwatch;
        string zipPath = "C:\\kot";

        public Form1()
        {
            InitializeComponent();
        }

        private void kompresso_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                stopwatch = Stopwatch.StartNew();
                Console.WriteLine(fbd.SelectedPath.ToString());
                string path = fbd.SelectedPath.ToString();
                Console.WriteLine("Pathi eshte: " + path);

                // CompressDirectory(path, "testing.gz", (fileName) => { Console.WriteLine("Compressing {0}...", fileName); },checkBox1.Checked);
                CompressDirectoryV2(path, checkBox1.Checked);
                stopwatch.Stop();
                label1.Text = "Koha eshte:" + stopwatch.ElapsedMilliseconds + "  ms";
                Console.WriteLine("************ " + stopwatch.ElapsedMilliseconds);

            }

        }

        public void CompressFile(string path, GZipStream zipStream)
        {
          
            //Compress file content
            byte[] bytes = File.ReadAllBytes((path)); //Merr direktorin absolute, pra të dhënat e  file-it kthehen ne byte
            zipStream.Write(bytes, 0, bytes.Length); //Shkruan të dhënën
        }
        public void CompressDirectoryV2(string inDir,bool multi)
        {
            string[] sFiles = Directory.GetFiles(inDir, "*.*", SearchOption.AllDirectories); //Merr filet
            foreach (string sFilePath in sFiles)
            {
                string sRelativePath = sFilePath.Substring(inDir.Length + 1); //File ka emrin e till C:\test\filename.txt kjo merr emrin relativ pra filename.txt
           
                if (multi)
                {
                    new Thread(() => {
                        using (FileStream outFile = new FileStream(zipPath + "\\" + sRelativePath + ".gz", FileMode.Create, FileAccess.Write, FileShare.None)) // Krijon nje file me emrin e dhene, emri ketu eshte dhene standart testing.gz
                        using (GZipStream str = new GZipStream(outFile, CompressionMode.Compress)) // Krijon nje Zip Stream ku do te kompresohen filet
                            CompressFile(sFilePath, str);
                    }).Start();
                }
                else
                {
                    using (FileStream outFile = new FileStream(zipPath + "\\" + sRelativePath + ".gz", FileMode.Create, FileAccess.Write, FileShare.None)) // Krijon nje file me emrin e dhene, emri ketu eshte dhene standart testing.gz
                    using (GZipStream str = new GZipStream(outFile, CompressionMode.Compress)) // Krijon nje Zip Stream ku do te kompresohen filet
                        CompressFile(sFilePath, str);

                }
            }
        }

        private void dekompreso_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                stopwatch = Stopwatch.StartNew();
                Console.WriteLine(fbd.SelectedPath.ToString());
                string path = fbd.SelectedPath.ToString();
                Console.WriteLine("Pathi eshte: " + path);

                DecompressToDirectoryV2(path, zipPath, checkBox1.Checked);
                stopwatch.Stop();
                label1.Text = "Koha eshte:" + stopwatch.ElapsedMilliseconds + "  ms";
                Console.WriteLine("************ " + stopwatch.ElapsedMilliseconds);

            }
        }

        bool DecompressFile(string path, GZipStream zipStream)
        {

            List<Byte> recivedBytes = new List<byte>();

            while (true)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = zipStream.Read(buffer, 0, buffer.Length);
                if (bytesRead <= 0)
                {
                    break;
                }
                byte[] correctBuffer = new byte[bytesRead];
                Array.Copy(buffer, correctBuffer, bytesRead);

                recivedBytes.AddRange(correctBuffer);
            }


            byte[] decompressedBytes = recivedBytes.ToArray();
            string sFinalDir = Path.GetDirectoryName(path);
            if (!Directory.Exists(sFinalDir))
                Directory.CreateDirectory(sFinalDir);

            using (FileStream outFile = new FileStream(path.Replace(".gz",""), FileMode.Create, FileAccess.Write, FileShare.None))
                outFile.Write(decompressedBytes, 0, decompressedBytes.Length);

            return true;
        }

        void DecompressToDirectoryV2(string sCompressedFileDir, string sDir, bool multi)
        {
            string[] sFiles = Directory.GetFiles(sCompressedFileDir, "*.gz*", SearchOption.AllDirectories); //Kthen te gjithe filet ne direktorin e dhene
            foreach (string sFilePath in sFiles)
            {
                string sRelativePath = sFilePath.Substring(sCompressedFileDir.Length + 1); //File ka emrin e till C:\test\filename.txt kjo merr emrin relativ pra filename.txt
               
                if (multi)
                {
                    new Thread(() => {
                        using (FileStream inFile = new FileStream(sFilePath, FileMode.Open, FileAccess.Read, FileShare.None)) // Hap file-in ne read mode
                        using (GZipStream zipStream = new GZipStream(inFile, CompressionMode.Decompress, true))//Vendos File-in ne stream
                            DecompressFile(sDir + "\\" + sRelativePath, zipStream); 

                    }).Start();
                }
                else
                {
                    using (FileStream inFile = new FileStream(sFilePath, FileMode.Open, FileAccess.Read, FileShare.None)) // Hap file-in ne read mode
                    using (GZipStream zipStream = new GZipStream(inFile, CompressionMode.Decompress, true))//Vendos File-in ne stream
                        while (DecompressFile(sDir + "\\" + sRelativePath, zipStream)) ;

                }
            }

        }
    }

}
