using System.Web.Http;
using System.Web.Http.Cors;

namespace BowlingSPAService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            //CORS Configuration  - uses Microsoft.AspNet.WebApi.Cors NuGet package
            //This provides a full framework for allowing CORS customizations and policy definitions            
            //(sample app, don't configure 'all' in a production situation)
            var cors = new EnableCorsAttribute("http://localhost:55716", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
