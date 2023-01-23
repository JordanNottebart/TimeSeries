﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries.Test
{
    public class TS12_Test : TimeSeries.TS_ITestFileFormat
    {
        public string ErrorMessage { get ; set ; }

        public bool PerformTest(string[] splitstring)
        {
            ErrorMessage = "Er bestaat geen titelrij";
            TimeSeries.TS_ITestFileFormat x = new TS13_Test();
            TimeSeries.TS_ITestFileFormat y = new TS14_Test();
            if (x.PerformTest(splitstring) && y.PerformTest(splitstring))
            {
                return true;
            }
            return false;

        }
    }
}
