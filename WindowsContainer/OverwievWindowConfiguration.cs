using System;
using System.Collections.Generic;
using Core;
using Core.Interface;
using Core.Abstract;

namespace Windows.Configuration
{
  public class OverwievWindowConfiguration : AWindowConfiguration
  {
    public const sbyte WINDOW_ID = 1;
    public override sbyte ID => WINDOW_ID;

    public override Dictionary<Type, IObjectModel> CreateModels()
    {
      var modelsMap = new Dictionary<Type, IObjectModel>();
      return modelsMap;
    }

    public override Dictionary<Type, IObjectController> CreateControllers()
    {
      var controllersMap = new Dictionary<Type, IObjectController>();
      CreateController<TestController>(controllersMap);
      return controllersMap;
    }
  }
}