using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public class TS14_Test : TS_ITestFileFormat
    {
        public bool PerformTest(string[] titleRow)
        {
            // Check if the title of the second column in the title row is "end" (case insensitive)
            if (titleRow[1].ToLower() == "end")
            {
                return true;
            }
            
            return false;
        }
    }
}
