using Godot;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTP
{
  public partial class HttpAccess : Node
  {
    private System.Net.Http.HttpClient Http;

    public override void _Ready()
    {
      Http = new() { BaseAddress = new Uri("http://localhost:8643") };
    }

    public async Task<HttpResponseMessage> SendPost(string uri, StringContent body)
    {
      return await Http.PostAsync(uri, body);
    }

    public async Task<HttpResponseMessage> SendGet(string uri)
    {
      using HttpResponseMessage response = await Http.GetAsync(uri);

      if (response is { StatusCode: HttpStatusCode.OK })
      {
        return response;
      }
      else
      {
        throw new Exception("HttpAccess : Method Get error");
      }
    }
  }
}
