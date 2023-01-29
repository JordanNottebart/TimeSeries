using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeSeries
{
    public class TS12_Test : TS_ITestFileFormat
    {
        public string ErrorMessage { get; set; }

        public bool PerformTest(string[] splitstring)
        {
            ErrorMessage = "Er bestaat geen titelrij";
            //TimeSeries.TS_ITestFileFormat x = new TS13_Test();
            //TimeSeries.TS_ITestFileFormat y = new TS14_Test();
            if ((splitstring.Contains("Start") || splitstring.Contains("End")) && splitstring.Length == 3)//Als de titel start, end en de array 3 groot is
            {
                return true;
            }
            return false;

        }
    }
}
