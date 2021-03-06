[assembly: WebActivator.PreApplicationStartMethod(typeof(WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace WebUI.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Core.Models;
    using Core.Repositories;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBaseRepository<Coffee>>().To<BaseRepository<Coffee>>().InRequestScope();
            kernel.Bind<IBaseRepository<Flavor>>().To<BaseRepository<Flavor>>().InRequestScope();
            kernel.Bind<IBaseRepository<CurrentOrder>>().To<BaseRepository<CurrentOrder>>().InRequestScope();
            kernel.Bind<IBaseRepository<Order>>().To<BaseRepository<Order>>().InRequestScope();
            kernel.Bind<IBaseRepository<Comment>>().To<BaseRepository<Comment>>().InRequestScope();
        }        
    }
}
