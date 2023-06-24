using System;
using System.Threading.Tasks;
using HTTP.Interface;

namespace HTTP
{
  public class UserData
  {
    public class PlayerData : IUserData
    {
      public string Id { get; set; }
      public string Name { get; set; }
    }

    public async Task<IUserData> GetPlayerData(string id)
    {
      await Task.Delay(2000);

      return new PlayerData
      {
        Id = id,
        Name = "Kapitoshka"
      };
    }
  }
}
