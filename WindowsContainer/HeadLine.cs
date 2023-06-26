using Godot;
using Godot.Collections;
using Core;

public partial class HeadLine : Node
{
  private HTTPManager Http;
  private WindowManager WManager;
  private Node Container;
  private GlobalSignals Signals;

	private Array<Node> Labels;

  private WindowManager WindowManager;


	public override void _Ready()
	{
    Container = GetNode<Node>("../Container");
    Signals = GetNode<GlobalSignals>("/root/GlobalSignals");
    Labels = GetTree().GetNodesInGroup("user_labels");

    WManager = GetNode<WindowManager>("/root/WindowManager");


    //GD.Print(WindowManager.GetController<TestController>().TestCall());
    //SetUserData();

    Signals.EmitSignal("WindowChange", 1, Container);
  }

  private void SetUserData()
  {
    ((Label)Labels[0]).Text = "";
  }

  public void OnLinkButtonPressed(int id)
  {
    Signals.EmitSignal("WindowChange", id, Container);
  }
}
