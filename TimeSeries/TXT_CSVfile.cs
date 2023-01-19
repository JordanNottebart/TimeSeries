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

            //Split the title row first
            SplitWordsTitleRow(fileInput[0]);

            for (int i = 1; i < fileInput.Length; i++)
            {

                Program.application.output.Items.Add(fileInput[i]);
                //SplitWords(line);
            }
        }

        public void SplitWords(string aLine)
        {
            string[] words = aLine.Split(';');
            //hier format test
            List<TS_ITestFileFormat> tests = new List<TS_ITestFileFormat>();
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
            string[] titleWords = aLine.Split(';');

            string startDateTitle = titleWords[0];
            string endDateTitle = titleWords[1];
            string valueTitle = titleWords[2];

            //Try to create a new titleBucket
            try
            {
                TitleBucket theTitleBucket = new TitleBucket(startDateTitle, endDateTitle, valueTitle);
                // Moeten hier dan de testen op de titelrij (13 t.e.m. 16)? - Jordan
            }
            catch
            {
                //Error message that show that there is no titlerow
            }

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
