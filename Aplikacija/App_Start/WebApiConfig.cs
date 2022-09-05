using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Aplikacija
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
           

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            SetJSONFormat(config);
        }

        private static void SetJSONFormat(HttpConfiguration config) //vraca podatke u JSON formatu
        {
            var xml = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(mt => mt.MediaType == "application/xml");

            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(xml);
        }
    }


}
