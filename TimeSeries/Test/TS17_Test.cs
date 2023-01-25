using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    class TS17_Test : TimeSeries.TS_ITestFileFormat
    {
        public bool PerformTest(string[] fileInput)
        {
            ErrorMessage = " file bevat geen data";
            bool testOk = true;
            if (fileInput.Length <= 1)//Als de array kleiner of gelijk aan 1 is
            {
                testOk = false;
            }
            return testOk;
        }
        public string ErrorMessage { get; set; }
    }
}
