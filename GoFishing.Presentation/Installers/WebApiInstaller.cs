using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GoFishing.Presentation.Installers
{
    public class WebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
        }

        internal class WindsorWebApiDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
        {
            private readonly IKernel _container;

            public WindsorWebApiDependencyResolver(IKernel container)
            {
                _container = container;
            }

            public IDependencyScope BeginScope()
            {
                return new WindsorWebApiDependencyScope(_container);
            }

            public object GetService(Type serviceType)
            {
                return _container.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _container.ResolveAll(serviceType).Cast<object>();
            }

            public void Dispose() { }
        }
        public class WindsorWebApiDependencyScope : IDependencyScope
        {
            private readonly IKernel _container;
            private readonly IDisposable _scope;

            public WindsorWebApiDependencyScope(IKernel container)
            {
                _container = container;
                _scope = container.BeginScope();
            }

            public object GetService(Type serviceType)
            {
                return _container.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _container.ResolveAll(serviceType).Cast<object>();
            }

            public void Dispose()
            {
                _scope.Dispose();
            }
        }
    }
}