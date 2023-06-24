using Godot;
using System;

public partial class StructureWindows : CanvasLayer
{
	private GlobalSignals Signals { get; set; }
	public override void _Ready()
	{
		base._Ready();

		GetNode<GlobalSignals>("/root/GSignals").Connect("StructureItemCall", new Callable(this, MethodName.ShowWindow));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void ShowWindow(int id)
	{
		Visible = true;

		GD.Print("Load structure info " + id);
	}

	public void OnClosePressed()
	{
    Visible = false;

    /*if (@event is InputEventMouseButton mEvent)
    {
      if (mEvent.Pressed && mEvent.ButtonIndex == MouseButton.Left)
      {
        
      }
    }*/
	}
}
