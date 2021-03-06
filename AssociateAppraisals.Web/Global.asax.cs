﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AssociateAppraisals.Data;

namespace AssociateAppraisals.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Initialize database with dummy values
            //   System.Data.Entity.Database.SetInitializer(new AssociateAppraisalsSeedData());
            System.Data.Entity.Database.SetInitializer<AssociateAppraisalsEntities>(null);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Autofac and Automapper configurations
   //         Bootstrapper.Run();
        }
    }
}
