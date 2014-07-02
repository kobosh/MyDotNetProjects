using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace MessageBoards
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();   // Web API configuration and services
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            
            // Web API routes
            config.MapHttpAttributeRoutes();
           config.Routes.MapHttpRoute(
                name: "RepliesRoute",
                routeTemplate: "api/v1/topics/{topicid}/replies/{id}",
                defaults: new {controller="replies", id = RouteParameter.Optional }
            );
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/topics/{id}",
                defaults: new {Controller="topics", id = RouteParameter.Optional }
            );
        }
    }
}
