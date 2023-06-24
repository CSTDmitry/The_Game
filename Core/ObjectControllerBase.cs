using System;
using System.Collections.Generic;
using Core.Interface;

namespace Core
{
  public class ObjectControllerBase
  {
    private Dictionary<Type, IObjectController> ControllersMap;
    private IWindowConfiguration WindowConfiguration;

    public ObjectControllerBase(IWindowConfiguration configuration)
    {
      WindowConfiguration = configuration;
      ControllersMap = new Dictionary<Type, IObjectController>();
    }

    public void CreateControllers()
    {
      ControllersMap = WindowConfiguration.CreateControllers();
    }

    public void SendCreateToAll()
    {
      foreach (var controller in ControllersMap.Values)
      {
        controller.Create();
      }
    }

    public void SendInitializeToAll()
    {
      foreach (var controller in ControllersMap.Values)
      {
        controller.Initialize();
      }
    }

    public void SendStartToAll()
    {
      foreach (var controller in ControllersMap.Values)
      {
        controller.Start();
      }
    }

    public T GetController<T>() where T : IObjectController
    {
      return (T)ControllersMap[typeof(T)];
    }
  }
}
