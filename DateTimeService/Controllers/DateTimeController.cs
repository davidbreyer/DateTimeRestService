﻿using DateTimeService.Components;
using DateTimeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DateTimeService.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    [RoutePrefix("api/json")]
    public class DateTimeController : ApiController
    {
        [Route("{timeZone}/{date}")]
        public DateTimeResponse Get(string timeZone, string date)
        {
            return TimeZoneHelper.ProcessRequest(timeZone, date);
        }
    }
}
