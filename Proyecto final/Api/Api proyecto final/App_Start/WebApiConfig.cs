using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api_proyecto_final
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Configuración y servicios de API web
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            // Ruta por defecto para la API
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Ruta específica para el Home
            config.Routes.MapHttpRoute(
                name: "Home",
                routeTemplate: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            // Configurar para devolver JSON por defecto
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
