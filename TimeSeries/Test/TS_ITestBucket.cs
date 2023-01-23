using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public interface TS_ITestBucked
        //Interface om buckets te testen
    {
        public bool PerformTestBucket(Bucket bucket);
    }
}
