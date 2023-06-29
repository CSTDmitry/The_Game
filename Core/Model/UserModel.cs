using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Model
{
  public class UserModel
  {
    private HttpClient HTTP;

    public UserModel()
    {
      HTTP = new() { BaseAddress = new Uri("http://localhost:8643") };
    }

    public async Task<string> Connect(string email, string password)
    {
      using StringContent body = new(JsonSerializer.Serialize
        (
          new { email, password }), Encoding.UTF8, "application/json"
        );

      var response = await HTTP.PostAsync("api/player/", body);

      if (response is { StatusCode: HttpStatusCode.OK })
      {
        return await response.Content.ReadAsStringAsync();
      }
      else
      {
        throw new Exception("UserModel : Method Connect error");
      }
    }

    public async Task<string> GetTest()
    {
      using HttpResponseMessage response = await HTTP.GetAsync("api/player/1");

      if (response is { StatusCode: HttpStatusCode.OK })
      {
        return await response.Content.ReadAsStringAsync(); ;
      }
      else
      {
        throw new Exception("HttpAccess : Method Get error :" + response);
      }
    }
  }
}
