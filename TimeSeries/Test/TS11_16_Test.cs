using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public class TS11_16_Test : TS_ITestFileFormat
    {

        public bool PerformTest(string[] splitstring)
        {
            if (splitstring.Length != 3)
            {
                return false;
            }

            return true;
        }
    }
}
