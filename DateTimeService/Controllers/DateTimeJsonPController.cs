using DateTimeService.Components;
using DateTimeService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebApiContrib.Formatting.Jsonp;

namespace DateTimeService.Controllers
{
    [RoutePrefix("api/jsonp")]
    [JsonPFormatterAttribute]
    public class DateTimeJsonPController : ApiController
    {
        [Route("{timeZone}/{date}")]
        public DateTimeResponse Get(string timeZone, string date, string callBack)
        {

            return TimeZoneHelper.ProcessRequest(timeZone, date);
            //return new DateTimeJsonPController().Get(timeZone, callBack);
            //        Id	"E. Europe Standard Time"	string
            //        Id	"W. Europe Standard Time"	string
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


        // GET api/values
        //[Route("datetime/{timeZone}")]
        //public DateTimeResponse Get(string timeZone, string callBack)
        //{
        //    //		Id	"E. Europe Standard Time"	string
        //    //		Id	"W. Europe Standard Time"	string
        //    //Eastern Standard Time

        //    try
        //    {

        //        if (timeZone == "est")
        //        {
        //            timeZone = "Eastern Standard Time";
        //        }

        //        var timeZoneInfo = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timeZone));

        //        return new DateTimeResponse
        //        {
        //            CurrentDateTime = timeZoneInfo
        //            ,
        //            IsDayLightSavingsTime = timeZoneInfo.IsDaylightSavingTime()
        //            ,
        //            UTCOffset = TimeZoneInfo.FindSystemTimeZoneById(timeZone).GetUtcOffset(timeZoneInfo).ToString()
        //            ,
        //            TimeZoneName = TimeZoneInfo.FindSystemTimeZoneById(timeZone).Id
        //            ,
        //            CurrentFileTime = timeZoneInfo.ToFileTime()
        //        };
        //    }
        //    catch (System.TimeZoneNotFoundException)
        //    {
        //        return new DateTimeResponse
        //        {
        //            ServiceResponse = string.Format("{0} is not a valid Time Zone. Check the Time Zone Service for a list of valid time zones.", timeZone)
        //        };
        //    }
        //    //TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timeZone)); //"E. Europe Standard Time")); //"Eastern Standard Time"));
        //}

        [Route("datetime")]
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

        public class JsonPFormatterAttribute : Attribute, IControllerConfiguration
        {
            public void Initialize(HttpControllerSettings settings,
                HttpControllerDescriptor descriptor)
            {
                // Clear the formatters list.
                //settings.Formatters.Clear();

                var jsonFormatter = settings.Formatters.JsonFormatter;
                jsonFormatter.SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                // Insert the JSONP formatter in front of the standard JSON formatter.
                var jsonpFormatter = new JsonpMediaTypeFormatter(settings.Formatters.JsonFormatter);
                settings.Formatters.Insert(0, jsonpFormatter);

                // Add a custom media-type formatter.
                //settings.Formatters.Add(settings.Formatters.JsonFormatter);
            }
        }
    }

