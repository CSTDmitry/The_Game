using Godot;
using System;
using HTTP.Interface;
using HTTP;
using System.Threading.Tasks;
using Network.HTTP;

public partial class HttpDataAccess : Node
{
  private string Id { get; set; }
  private string User { get; set; }
  private string Password { get; set; }
  private string Token { get; set; }

  private HttpAccess HTTP;

  public override void _Ready()
  {
    HTTP = new HttpAccess();
  }

  public async Task<string> TryToGetAccess(string email, string password)
  {
    await Task.Delay(5000);

    return Guid.NewGuid().ToString();
  }

  public string GetUserName()
  {
    return "Kapitoshka";
  }

  private async void Test()
  {
    var result = await HTTP.Get();

      GD.Print(result);
  }
}
