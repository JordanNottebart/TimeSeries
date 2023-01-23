using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries.Test
{
    public class TS12_Test : TS_ITestFileFormat
    {
        public string ErrorMessage { get ; set ; }

        public bool PerformTest(string[] splitstring)
        {
            ErrorMessage = "Er bestaat geen titelrij";
            return true;
        }
    }
}
