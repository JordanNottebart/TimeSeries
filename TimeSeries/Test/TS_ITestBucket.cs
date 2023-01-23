using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries.Test
{
    public interface TS_ITestBucked
        //Interface om buckets te testen
    {
        public bool PerformTestBucket(Bucket bucket);
    }
}
