using System;
using System.Threading.Tasks;
using Core.Interface;

namespace Core
{
  public partial class TestController : IObjectController
  {
    public void Create()
    {
    }

    public void Initialize()
    {
    }

    public void Start()
    {
    }

    public string TestCall()
    {
      return "Test Controller Ready";
    }

    public async Task<string> TryToConnect(string eMail, string password)
    {
      await Task.Delay(5000);

      //return Guid.NewGuid().ToString();

      return "Kapitoshka";
    }
  }
}
