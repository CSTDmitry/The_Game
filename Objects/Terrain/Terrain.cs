using Godot;
using Godot.Collections;


public partial class Terrain : Node
{
  private Camera2D Camera { get; set; }
  private GlobalSignals Signals { get; set; }

  private Tween Tween;
  private bool TFinished = true;

  private StaticBody2D StaticBody;
  

  public override void _Ready()
  {
    Camera = GetNode<Camera2D>("Camera2D");
    Signals = GetNode<GlobalSignals>("/root/GlobalSignals");
  }

  private void TweenFinished()
  {
    TFinished = true;
  }

  public override void _UnhandledInput(InputEvent @event)
  {
    if (@event is InputEventMouseButton btn)
    {
      if (btn.Pressed && btn.ButtonIndex == MouseButton.WheelUp)
      {
        if (TFinished && Camera.Position.Y != 540)
        {
          Tween = CreateTween();
          Tween.Connect("finished", new Callable(this, "TweenFinished"));
          Tween.TweenProperty(Camera, "position", new Vector2(960, 540), 0.5);
          TFinished = false;
        }
      }
      if (btn.Pressed && btn.ButtonIndex == MouseButton.WheelDown)
      {
        if (TFinished && Camera.Position.Y != 1490)
        {
          Tween = CreateTween();
          Tween.Connect("finished", new Callable(this, "TweenFinished"));
          Tween.TweenProperty(Camera, "position", new Vector2(960, 1490), 0.5);
          TFinished = false;
        }
      }
    }
  }

  private void OnBuildingClick(int id)
  {
    Signals.EmitSignal("StructureItemCall", id);
  }
}
