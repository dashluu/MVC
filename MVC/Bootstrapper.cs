using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using MVC.Controllers;
using MVC.Services.Services;
using MVC.DAL.DAL;
using MVC.DAL.Entities;

namespace MVC
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>(); 
            container.RegisterType<IBaseRepository<BlogEntity, int>, BlogRepository>();
            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<IController, HomeController>();
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}