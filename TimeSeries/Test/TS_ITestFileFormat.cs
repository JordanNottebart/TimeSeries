using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    internal interface TS_ITestFileFormat
    {
        public bool PerformTest(string[] splitstring);
    }
}
