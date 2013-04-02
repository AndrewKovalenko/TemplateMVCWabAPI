using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infrastructure.BaseRepository;
using ProjectTemplate.Infrastructure.BaseRepository.Interfaces;
using ProjectTemplate.Infrastructure.DataBaseContext;
using ProjectTemplate.Infrastructure.DataBaseContext.Interfaces;
using ProjectTemplate.Web.App_Start;

namespace ProjectTemplate.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoFacConfig.ApplyConfiguration();
            AutoMappingConf.ApplyMappings();
        }
    }
}