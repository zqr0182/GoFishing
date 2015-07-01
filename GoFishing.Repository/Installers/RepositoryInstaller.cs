using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GoFishing.Repository.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(GoFishingRepository<>)).ImplementedBy(typeof(GoFishingRepository<>)).LifestylePerWebRequest(),
                 Component.For<IUnitOfWork>().ImplementedBy<GoFishingUnitOfWork>().LifestylePerWebRequest(),              
                 Component.For<GoFishingContext>().ImplementedBy<GoFishingContext>().LifestylePerWebRequest());
        }
    }
}


