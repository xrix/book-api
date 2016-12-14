using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Buku.API.App_Start;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

[assembly: OwinStartup(typeof(Buku.API.Startup))]

namespace Buku.API
{
    public partial class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }

        public void Configuration(IAppBuilder app)
        {

            HttpConfiguration = new HttpConfiguration();
            Bootstrap();
            var container = IocConfig.BuildContainer(app, HttpConfiguration);

            WebApiConfig.Register(HttpConfiguration, container);

            app.UseWebApi(HttpConfiguration);


        }

        private static void Bootstrap()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            // Configure AutoMapper
            Mappings.AutoMapperConfig.Initialize();
        }
    }
}
