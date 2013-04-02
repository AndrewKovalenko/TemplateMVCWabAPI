using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ProjectTemplate.Infrastructure.BaseRepository;
using ProjectTemplate.Infrastructure.BaseRepository.Interfaces;
using ProjectTemplate.Infrastructure.DataBaseContext;
using ProjectTemplate.Infrastructure.DataBaseContext.Interfaces;

namespace ProjectTemplate.Web.App_Start
{
    public static class AutoFacConfig
    {

        private static readonly ContainerBuilder Builder = new ContainerBuilder();
        public static void ApplyConfiguration()
        {
            Builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            Builder.RegisterControllers(Assembly.GetExecutingAssembly());

            ApplyModulesDependencies();

            var container = Builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void ApplyModulesDependencies()
        {
            Builder.RegisterType<DataBaseFactory>().As<IDataBaseFactory>();
            Builder.RegisterGeneric(typeof(BaseRepository<,>)).As(typeof(IBaseRepository<,>));
            Builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            Builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
        }
    }
}