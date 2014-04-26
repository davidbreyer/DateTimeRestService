using DateTimeService.Components;
using DateTimeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DateTimeService.Controllers
{
    [RoutePrefix("api/json")]
    public class DateTimeController : ApiController
    {
        // GET api/values
        [Route("{timeZone}/{date}")]
        //[Route("api/datetime/{timeZone}")]
        public DateTimeResponse Get(string timeZone, string date)
        {

            return TimeZoneHelper.ProcessRequest(timeZone, date);
            //		Id	"E. Europe Standard Time"	string
            //		Id	"W. Europe Standard Time"	string
            //Eastern Standard Time

            //try
            //{
            //    if (timeZone == "est")
            //    {
            //        timeZone = "Eastern Standard Time";
            //    }

            //    DateTime dateToReturn = DateTime.UtcNow;

            //    if (!date.Equals("now", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        DateTime.TryParse(date, out dateToReturn);
            //        dateToReturn = TimeZoneInfo.ConvertTimeToUtc(dateToReturn, TimeZoneInfo.FindSystemTimeZoneById(timeZone));

            //    }

            //    var timeZoneInfo = TimeZoneInfo.ConvertTimeFromUtc(dateToReturn, TimeZoneInfo.FindSystemTimeZoneById(timeZone));

            //    return new DateTimeResponse
            //    {
            //        CurrentDateTime = timeZoneInfo
            //        ,
            //        IsDayLightSavingsTime = timeZoneInfo.IsDaylightSavingTime()
            //        ,
            //        UTCOffset = TimeZoneInfo.FindSystemTimeZoneById(timeZone).GetUtcOffset(timeZoneInfo).ToString()
            //        ,
            //        TimeZoneName = TimeZoneInfo.FindSystemTimeZoneById(timeZone).Id
            //        ,
            //        CurrentFileTime = timeZoneInfo.ToFileTime()
            //    };
            //} 
            //catch(System.TimeZoneNotFoundException)
            //{
            //    return new DateTimeResponse
            //    {
            //        ServiceResponse = string.Format("{0} is not a valid Time Zone. Check the Time Zone Service for a list of valid time zones.", timeZone)
            //    };
            //}
                //TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timeZone)); //"E. Europe Standard Time")); //"Eastern Standard Time"));
        }

        //[Route("api/{timeZone}/{date}")]
        public DateTimeResponse Get(string timeZone, string date, string callBack)
        {
            return new DateTimeJsonPController().Get(timeZone, date, callBack);
            //		Id	"E. Europe Standard Time"	string
            //		Id	"W. Europe Standard Time"	string
            //Eastern Standard Time

            //try
            //{
            //    DateTime dateToReturn = DateTime.UtcNow;

            //    if (!date.Equals("now", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        DateTime.TryParse(date, out dateToReturn);
            //    }

            //    if (timeZone == "est")
            //    {
            //        timeZone = "Eastern Standard Time";
            //    }

            //    var timeZoneInfo = TimeZoneInfo.ConvertTimeFromUtc(dateToReturn, TimeZoneInfo.FindSystemTimeZoneById(timeZone));

            //    return new DateTimeResponse
            //    {
            //        CurrentDateTime = timeZoneInfo
            //        ,
            //        IsDayLightSavingsTime = timeZoneInfo.IsDaylightSavingTime()
            //        ,
            //        UTCOffset = TimeZoneInfo.FindSystemTimeZoneById(timeZone).GetUtcOffset(timeZoneInfo).ToString()
            //        ,
            //        TimeZoneName = TimeZoneInfo.FindSystemTimeZoneById(timeZone).Id
            //        ,
            //        CurrentFileTime = timeZoneInfo.ToFileTime()
            //    };
            //}
            //catch (System.TimeZoneNotFoundException)
            //{
            //    return new DateTimeResponse
            //    {
            //        ServiceResponse = string.Format("{0} is not a valid Time Zone. Check the Time Zone Service for a list of valid time zones.", timeZone)
            //    };
            //}
            //TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timeZone)); //"E. Europe Standard Time")); //"Eastern Standard Time"));
        }

        [Route("api/datetime")]
        public DateTimeResponse Get()
        {
            //		Id	"E. Europe Standard Time"	string
            //		Id	"W. Europe Standard Time"	string
            //Eastern Standard Time
            return new DateTimeResponse
            {
                CurrentDateTime = DateTime.UtcNow
                ,
                UTCOffset = TimeZoneInfo.FindSystemTimeZoneById("UTC").GetUtcOffset(DateTime.UtcNow).ToString()
                ,
                IsDayLightSavingsTime = TimeZoneInfo.FindSystemTimeZoneById("UTC").IsDaylightSavingTime(DateTime.UtcNow)
                ,
                TimeZoneName = TimeZoneInfo.FindSystemTimeZoneById("UTC").Id
                ,
                CurrentFileTime = DateTime.UtcNow.ToFileTime()
            };
            //return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")); //"E. Europe Standard Time")); //"Eastern Standard Time"));
        }
    }
}
