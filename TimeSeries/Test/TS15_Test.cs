using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    class TS15_Test : TS_ITestFileFormat
    {
        public bool PerformTest(string[] splitstring)
        {
            ErrorMessage = " Titel derde kolom is leeg";
            bool testOk = true;
            if (splitstring[2] == "")//Als titel leeg is
            {
                testOk = false;
            }
            return testOk;
        }

        public string ErrorMessage { get; set; }
    }
}
