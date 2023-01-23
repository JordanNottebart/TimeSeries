using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TimeSeries.Test
{
    class TS18_Test : TS_ITestBucket
    {
        public string ErrorMessage { get; set; }
        
        DateTime result;
        bool TS_ITestBucket.PerformTestBucket(Bucket bucket)//Method die bekijkt of de start en enddate in het juiste formaat staat
        {
            ErrorMessage = "Start or End date was not in the correct format";
            return DateTime.TryParseExact(bucket.startDate.ToString(),
                "yyyy/MM/dd hh:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out result)
                && DateTime.TryParseExact(bucket.endDate.ToString(),
                "yyyy/MM/dd hh:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out result);

        }
    }
}
