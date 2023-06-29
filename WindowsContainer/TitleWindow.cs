using Godot;
using Core;
using Core.Controller;

public partial class TitleWindow : CanvasLayer
{
	private WindowManager WManager;
  private TextEdit[] Fields;
  private Button[] Buttons;
  public override void _Ready()
	{
		WManager = GetNode<WindowManager>("/root/WindowManager");
		WManager.InitializeWindow(0);

		TestConnect();

    Fields = new TextEdit[] {
			GetNode<TextEdit>("dialog_box/login_field"),
      GetNode<TextEdit>("dialog_box/pass_field")
    };

		Buttons = new Button[] {
			GetNode<Button>("dialog_box/send")
		};

		Buttons[0].Pressed += () => ButtonPressed();
	}

  private void ButtonPressed()
	{
		TryToGetAccess();
  }

	private async void TryToGetAccess()
	{
		//var result = await WManager.GetController<UserController>().TryToConnect(Fields[0].Text, Fields[1].Text);

		var result = await WManager.GetController<UserController>().Test();


    GD.Print("Click");

		if (result != null)
		{
      //GetNode("/root/GlobalSignals").EmitSignal("InitializeWindowsContainer", 0);

      GD.Print(result);
    }
	}

	private async void TestConnect()
	{
		//var result = await WManager.GetController<UserController>().TryToConnect();

		//if (result != null)
		//{
			//GD.Print(result);
    //}
  }
}
