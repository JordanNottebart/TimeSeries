using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using TimeSeries.Test;

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

            List<TS_ITestFileFormat> tests = new List<TS_ITestFileFormat>();
            #region MakeTests
            TS_ITestFileFormat test11_16 = new TS11_16_Test();
            TS_ITestFileFormat test13 = new TS13_Test();
            TS_ITestFileFormat test14 = new TS14_Test();
            TS_ITestFileFormat test17 = new TS17_Test();
            tests.Add(test11_16);
            tests.Add(test13);
            tests.Add(test14);
            tests.Add(test17); 
            #endregion

            Program.application.output.Items.Clear();
            string[] fileInput = File.ReadLines(TheFile.FullName).ToArray();
            for (int i = 1; i < fileInput.Length; i++)
            {

                Program.application.output.Items.Add(fileInput[i]);
                SplitWords(fileInput[i], tests);
            }
        }

        public void SplitWords(string aLine, List<TS_ITestFileFormat> tests)
        {
            string[] words = aLine.Split(';');
            //hier format test

            
            
            bool formatIsGood = true;
            int index = 0;
            while (formatIsGood && index < tests.Count)
            {
                formatIsGood = tests[index].PerformTest(words);
                index++;
            }
            /*
             * Zorg ervoor dat je test false returned wanneer hij faalt
             * hier lopen we door elke test totdat we enerzijds een false terug krijgen of
             * we het einde van de lijst van testen terecht komen
             * als de format goed blijft en we dus aan het einde van de lijst komen 
             * maken we een bucket aan 
             * anders gooien we een exception
             * 
             */
            if (true)
            {
                string startDate = words[0];
                string endDate = words[1];
                string strValue = words[2];

                Bucket bucket = CreateBucket(startDate, endDate, strValue);
            }
            else
            {
                throw new Exception();
                //throw new test[index].Exception();
            }



        }

        public void SplitWordsTitleRow(string aLine)
        {

        }

        public Bucket CreateBucket(string startDate, string endDate, string value)
        {

            try
            {
                DateTime dtStartDate = DateTime.Parse(startDate);
                DateTime dtEndDate = DateTime.Parse(endDate);
                return Bucket.GetBucket(dtStartDate, dtEndDate, value);
            }
            catch
            {
                return new Bucket();
            }
        } 
    }
}
