using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public class TitleBucket
    {
        // Variables
        public string titleStartDate;
        public string titleEndDate;        
        public string titleBucketValue;

        public TitleBucket(string startDateLine, string endDateLine, string value)
        {
            this.titleStartDate = startDateLine;
            this.titleEndDate = endDateLine;
            this.titleBucketValue = value;
        }
    }
}
