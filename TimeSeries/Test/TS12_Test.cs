using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSeries
{
    public class TS12_Test : TimeSeries.TS_ITestFileFormat
    {
        public string ErrorMessage { get; set; }

        public bool PerformTest(string[] splitstring)
        {
            ErrorMessage = "Er bestaat geen titelrij";
            //TimeSeries.TS_ITestFileFormat x = new TS13_Test();
            //TimeSeries.TS_ITestFileFormat y = new TS14_Test();
            if ((splitstring.Contains("Start") || splitstring.Contains("End")) && splitstring.Length == 3)
            {
                return true;
            }
            return false;

        }
    }
}
