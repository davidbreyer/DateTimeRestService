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
        }
    }

        public class JsonPFormatterAttribute : Attribute, IControllerConfiguration
        {
            public void Initialize(HttpControllerSettings settings,
                HttpControllerDescriptor descriptor)
            {
                var jsonFormatter = settings.Formatters.JsonFormatter;
                jsonFormatter.SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                // Insert the JSONP formatter in front of the standard JSON formatter.
                var jsonpFormatter = new JsonpMediaTypeFormatter(settings.Formatters.JsonFormatter);
                settings.Formatters.Insert(0, jsonpFormatter);
            }
        }
    }

