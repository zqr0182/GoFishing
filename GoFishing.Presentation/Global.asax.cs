using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using GoFishing.Application.Installers;
using GoFishing.Application.Services;
using GoFishing.Presentation.Installers;
using GoFishing.Repository.Installers;

namespace GoFishing.Presentation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootstrapContainer();
        }

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer().Install(FromAssembly.This(),
                                                        FromAssembly.Containing<RepositoryInstaller>(),
                                                        FromAssembly.Containing<WebApiInstaller>(),
                                                        FromAssembly.Containing<ServicesInstaller>());
        
            GlobalConfiguration.Configuration.DependencyResolver = new DependencyResolver(_container.Kernel);
        }
    }
}