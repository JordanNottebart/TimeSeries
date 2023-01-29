using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public class TS11_16_Test : TS_ITestFileFormat//Test 11,16
    {
        public string ErrorMessage { get; set; }

        public bool PerformTest(string[] splitstring)
        {
            ErrorMessage = " Er is geen 3de kolom";
            if (splitstring.Length != 3)//Als de lengte niet 3 is
            {
                return false;

            }

            return true;
        }
    }
}
