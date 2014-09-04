using System.Data.Entity;
using System.Web.Http;
using BowlingSPAService.Model.EntityModels;
using BowlingSPAService.Repository.Repositories;
using BowlingSPAService.Repository.RepoTransactions;
using BowlingSPAService.WebAPI.Helpers;
using Microsoft.Practices.Unity;

namespace BowlingSPAService.WebAPI.App_Start
{
    public static class Bootstrapper
    {

        /// <summary>
        /// Basic framework code to initialize the Unity IoC Framework
        /// </summary>
        public static void Initialize()
        {

            var container = BuildUnityContainer();

            //Relies on UnityDependencyResolver from Unity.WebAPI package which provides an implementation of the IDependencyResolver interface that wraps a Unity container.
            //This way we do not have to write the default implementation on our own.
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        /// <summary>
        /// Contains registrations for each Interface to its mapped concrete type.
        /// </summary>
        /// <returns>IUnityContainer</returns>
        public static IUnityContainer BuildUnityContainer()
        {

            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();   
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IRepository, Repository.Repositories.Repository>();
            container.RegisterType<DbContext, BowlingStatsEntities>(new HttpContextLifetimeManager());

            return container;
        }


    }
}