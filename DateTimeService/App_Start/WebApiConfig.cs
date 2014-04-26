using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;

namespace DateTimeService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
            //config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));

            //var jsonFormatter = config.Formatters.JsonFormatter;
            //jsonFormatter.SerializerSettings = new JsonSerializerSettings
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver()
            //};

            //// Insert the JSONP formatter in front of the standard JSON formatter.
            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonpFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //name: "Api UriPathExtension",
            //routeTemplate: "api/{controller}.{ext}/{id}",
            //defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //name: "Api UriPathExtension2",
            //routeTemplate: "api/{controller}/{id}.{ext}",
            //defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //name: "DefaultApi",
            //routeTemplate: "api/{controller}/{id}/{callBack}",
            //defaults: new
            //{
            //    id = RouteParameter.Optional,
            //    callBack = RouteParameter.Optional
            //}
        //);
        }
    }
}
