using System;
using System.Collections.Generic;
using Core.Interface;

namespace Core.Abstract
{
  public abstract class AWindowConfiguration : IWindowConfiguration
  {
    public abstract sbyte ID { get; }
    public abstract Dictionary<Type, IObjectModel> CreateModels();
    public abstract Dictionary<Type, IObjectController> CreateControllers();

    public void CreateModel<T>(Dictionary<Type, IObjectModel> modelsMap) where T : IObjectModel, new()
    {
      modelsMap[typeof(T)] = new T();
    }

    public void CreateController<T>(Dictionary<Type, IObjectController> controllersMap) where T : IObjectController, new()
    {
      controllersMap[typeof(T)] = new T();
    }
  }
}
