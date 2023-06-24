using Core.Interface;

namespace Core
{
  public class Window
  {
    private ObjectModelBase Models;
    private ObjectControllerBase Controllers;
    private IWindowConfiguration SConfiguration;

    public Window(IWindowConfiguration configuration)
    {
      SConfiguration = configuration;
      Models = new ObjectModelBase(SConfiguration);
      Controllers = new ObjectControllerBase(SConfiguration);
    }

    public void Initialize()
    {
      Models.CreateModels();
      Controllers.CreateControllers();

      Models.SendCreateToAll();
      Controllers.SendCreateToAll();

      Models.SendInitializeToAll();
      Controllers.SendInitializeToAll();

      Models.SendStartToAll();
      Controllers.SendStartToAll();
    }

    public T GetModel<T>() where T : IObjectModel
    {
      return Models.GetModel<T>();
    }

    public T GetController<T>() where T : IObjectController
    {
      return Controllers.GetController<T>();
    }
  }
}
