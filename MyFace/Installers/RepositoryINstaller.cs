using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using MyFace.DataAccess;

namespace MyFace.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IPostRepository>()
                    .ImplementedBy<PostRepository>()
                    .LifestyleSingleton());

            container.Register(
                Component
                    .For<IUserRepository>()
                    .ImplementedBy<UserRepository>()
                    .LifestyleSingleton());
        }
    }
}