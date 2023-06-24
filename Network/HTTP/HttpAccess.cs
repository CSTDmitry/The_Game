using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Network.HTTP
{
  public partial class HttpAccess
  {
    private HttpClient Http;

    public HttpAccess()
    {
      Http = new() { BaseAddress = new Uri("http://localhost:8643") };
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
