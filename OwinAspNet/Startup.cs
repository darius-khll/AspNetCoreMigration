using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(OwinAspNet.Startup))]

namespace OwinAspNet
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseMyMiddleware();

            app.UseWebApi(GetHttpConfig());
        }

        private HttpConfiguration GetHttpConfig()
        {
            HttpConfiguration config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            return config;
        }
    }
}
