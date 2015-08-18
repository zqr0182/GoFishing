using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GoFishing.NServicebusMessage;
using NServiceBus;

namespace GoFishing.Presentation.Installers
{
    public class NServicebusMessageInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Classes.FromAssemblyContaining<GoFishing.NServicebusMessage.EventMessage>()
                                   .Where(type => !type.IsInterface)
                                   .WithServiceDefaultInterfaces()
                                   .LifestylePerWebRequest()
                                   );
        }
    }
}