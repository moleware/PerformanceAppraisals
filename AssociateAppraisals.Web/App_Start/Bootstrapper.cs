using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using AssociateAppraisals.Model;
using AssociateAppraisals.Data;
using AssociateAppraisals.Data.Infrastructure;
using AssociateAppraisals.Data.Repositories;
using AssociateAppraisals.Service;
using AssociateAppraisals.Web.Mappings;


namespace AssociateAppraisals.Web
{
    public class Bootstrapper
    {
        public static void Run()
        {
            // Start AutoFac
            SetAutofacContainer();

            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(AppraisalRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(AppraisalService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
