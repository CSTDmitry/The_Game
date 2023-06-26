using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTP
{
  public partial class HttpAccess
  {
    private HttpClient Http;

    public HttpAccess()
    {
      Http = new() { BaseAddress = new Uri("http://localhost:8643") };
    }

    public async Task<HttpResponseMessage> SendPost(string email, string password)
    {
      using StringContent jsonContent = new (JsonSerializer.Serialize
        (
          new { email, password }), Encoding.UTF8, "application/json"
        );

      using HttpResponseMessage response = await Http.PostAsync(
          "todos", jsonContent);

      return response;
    }

    public async Task<string> Get()
    {
      using HttpResponseMessage response = await Http.GetAsync("api/player/1");

      var result = await response.Content.ReadAsStringAsync();

      if (response is { StatusCode: HttpStatusCode.OK })
      {
        return result;
      }
      else
      {
        return "No";
      }
    }
  }
}
