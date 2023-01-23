﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TimeSeries.Test;

namespace TimeSeries
{
    public class TXT_CSVfile : TS_IFile
    {
        private int _lineIndex = 1;
        private BucketList TimeSeries = new BucketList();

        public FileInfo TheFile { get; set; }
        public TXT_CSVfile(FileInfo theFile)
        {
            this.TheFile = theFile;
        }


        public void ReadFile()
        {
            List<TS_ITestFileFormat> tests = new List<TS_ITestFileFormat>();
            List<TS_ITestFileFormat> testsHeader = new List<TS_ITestFileFormat>();
            #region MakeTests
            TS_ITestFileFormat test11_16 = new TS11_16_Test();
            TS_ITestFileFormat test13 = new TS13_Test();
            TS_ITestFileFormat test14 = new TS14_Test();
            TS_ITestFileFormat test12 = new TS12_Test();
            TS_ITestFileFormat test17 = new TS17_Test();
            tests.Add(test11_16);
            //tests.Add(test13);
            //tests.Add(test14);
            tests.Add(test17);
            testsHeader.Add(test12);
            testsHeader.AddRange(tests);
            testsHeader.Add(test13);
            testsHeader.Add(test14);

            #endregion

            Program.application.output.Items.Clear();
            string[] fileInput = File.ReadLines(TheFile.FullName).ToArray();

            SplitWordsTitleRow(fileInput[0],testsHeader);
            for(; _lineIndex < fileInput.Length; _lineIndex++)
            {
                #region Vorige Oplossing
                //if (i<1)
                //{
                //    //dit test ook op TS12: Er is geen titelrij

                //    try
                //    {
                //        SplitWords(fileInput[i], testsHeader);
                //        Program.application.output.Items.Add("Checks gedaan voor " + i);
                //    }
                //    catch (Exception e)
                //    {
                //        System.Windows.Forms.MessageBox.Show(e.Message + i);
                //        i = fileInput.Length;
                //    }
                //}

                //Program.application.output.Items.Add(fileInput[i]);
                //else
                //{ 
                #endregion

                SplitWords(fileInput[_lineIndex], tests);
                Program.application.output.Items.Add("Checks gedaan voor " + _lineIndex);


                //}

            }
        }

        public void SplitWords(string aLine, List<TS_ITestFileFormat> tests)
        {
            string[] words = aLine.Split(';');
            //hier format test


            int index = 0;
            bool formatIsGood = true;
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
            if (formatIsGood)
            {
                string startDate = words[0];
                string endDate = words[1];
                string strValue = words[2];
                Bucket bucket = CreateBucket(startDate, endDate, strValue);
                this.TimeSeries.Add(bucket);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(tests[index].ErrorMessage + "\tlijn " + (_lineIndex +1));
                this._lineIndex = int.MaxValue -1;// dit zorgt ervoor dat wanneer er een test faalt de loop eindigt 
                //kan enkel problemen geven wanneer je een file hebt van dezelfde lengte
                // is een beetje een lange file
                //throw new test[index].Exception();
            }



        }

        public void SplitWordsTitleRow(string aLine, List<TS_ITestFileFormat> headerTests)
        {
            string[] words = aLine.Split(';');

            int index = 0;
            bool formatIsGood = true;
            while (formatIsGood && index < headerTests.Count)
            {
                //werkt hetzelfde als de SpitWords Maar bevat meer tests zoals test 12 die test op de titelrij zelf.
                formatIsGood = headerTests[index].PerformTest(words);

                if (formatIsGood)
                {
                    string startDateTitle = words[0];
                    string endDateTitle = words[1];
                    string valueTitle = words[2];

                    //Try to create a new titleBucket
                    this.TimeSeries.TitleBucket = new TitleBucket(startDateTitle, endDateTitle, valueTitle);

                }            // Moeten hier dan de testen op de titelrij (13 t.e.m. 16)? - Jordan

                else
                {
                    System.Windows.Forms.MessageBox.Show(headerTests[index].ErrorMessage + "\tlijn " + _lineIndex);
                    this._lineIndex = int.MaxValue - 1;
                    //throw new test[index].Exception();
                }
                index++;

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
