using Membership.Controllers;
using Membership.Models;
using Membership.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Membership
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<DbContext>();
            //container.RegisterType<ApplicationDbContext>();
            //container.RegisterType<ApplicationUserManager>();
            //container.RegisterType<ApplicationSignInManager>();
            //container.RegisterType<UserManager<ApplicationUser>>();



            //container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //container.RegisterTypes(AllClasses.FromLoadedAssemblies().Where(x => x.Name.Contains("Service")), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.ContainerControlled);

            container.RegisterType<IApplicationDbContext, ApplicationDbContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            //container.RegisterType<AccountController>(new InjectionConstructor());


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}