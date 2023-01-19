using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public struct Bucket//Struct
    {
        public DateTime startDate;
        public DateTime? endDate;        //Variabelen
        public string bucketValue;

        public static Bucket GetBucket(DateTime startDateLine, DateTime? endDateLine, string value)
        {
            Bucket bucket = new Bucket();
            bucket.startDate = startDateLine;
            bucket.endDate = endDateLine;
            bucket.bucketValue = value;
            return bucket;
        }
    }
}
