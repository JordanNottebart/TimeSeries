using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MyExcelApp = Microsoft.Office.Interop.Excel;
namespace TimeSeries
{
    public class XLS_XLSXfile : TS_IFile
    {
        public FileInfo TheFile { get;set; }
        public XLS_XLSXfile(FileInfo theFile)
        {
            this.TheFile = theFile;
        }

        public void ReadFile()
        {
            MyExcelApp.Application theExcelApplication;
            MyExcelApp.Workbook theWorkbook;
            MyExcelApp.Worksheet theWorksheet;
            MyExcelApp.Range theRange;
            theExcelApplication = new MyExcelApp.Application();   // Make a new excel application

            theExcelApplication.Visible = true;   // Show the excel file or not
            theWorkbook = theExcelApplication.Workbooks.Open(this.TheFile.FullName);   // Define the workbook
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
                rowsInput[0] = theRange.Rows[RowCounter, 1].Value;
                rowsInput[1] = theRange.Rows[RowCounter, 2].Value;
                rowsInput[2] = theRange.Rows[RowCounter, 3].Value;
            }

            theExcelApplication.Quit();
        }
    }
}
