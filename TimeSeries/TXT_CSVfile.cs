﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TimeSeries
{
    public class TXT_CSVfile : TS_IFile
    {
        private int _lineIndex = 1;
        private BucketList TimeSeries = new BucketList();       //Variabelen

        public FileInfo TheFile { get; set; }       //Property
        public TXT_CSVfile(FileInfo theFile)//Constructor
        {
            this.TheFile = theFile;
        }

        public void ReadFile()//Method om file in te lezen
        {
            List<TS_ITestFileFormat> tests = new List<TS_ITestFileFormat>();
            List<TS_ITestFileFormat> testsHeader = new List<TS_ITestFileFormat>();      //Er worden 2 lists aangemaakt
            #region MakeTests
            TS_ITestFileFormat test11_16 = new TS11_16_Test();
            TS_ITestFileFormat test13 = new TS13_Test();
            TS_ITestFileFormat test14 = new TS14_Test();
            TS_ITestFileFormat test12 = new TS12_Test();
            TS_ITestFileFormat test17 = new TS17_Test();
            TS_ITestFileFormat test18 = new TS18_Test();        //Alle testen worden aangemaakt
            TS_ITestFileFormat test15 = new TS15_Test();
            tests.Add(test11_16);       //Testen worden toegevoegd
            //tests.Add(test13);
            //tests.Add(test14);
            //tests.Add(test17);
            testsHeader.Add(test12);
            testsHeader.AddRange(tests);//Voor de titelrij maken we een andere lijst en voegen andere tests toe
            testsHeader.Add(test13);
            testsHeader.Add(test14);
            testsHeader.Add(test15);
            //tests.Add(test17);
            tests.Add(test18);


            #endregion

            Program.application.output.Items.Clear();
            string[] fileInput = File.ReadLines(TheFile.FullName).ToArray();

            if (test17.PerformTest(fileInput))//Als test17 true terugkeert(als er data is)
            {
                SplitWordsTitleRow(fileInput[0], testsHeader);//Controleer de titelrij
                for (; _lineIndex < fileInput.Length; _lineIndex++)
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
                    //Program.application.output.Items.Add("Checks gedaan voor " + _lineIndex);
                    //}
                }
                if (TimeSeries.TimeSeries.Count == fileInput.Length - 1)//Als de lijst 1 kleiner is dan de inputfile(zonder titel)
                {
                    CheckAllBuckets();//Method die de testen van de bucket uitvoert
                }
            }
            else
            {
                MessageBox.Show(test17.ErrorMessage);
            }
        }

        public void CheckAllBuckets()//Method om buckets te checken
        {
            List<TS_ITestBucket> testBuckets = new List<TS_ITestBucket>();//Maak een lijst
            TS_ITestBucket test23 = new TS23_Test();
            testBuckets.Add(test23);    
            _lineIndex = 0;
            int index;
            bool bucketIsGood = true;
            for (; _lineIndex < TimeSeries.TimeSeries.Count; _lineIndex++)//Zolang i kleiner is dan timeseries
            {
                index = 0;
                while (bucketIsGood && index < testBuckets.Count)//Als de bool true is en index kleiner is dan de hoeveelheid testen
                {
                    bucketIsGood = testBuckets[index].PerformTestBucket(TimeSeries.TimeSeries[_lineIndex]);//bool is gelijk aan de uitkomst van de test op de bucket
                    index++;
                }
                if (!bucketIsGood)//Als de bucket niet goed is
                {
                    MessageBox.Show(testBuckets[index-1].ErrorMessage + " Bucket: " + _lineIndex);//Toon de plaats waar de error zich bevind
                    //Index -1 omdat in de while loop er altijd nog 1 bijtelt
                    _lineIndex = int.MaxValue - 1;
                }
            }
        }

        public void SplitWords(string aLine, List<TS_ITestFileFormat> tests)//Method om het formaat te controleren
        {
            string[] words = aLine.Split(';');
            //hier format test

            int index = 0;
            bool formatIsGood = true;
            while (formatIsGood && index < tests.Count)//Zolang het formaat goed is en de index kleiner is dan de hoeveelheid testen
            {
                formatIsGood = tests[index].PerformTest(words);//Test
                index++;
            }
            if (formatIsGood)//Als het formaat goed is na alle testen
            {
                string startDate = words[0];
                string endDate = words[1];
                string strValue = words[2];
                Bucket bucket = CreateBucket(startDate, endDate, strValue);//Maak een bucket
                this.TimeSeries.Add(bucket);//Voeg het toe aan de lijst timeseries
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(tests[index-1].ErrorMessage + "lijn: " + (_lineIndex + 1));
                this._lineIndex = int.MaxValue - 1;// dit zorgt ervoor dat wanneer er een test faalt de loop eindigt 
                                                   //kan enkel problemen geven wanneer je een file hebt van dezelfde lengte
                                                   // is een beetje een lange file
                                                   //throw new test[index].Exception();
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
        }

        public void SplitWordsTitleRow(string aLine, List<TS_ITestFileFormat> headerTests)//Method die de titelrij test
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
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(headerTests[index].ErrorMessage + " lijn: " + _lineIndex);
                    this._lineIndex = int.MaxValue - 1;
                    //throw new test[index].Exception();
                }
                index++;
            }
        }

        public Bucket CreateBucket(string startDate, string endDate, string value)//Method om bucket te maken
        {
            //doen we hier zo kan ook anders maar geeft ons wat mooiere code
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
