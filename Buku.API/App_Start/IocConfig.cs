using Autofac;
using Autofac.Integration.WebApi;
using Buku.BLL;
using Buku.Contract;
using Owin;
using System.Reflection;
using System.Web.Http;

namespace Buku.API.App_Start
{
    public class IocConfig
    {
        public static IContainer BuildContainer(IAppBuilder app, HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //RegisterBLL
            builder.RegisterType<BukuBLL>().As<IBukuBLL>();
            builder.RegisterType<AuthorBLL>().As<IAuthorBLL>();
            builder.RegisterType<StudentBLL>().As<IStudentBLL>();

            var container = builder.Build();
            
            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API 
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(configuration);
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}