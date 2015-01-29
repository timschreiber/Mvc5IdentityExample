using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Mvc5IdentityExample.Domain;
using Mvc5IdentityExample.Data.EntityFramework;
using Mvc5IdentityExample.Web.Identity;
using Microsoft.AspNet.Identity;
using System;

namespace Mvc5IdentityExample.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor("Mvc5IdentityExample"));
            container.RegisterType<IUserStore<IdentityUser, Guid>, UserStore>(new TransientLifetimeManager());
            container.RegisterType<RoleStore>(new TransientLifetimeManager());
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}