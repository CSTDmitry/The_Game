using System.Threading.Tasks;
using Core.Interface;
using Core.Model;

namespace Core.Controller
{
  public class UserController : IObjectController
  {
    private UserModel Model;

    public void Create()
    {
      Model = new UserModel();
    }

    public void Initialize()
    {
    }

    public void Start()
    {
    }

    public async Task<string> TryToConnect(string email, string password)
    {
      return await Model.Connect(email, password);
    }

    public async Task<string> Test()
    {
      return await Model.GetTest();
    }
  }
}
