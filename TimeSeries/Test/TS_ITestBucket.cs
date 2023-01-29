using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public interface TS_ITestBucket
        //Interface om buckets te testen
    {
        public string ErrorMessage { get; set; }//Property
        public bool PerformTestBucket(Bucket bucket);//Method
    }
}
