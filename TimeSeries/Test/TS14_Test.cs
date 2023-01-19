using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public class TS14_Test : TS_ITestFileFormat
    {
        public bool PerformTest(string[] titleRow)
        {
            // Chech if the title of the first colmun in the title row is "end" (case insensitive)
            if (titleRow[0].ToLower() == "end")
            {
                return true;
            }
            
            return false;
        }
    }
}
