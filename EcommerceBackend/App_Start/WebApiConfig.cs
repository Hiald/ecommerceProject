﻿using System.Web.Http;

namespace EcommerceBackend
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
            //.Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
            //                              "text/html",
            //                              StringComparison.InvariantCultureIgnoreCase,
            //                              true,
            //                              "application/json"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}