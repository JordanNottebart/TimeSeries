using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries.Test
{
    class TS17_Test : TS_ITestFileFormat
    {
        public bool PerformTest(string[] splitstring)
        {
            bool testOk = true;
            if (splitstring.Length <= 1)//Als de array kleiner of gelijk aan 1 is
            {
                testOk = false;
                ErrorMessage = " file bevat geen data";
            }
            return testOk;
        }
        public string ErrorMessage { get; set; }
    }
}
