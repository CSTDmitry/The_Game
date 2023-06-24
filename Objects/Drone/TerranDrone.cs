using Godot;

public partial class TerranDrone : Node2D
{
	private AnimationPlayer AnimationPlayer;


	public override void _Ready()
	{
    AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}


  public override void _Process(double delta)
  {
    AnimationPlayer.Play("terran_drone_idle");
  }

  public void OnInputEvent(Node vP, InputEvent @event, int shape_idx)
  {
    if (@event is InputEventMouseButton mouseEvent)
    {
      if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
      {
        GetNode<GlobalSignals>("/root/GSignals").EmitSignal("DroneClick");
      }
    }
  }
}
