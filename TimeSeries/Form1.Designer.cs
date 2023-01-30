using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyExcelApp = Microsoft.Office.Interop.Excel;


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
            this.btn_ExecuteRead = new System.Windows.Forms.Button();
            this.btn_CheckTimeSeries = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(22, 81);
            this.openFile.Margin = new System.Windows.Forms.Padding(6);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(184, 63);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Browse";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // output
            // 
            this.output.FormattingEnabled = true;
            this.output.ItemHeight = 37;
            this.output.Location = new System.Drawing.Point(249, 183);
            this.output.Margin = new System.Windows.Forms.Padding(6);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(865, 374);
            this.output.TabIndex = 1;
            // 
            // pathofthefile
            // 
            this.pathofthefile.Location = new System.Drawing.Point(249, 89);
            this.pathofthefile.Margin = new System.Windows.Forms.Padding(6);
            this.pathofthefile.Name = "pathofthefile";
            this.pathofthefile.Size = new System.Drawing.Size(865, 43);
            this.pathofthefile.TabIndex = 2;
            // 
            // btn_ExecuteRead
            // 
            this.btn_ExecuteRead.Location = new System.Drawing.Point(37, 183);
            this.btn_ExecuteRead.Name = "btn_ExecuteRead";
            this.btn_ExecuteRead.Size = new System.Drawing.Size(169, 52);
            this.btn_ExecuteRead.TabIndex = 3;
            this.btn_ExecuteRead.Text = "Read";
            this.btn_ExecuteRead.UseVisualStyleBackColor = true;
            this.btn_ExecuteRead.Click += new System.EventHandler(this.btn_ExecuteRead_Click);
            // 
            // btn_CheckTimeSeries
            // 
            this.btn_CheckTimeSeries.Location = new System.Drawing.Point(37, 265);
            this.btn_CheckTimeSeries.Name = "btn_CheckTimeSeries";
            this.btn_CheckTimeSeries.Size = new System.Drawing.Size(169, 52);
            this.btn_CheckTimeSeries.TabIndex = 4;
            this.btn_CheckTimeSeries.Text = "check";
            this.btn_CheckTimeSeries.UseVisualStyleBackColor = true;
            this.btn_CheckTimeSeries.Visible = false;
            this.btn_CheckTimeSeries.Click += new System.EventHandler(this.btn_CheckTimeSeries_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 832);
            this.Controls.Add(this.btn_CheckTimeSeries);
            this.Controls.Add(this.btn_ExecuteRead);
            this.Controls.Add(this.pathofthefile);
            this.Controls.Add(this.output);
            this.Controls.Add(this.openFile);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox pathofthefile;
        public System.Windows.Forms.ListBox output;
        private System.Windows.Forms.Button btn_ExecuteRead;
        private System.Windows.Forms.Button btn_CheckTimeSeries;
    }
}

