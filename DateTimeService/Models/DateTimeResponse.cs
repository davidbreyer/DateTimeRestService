using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateTimeService.Models
{
    public class DateTimeResponse
    {
        public string CurrentDateTime { get; set; }
        public string UTCOffset { get; set; }
        public bool IsDayLightSavingsTime { get; set; }
        public string DayOfTheWeek { get; set; }
        public string TimeZoneName { get; set; }
        public long CurrentFileTime { get; set; }
        public string OrdinalDate { get; set; }
        public string ServiceResponse { get; set; }
    }
}