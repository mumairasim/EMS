using Autofac;
using Autofac.Integration.WebApi;
using SMS.DATA.Implementation;
using SMS.DATA.Infrastructure;
using System.Reflection;
using System.Web.Http;
using SMS.REQUESTDATA.Implementation;
using SMS.REQUESTDATA.Infrastructure;

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
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }
    }
}