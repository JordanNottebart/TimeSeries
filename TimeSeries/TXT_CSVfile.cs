using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace TimeSeries
{
    public class TXT_CSVfile : TS_IFile
    {
        public FileInfo TheFile { get; set; }
        public TXT_CSVfile(FileInfo theFile)
        {
            this.TheFile = theFile;
        }


        public void ReadFile()
        {
               
            Program.application.output.Items.Clear();
            string[] fileInput = File.ReadLines(TheFile.FullName).ToArray();
            foreach (string line in fileInput)
            {
                Program.application.output.Items.Add(line);
                SplitWords(line);
            }
        }

        public void SplitWords(string aLine)
        {
            string[] words = aLine.Split(';');

            string startDate = words[0];
            string endDate = words[1];
            string strValue = words[2];

            string[] startDateWords = startDate.Split('/');
            string[] endDateWords = endDate.Split('/');

            try
            {
                int startDateDay = Convert.ToInt32(startDateWords[0]);
                int startDateMonth = Convert.ToInt32(startDateWords[1]);
                int startDateYear = Convert.ToInt32(startDateWords[2]);

                int endDateDay = Convert.ToInt32(endDateWords[0]);
                int endDateMonth = Convert.ToInt32(endDateWords[1]);
                int endDateYear = Convert.ToInt32(endDateWords[2]);

                DateTime dtStartDate = new DateTime(startDateYear, startDateMonth, startDateDay);
                DateTime dtEndDate = new DateTime(endDateYear, endDateMonth, endDateDay);

            }
            catch
            {
                
            }


        }
    }
}
