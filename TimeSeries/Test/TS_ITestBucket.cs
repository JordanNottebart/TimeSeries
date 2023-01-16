using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries.Test
{
    interface TS_ITestBucket//Interface om buckets te testen
    {
        public bool PerformTestBucket(Bucket bucket);
    }
}
