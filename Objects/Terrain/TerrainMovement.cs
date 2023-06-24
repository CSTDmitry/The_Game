using Godot;
using System;

public partial class TerrainMovement : Node2D
{
	private int Speed { get; set; } = 400;
  private Camera2D Terrain { get; set; }
  private Tween Tween;
  public override void _Ready()
	{
    Terrain = GetNode<Camera2D>("Camera2D");
    //Terrain.Position = new Vector2(968, 544);
  }

  

	public override void _Process(double delta)
	{
    
  }
}
