using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    class TS23_Test : TS_ITestBucket
    {
        public bool PerformTestBucket(Bucket bucket)
        {
            ErrorMessage = "Er is geen waarde in kolom 3";

            if (bucket.bucketValue == "")//Als de waarde van de bucket leeg is
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
