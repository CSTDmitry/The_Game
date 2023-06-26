using Godot;
using System;
using HTTP;
using System.Threading.Tasks;

public partial class HTTPManager : Node
{
  private string Id { get; set; }
  private string EMail { get; set; }
  private string Token { get; set; }

  private HttpAccess HTTP;

  public override void _Ready()
  {
    HTTP = new HttpAccess();
  }

  public async Task<string> TryToGetAccess(string email, string password)
  {
    var response = await HTTP.SendPost(email, password);

    var json = await response.Content.ReadAsStringAsync();

    return json;
  }

  private async void Test()
  {
    var result = await HTTP.Get();

      GD.Print(result);
  }
}
