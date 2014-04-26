using DateTimeService.Components;
using DateTimeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateTimeService.Controllers
{
    public class TimeZoneListController : Controller
    {
        //
        // GET: /TimeZoneList/
        public ActionResult Index()
        {
            var infos = TimeZoneInfo.GetSystemTimeZones();

            var returnValue = new List<TimeZoneModel>();

            foreach (var timeZone in infos)
            {
                returnValue.Add(new TimeZoneModel
                {
                    Code = TimeZoneHelper.TimeZoneList.TimeZones.SingleOrDefault(x=>x.Value.Equals(timeZone.Id)).Key
                    ,
                    Name = timeZone.Id
                    ,
                    UtcOffset = timeZone.BaseUtcOffset.ToString()
                    , IsDaylightSavingsTime = timeZone.IsDaylightSavingTime(DateTime.UtcNow)
                });
            }

            return View(returnValue);
        }
    }
}
