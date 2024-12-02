using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
namespace Api_proyecto_final
{
     public class WebApiApplication : HttpApplication
        {
            protected void Application_Start()
            {
                // Configuración de Web API
                GlobalConfiguration.Configure(WebApiConfig.Register);

                // Configurar el formateador JSON para usar camelCase
                var formatters = GlobalConfiguration.Configuration.Formatters;
                var jsonFormatter = formatters.JsonFormatter;
                var settings = jsonFormatter.SerializerSettings;
                settings.Formatting = Newtonsoft.Json.Formatting.Indented;
                settings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

                // Eliminar el formateador XML si solo quieres respuestas JSON
                var xmlFormatter = formatters.XmlFormatter;
                formatters.Remove(xmlFormatter);
            }
    }
}
