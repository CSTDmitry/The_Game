using System;
using System.Collections.Generic;
using Core.Interface;

namespace Core
{
  class ObjectModelBase
  {
    private Dictionary<Type, IObjectModel> ModelsMap;
    private IWindowConfiguration SceneConfig;

    public ObjectModelBase(IWindowConfiguration config)
    {
      SceneConfig = config;
      ModelsMap = new Dictionary<Type, IObjectModel>();
    }

    public void CreateModels()
    {
      ModelsMap = SceneConfig.CreateModels();
    }

    public void SendCreateToAll()
    {
      foreach (var model in ModelsMap.Values)
      {
        model.Create();
      }
    }

    public void SendInitializeToAll()
    {
      foreach (var model in ModelsMap.Values)
      {
        model.Initialize();
      }
    }

    public void SendStartToAll()
    {
      foreach (var model in ModelsMap.Values)
      {
        model.Start();
      }
    }

    public T GetModel<T>() where T : IObjectModel
    {
      return (T)ModelsMap[typeof(T)];
    }
  }
}
