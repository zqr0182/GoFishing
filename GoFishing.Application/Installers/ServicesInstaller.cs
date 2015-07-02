using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GoFishing.Application.Services;

namespace GoFishing.Application.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<FishingService>()
                                  .Where(type => type.Name.EndsWith("Service") && !type.IsInterface)
                                  .WithServiceDefaultInterfaces()
                                  .LifestylePerWebRequest()
                                  );
        }
    }
}
