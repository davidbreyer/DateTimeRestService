﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DateTimeService.Controllers
{
    [JsonFormatter]
    public class TimeZoneController : ApiController
    {
        
        public ICollection<string> Get()
        {
            var infos = TimeZoneInfo.GetSystemTimeZones();

            var returnValue = new List<string>();

            foreach(var timeZone in infos)
            {
                returnValue.Add(string.Format("{0},{1}", timeZone.Id, timeZone.BaseUtcOffset));
            }

            return returnValue;
        }
    }

    public class JsonFormatter : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings settings,
            HttpControllerDescriptor descriptor)
        {
            var json = settings.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            settings.Formatters.Remove(settings.Formatters.XmlFormatter);
        }
    }
}
