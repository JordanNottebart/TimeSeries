﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public class TS11_16_Test : TS_ITestFileFormat
    {
        public string ErrorMessage { get; set; }

        public bool PerformTest(string[] splitstring)
        {
            if (splitstring.Length != 3)
            {
                return false;
                ErrorMessage = " Er is geen 3de kolom";
            }

            return true;
        }
    }
}
