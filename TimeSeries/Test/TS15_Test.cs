using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    class TS15_Test : TS_ITestBucked
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
