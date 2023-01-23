using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    class TS23_Test : TS_ITestBucked
    {
        public bool PerformTestBucket(Bucket bucket)
        {
            ErrorMessage = "Er is geen waarde in kolom 3";

            if (bucket.bucketValue == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
          

        public string ErrorMessage { get; set; }
    }
}
