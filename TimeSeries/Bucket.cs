using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public struct Bucket//Struct
    {
        public string startDate;
        public string? endDate;        //Variabelen
        public object bucketValue;

        public static Bucket GetBucket(string startDateLine, string? endDateLine, object value)
        {
            Bucket bucket = new Bucket();
            bucket.startDate = startDateLine;
            bucket.endDate = endDateLine;
            bucket.bucketValue = value;
            return bucket;
        }
    }
}
