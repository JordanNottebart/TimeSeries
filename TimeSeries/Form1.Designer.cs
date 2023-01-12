using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TimeSeries
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFile = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.ListBox();
            this.pathofthefile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(12, 44);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(98, 34);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Browse";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // output
            // 
            this.output.FormattingEnabled = true;
            this.output.ItemHeight = 20;
            this.output.Location = new System.Drawing.Point(133, 99);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(463, 204);
            this.output.TabIndex = 1;
            // 
            // pathofthefile
            // 
            this.pathofthefile.Location = new System.Drawing.Point(133, 48);
            this.pathofthefile.Name = "pathofthefile";
            this.pathofthefile.Size = new System.Drawing.Size(463, 27);
            this.pathofthefile.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pathofthefile);
            this.Controls.Add(this.output);
            this.Controls.Add(this.openFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox pathofthefile;
        private System.Windows.Forms.ListBox output;


        public  void ReadInputTXT(string path, string name)
        {
            string[] fileInput = File.ReadLines(path + name).ToArray();
            foreach (string line in fileInput)
            {
                output.Items.Add(line);
            }
        }

        public  void ReadInputCSV(string path, string name)
        {
            string[] fileInput = File.ReadLines(path + name).ToArray();
            foreach (string line in fileInput)
            {
                output.Items.Add(line);
            }
        }

        public  void ReadInputXLS(string path, string name)
        {

        }

        public  void ReadInputXLSX(string path, string name)
        {

        }


    }
}

