using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public interface TS_ITestFileFormat//Interface
    {
        public string ErrorMessage { get; set; }//Property
        public bool PerformTest(string[] splitstring);//Method
    }
}
