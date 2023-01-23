using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public class TS13_Test : TS_ITestFileFormat
    {
        public string ErrorMessage { get ; set ; }

        public bool PerformTest(string[] titleRow)
        {

            ErrorMessage = "Titel van de eerste kolom is niet start";
            // Check if the title of the first column in the title row is "start" (case insensitive)
            if (titleRow[0].ToLower() == "start")
            {
                return true;
            }
            return false;
        }
    }
}
