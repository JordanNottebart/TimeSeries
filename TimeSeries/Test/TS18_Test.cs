using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TimeSeries
{
    class TS18_Test : TS_ITestFileFormat
    {
        public string ErrorMessage { get; set; }
        
        DateTime result;
        public bool PerformTest(string[] splitstring)//Method die bekijkt of de start en enddate in het juiste formaat staat
        {
            string startDate = splitstring[0];
            string endDate = splitstring[1];
            ErrorMessage = "Start or End date was not in the correct format";
            return DateTime.TryParseExact(startDate,
                "yyyy/MM/dd hh:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out result)
                && DateTime.TryParseExact(endDate,
                "yyyy/MM/dd hh:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out result);

        }
    }
}
