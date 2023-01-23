using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries.Test
{
    public class TS20_Test : TS_ITestFileFormat
    {
        public string ErrorMessage { get; set; }

        public bool PerformTest(string[] splitstring)
        {
            ErrorMessage = "start datum is leeg";

            if (splitstring[0] == "")
            {
                return false;
            }
            return true;
        }
    }
}
