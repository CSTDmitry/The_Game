using Godot;
using System;

public partial class MetallMine : StaticBody2D
{
	[Signal]
	public delegate void ClickEventHandler(int id);

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

  public void OnInputEvent(Node vPort, InputEvent @event, int shape_idx)
  {
    if (@event is InputEventMouseButton mEvent)
    {
      if (mEvent.Pressed && mEvent.ButtonIndex == MouseButton.Left)
      {
        EmitSignal(SignalName.Click, 0);
      }
    }
  }
}
