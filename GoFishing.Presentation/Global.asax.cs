using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using GoFishing.Application.Installers;
using GoFishing.Application.Services;
using GoFishing.Presentation.Installers;
using GoFishing.Repository.Installers;

using NServiceBus;

namespace GoFishing.Presentation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class Global : System.Web.HttpApplication
    {
        public static IWindsorContainer Container;

        public static IBus Bus { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootstrapContainer();

            ConfigNServicebus();

        }

        private static void ConfigNServicebus()
        {
            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName(ConfigurationManager.AppSettings["NServicebusEndpointName"]);
            busConfiguration.UseSerialization<XmlSerializer>();
            busConfiguration.EnableInstallers();
            busConfiguration.UsePersistence<InMemoryPersistence>();

            busConfiguration.UseContainer<WindsorBuilder>(c => c.ExistingContainer(Container));

            Bus = NServiceBus.Bus.Create(busConfiguration).Start();
        }

        private static void BootstrapContainer()
        {
            Container = new WindsorContainer().Install(FromAssembly.This(),
                                                        FromAssembly.Containing<RepositoryInstaller>(),
                                                        FromAssembly.Containing<WebApiInstaller>(),
                                                        FromAssembly.Containing<NServicebusMessageInstaller>(),
                                                        FromAssembly.Containing<ServicesInstaller>());
            Container.AddFacility<LoggingFacility>(f => f.UseNLog());
            GlobalConfiguration.Configuration.DependencyResolver = new WebApiInstaller.WindsorWebApiDependencyResolver(Container.Kernel);
        }
    }
}