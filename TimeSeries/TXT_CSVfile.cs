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

            }
        }
    }
}
