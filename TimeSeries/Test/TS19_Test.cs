using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    class TS19_Test : TS_ITestBucket
    {
        public bool PerformTestBucket(Bucket bucket)
        {
            // Variables
            ErrorMessage = "Date does not exist";
            DateTime dateLowerLimit = new DateTime(0001, 01, 01, 0, 0, 0);
            DateTime dateUpperLimit = new DateTime(9999, 12, 31, 23, 59, 59);
            
            // If the startDate or the endDate is not in between the limits
            if (bucket.startDate < dateLowerLimit || bucket.startDate > dateUpperLimit || bucket.endDate < dateLowerLimit || bucket.endDate > dateUpperLimit)
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

