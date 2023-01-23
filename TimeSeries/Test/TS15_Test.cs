using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries.Test
{
    class TS15_Test : TS_ITestFileFormat
    {
        public bool PerformTestBucket(Bucket bucket)
        {
            ErrorMessage = " Titel is leeg";
            bool testOk = true;
            if(bucket.bucketValue == "")//Als titel leeg is
            {
                testOk = false;
            }
            return testOk;
        }

        public string ErrorMessage { get; set; }
    }
}
