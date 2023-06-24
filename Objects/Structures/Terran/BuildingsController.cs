using Godot;
using Godot.Collections;

public partial class BuildingsController : Node2D
{

  public override void _Ready()
	{
    
  }

  public override void _Process(double delta)
	{
    
	}

  private void OnBuildingClick(int id)
  {
    GD.Print("Building clicked id: " + id);
  }
}
