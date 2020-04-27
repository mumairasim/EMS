using System.Collections.Generic;
using Autofac;
using Autofac.Integration.WebApi;
using SMS.DATA.Implementation;
using SMS.DATA.Infrastructure;
using System.Reflection;
using System.Web.Http;
using AutoMapper;
using SMS.REQUESTDATA.Implementation;
using SMS.REQUESTDATA.Infrastructure;
using SMS.MAP;

namespace SMS.API.Registrar
{
    public class DependencyRegistrar
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RequestRepository<>)).As(typeof(IRequestRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<RequestUnitOfWork>().As<IRequestUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.Load("SMS.SERVICES"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("SMS.FACADE"))
                .Where(t => t.Name.EndsWith("Facade"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                //add your profiles (either resolve from container or however else you acquire them)
                foreach (var profile in c.Resolve<IEnumerable<MapperConfigurationInternal>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            //register your mapper
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
            //builder.RegisterType<Test>().AsSelf();
            var container = builder.Build();
            
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }

    }

}