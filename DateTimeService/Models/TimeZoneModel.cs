using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateTimeService.Models
{
    public class TimeZoneModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string UtcOffset { get; set; }
        public bool IsDaylightSavingsTime { get; set; }
    }
}