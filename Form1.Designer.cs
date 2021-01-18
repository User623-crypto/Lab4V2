
namespace Lab4V2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dekompreso_button = new System.Windows.Forms.Button();
            this.kompresso_button = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dekompreso_button
            // 
            this.dekompreso_button.Location = new System.Drawing.Point(609, 91);
            this.dekompreso_button.Name = "dekompreso_button";
            this.dekompreso_button.Size = new System.Drawing.Size(164, 88);
            this.dekompreso_button.TabIndex = 0;
            this.dekompreso_button.Text = "Zgjidh Folderin qe do dekompresosh";
            this.dekompreso_button.UseVisualStyleBackColor = true;
            this.dekompreso_button.Click += new System.EventHandler(this.dekompreso_button_Click);
            // 
            // kompresso_button
            // 
            this.kompresso_button.Location = new System.Drawing.Point(92, 69);
            this.kompresso_button.Name = "kompresso_button";
            this.kompresso_button.Size = new System.Drawing.Size(203, 91);
            this.kompresso_button.TabIndex = 1;
            this.kompresso_button.Text = "Zgjidh folderin që do kompresosh";
            this.kompresso_button.UseVisualStyleBackColor = true;
            this.kompresso_button.Click += new System.EventHandler(this.kompresso_button_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(408, 246);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 21);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "multThread";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.kompresso_button);
            this.Controls.Add(this.dekompreso_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dekompreso_button;
        private System.Windows.Forms.Button kompresso_button;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
    }
}

