using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public class TS13_Test : TS_ITestFileFormat
    {
        public bool PerformTest(string[] titleRow)
        {
            // Chech if the title of the first colmun in the title row is "start" (case insensitive)
            if (titleRow[0].ToLower() == "start")
            {
                return true;
            }

            return false;
        }
    }
}
