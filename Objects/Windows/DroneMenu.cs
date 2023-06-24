using Godot;
using Godot.Collections;
using System;

public partial class DroneMenu : CanvasLayer
{
	private GlobalSignals Signals;
	public override void _Ready()
	{
		Signals = GetNode<GlobalSignals>("/root/GSignals");
    Signals.Connect("DroneClick", new Callable(this, MethodName.ShowWindow));
	}

	private void ItemClicked()
	{
	}

	private void OnButtonPressed(int id)
	{
		Signals.EmitSignal("StructureItemCall", id);
	}


  private void ShowWindow()
	{
		Visible = true;
	}

	public void OnCloseGuiInput(InputEvent @event)
	{
    if (@event is InputEventMouseButton mouseEvent)
    {
      if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
      {
        Visible = false;
      }
    }
  }
}
