using ProjectManager.BusinessLayer;
using ProjectManager.DataLayer.Repository;
using ProjectManager.Entities;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ProjectManager.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IProjectManagerService, ProjectManagerService>();
            container.RegisterType<IRepository<Task>, Repository<Task>>();
            container.RegisterType<IRepository<ParentTask>, Repository<ParentTask>>();
            container.RegisterType<IRepository<User>, Repository<User>>();
            container.RegisterType<IRepository<Project>, Repository<Project>>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}