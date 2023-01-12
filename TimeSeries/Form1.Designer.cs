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
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(22, 81);
            this.openFile.Margin = new System.Windows.Forms.Padding(6);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(184, 63);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "button1";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 832);
            this.Controls.Add(this.pathofthefile);
            this.Controls.Add(this.output);
            this.Controls.Add(this.openFile);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox pathofthefile;
        private System.Windows.Forms.ListBox output;


        public void ReadInputTXT(string path)
        {
            output.Items.Clear();
            string[] fileInput = File.ReadLines(path).ToArray();
            foreach (string line in fileInput)
            {
                output.Items.Add(line);
            }
        }

        public void ReadInputCSV(string path)
        {
            output.Items.Clear();
            string[] fileInput = File.ReadLines(path).ToArray();
            foreach (string line in fileInput)
            {
                output.Items.Add(line);
            }
        }

        public void ReadInputXLS(string path)
        {

        }

        public void ReadInputXLSX(string path)
        {
            FileInfo aFile;
            MyExcelApp.Application theExcelApplication;
            MyExcelApp.Workbook theWorkbook;
            MyExcelApp.Worksheet theWorksheet;
            MyExcelApp.Range theRange;
            MyExcelApp.Range theCell;
            aFile = new FileInfo(path);
            theExcelApplication = new MyExcelApp.Application();   // Make a new excel application

            theExcelApplication.Visible = true;   // Show the excel file or not
            theWorkbook = theExcelApplication.Workbooks.Open(aFile.FullName);   // Define the workbook
            theWorksheet = theWorkbook.Worksheets[1];   // Define the worksheet you are using
            theRange = theWorksheet.UsedRange;   // Define the range used
            List<string> fileInput = new List<string>();
            for (int RowCounter = 1; RowCounter <= theRange.Rows.Count; RowCounter++)   // Show the value of each used cell, row after row
            {
                string[] rowsInput = new string[3];
                //for (int ColumnCounter = 1; ColumnCounter <= theRange.Columns.Count; ColumnCounter++)
                //{
                //    theCell = theRange.Cells[RowCounter, ColumnCounter];

                //}
                rowsInput[0] = theRange.Rows[RowCounter,1];
                rowsInput[1] = theRange.Rows[RowCounter,2];
                rowsInput[2] = theRange.Rows[RowCounter,3];
            }

            theExcelApplication.Quit();

        }


    }
}

