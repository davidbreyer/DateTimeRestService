using DateTimeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateTimeService.Components
{
    public static class TimeZoneHelper
    {
        public static TimeZoneList TimeZoneList { get; set; }

        public static DateTimeResponse ProcessRequest(string timeZoneCode, string date)
        {
            try 
            {
                //Get Requested TimeZone Name from Friendly Code
                var timeZone = GetTimeZoneName(timeZoneCode);
                //Get Time Zone object by Time Zone Name.
                var timeZoneToReturn = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                //Parse the passed date.
                var dateToReturn = ProcessNaturalLanguage(date, timeZoneToReturn);
                //Convert UTC time to the requested time zone.
                var timeZoneInfo = TimeZoneInfo.ConvertTimeFromUtc(dateToReturn.DateTime, timeZoneToReturn);

                if (timeZoneInfo.Date != DateTime.MinValue)
                {
                    return new DateTimeResponse
                    {
                        CurrentDateTime = FormatDateTime(timeZoneInfo, timeZoneToReturn)
                        ,
                        IsDayLightSavingsTime = timeZoneToReturn.IsDaylightSavingTime(timeZoneInfo)
                        ,
                        UTCOffset = timeZoneToReturn.GetUtcOffset(timeZoneInfo).ToString()
                        ,
                        TimeZoneName = timeZoneToReturn.Id
                        ,
                        CurrentFileTime = timeZoneInfo.ToFileTime()
                        ,
                        DayOfTheWeek = timeZoneInfo.DayOfWeek.ToString()
                        ,
                        OrdinalDate = string.Format("{0}-{1}", timeZoneInfo.Year, timeZoneInfo.DayOfYear)
                    };
                }
                else
                {
                    return new DateTimeResponse
                    {
                        ServiceResponse = string.Format("{0} is not a valid date or command.", date)
                    };
                }
            } 
            catch(System.TimeZoneNotFoundException)
            {
                return new DateTimeResponse
                {
                    ServiceResponse = string.Format("{0} is not a valid Time Zone. Check the Time Zone Service for a list of valid time zones.", timeZoneCode)
                };
            }
        }

        private static string FormatDateTime(DateTime timeZoneInfo, TimeZoneInfo timeZoneToReturn)
        {
            if(timeZoneToReturn.Id.Equals("utc", StringComparison.InvariantCultureIgnoreCase))
            {
                return string.Format("{0}{1}", timeZoneInfo.ToString("yyyy-MM-ddTHH\\:mm\\:ss"), "Z");
            }

            return string.Format("{0}{1}", timeZoneInfo.ToString("yyyy-MM-ddTHH\\:mm\\:ss"), GetOffSetFormatted(timeZoneInfo, timeZoneToReturn));
        }

        private static string GetOffSetFormatted(DateTime timeZoneInfo, TimeZoneInfo timeZoneToReturn)
        {
            var offSetBase = timeZoneToReturn.GetUtcOffset(timeZoneInfo);
            if (offSetBase.ToString().Contains("-")) return offSetBase.ToString();

            return string.Format("+{0}", offSetBase);
        }


        private static string GetTimeZoneName(string timeZoneCode)
        {
            if (TimeZoneList.TimeZones.ContainsKey(timeZoneCode))
            {
               return TimeZoneList.TimeZones.SingleOrDefault(x => x.Key.Equals(timeZoneCode, StringComparison.CurrentCultureIgnoreCase)).Value;
            }
            else
            {
                return timeZoneCode;
            }
        }

        private static DateTimeOffset ProcessNaturalLanguage(string date, TimeZoneInfo timeZoneToReturn)
        {
            switch (date.ToLower())
            {
                case "now":
                    return DateTimeOffset.UtcNow;
                case "tomorrow":
                    return DateTimeOffset.UtcNow.AddHours(24);
                case "yesterday":
                    return DateTimeOffset.UtcNow.AddHours(-24);
                default:
                    DateTime outDate;
                    DateTime.TryParse(date, out outDate);
                    return TimeZoneInfo.ConvertTimeToUtc(outDate, timeZoneToReturn);
            }
        }
    }
}