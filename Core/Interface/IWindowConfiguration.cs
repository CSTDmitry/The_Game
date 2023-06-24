using System;
using System.Collections.Generic;
using Core.Interface;

namespace Core.Interface
{
  public interface IWindowConfiguration
  {
    public Dictionary<Type, IObjectModel> CreateModels();
    public Dictionary<Type, IObjectController> CreateControllers();
  }
}
