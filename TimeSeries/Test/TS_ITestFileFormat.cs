using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public interface TS_ITestFileFormat
    {
        public bool PerformTest(string[] splitstring);
    }
}
