using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries.Test
{
    public interface TS_ITestBucket//Interface om buckets te testen
    {
        public string ErrorMessage { get; set; }
        public bool PerformTestBucket(Bucket bucket);
    }
}
