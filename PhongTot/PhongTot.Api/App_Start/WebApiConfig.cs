﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PhongTot.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();
            JsonSerializerSettings jSettings = new Newtonsoft.Json.JsonSerializerSettings();
            jSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jSettings;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
