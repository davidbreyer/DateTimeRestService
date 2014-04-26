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
                var timeZoneInfo = TimeZoneInfo.ConvertTimeFromUtc(dateToReturn, timeZoneToReturn);

                return new DateTimeResponse
                {
                    CurrentDateTime = timeZoneInfo
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
                };
            } 
            catch(System.TimeZoneNotFoundException)
            {
                return new DateTimeResponse
                {
                    ServiceResponse = string.Format("{0} is not a valid Time Zone. Check the Time Zone Service for a list of valid time zones.", timeZoneCode)
                };
            }
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

        private static DateTime ProcessNaturalLanguage(string date, TimeZoneInfo timeZoneToReturn)
        {
            if (!date.Equals("now", StringComparison.CurrentCultureIgnoreCase))
            {
                DateTime outDate;
                DateTime.TryParse(date, out outDate);
                return TimeZoneInfo.ConvertTimeToUtc(outDate, timeZoneToReturn);
            }

            return DateTime.UtcNow;
        }
    }
}