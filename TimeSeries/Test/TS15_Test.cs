using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries.Test
{
    class TS15_Test : TS_ITestBucket
    {
        public bool PerformTestBucket(Bucket bucket)
        {
            bool testOk = true;
            if(bucket.bucketValue == "")//Als titel leeg is
            {
                testOk = false;
                ErrorMessage = " Titel is leeg";
            }
            return testOk;
        }

        public string ErrorMessage { get; set; }
    }
}
