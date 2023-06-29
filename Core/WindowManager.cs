using System.Collections.Generic;
using Godot;
using Core.Interface;
using Core.Abstract;
using Windows.Configuration;

namespace Core
{
  public partial class WindowManager : Node
  {
    private Window Window { get; set; }
    private Dictionary<sbyte, AWindowConfiguration> WindowsConfigurationMap;

    private string[] ContainersList = {
    "res://WindowsContainer/Main.tscn"
    };

    private string[] WindowsList = {
    "res://WindowsContainer/Universe.tscn",
    "res://WindowsContainer/Overview.tscn",
    "res://WindowsContainer/Structures.tscn",
    "res://WindowsContainer/Research.tscn",
    "res://WindowsContainer/Shipyard.tscn",
    "res://WindowsContainer/Defense.tscn"
    };

    public override void _Ready()
    {
      GetNode("/root/GlobalSignals").Connect("InitializeWindowsContainer", new Callable(this, MethodName.LoadWindowContainer));
      GetNode("/root/GlobalSignals").Connect("WindowChange", new Callable(this, MethodName.LoadWindow));

      WindowsConfigurationMap = new Dictionary<sbyte, AWindowConfiguration>();
      InitializeConfigurationMap();
    }

    public void InitializeConfigurationMap()
    {
      WindowsConfigurationMap[TitleWindowConfiguration.WINDOW_ID] = new TitleWindowConfiguration();
      WindowsConfigurationMap[OverwievWindowConfiguration.WINDOW_ID] = new TitleWindowConfiguration();
    }

    private Node GetCurrentWindow()
    {
      var root = GetTree().Root;

      return root.GetChild(root.GetChildCount() - 1);
    }

    public void LoadWindowContainer(sbyte id)
    {
      GetCurrentWindow().QueueFree();
      GetTree().Root.AddChild(GD.Load<PackedScene>(ContainersList[id]).Instantiate());
    }

    public void LoadWindow(sbyte id, Node container)
    {
      InitializeWindow(id);

      if (container.GetChildren().Count > 0)
      {
        var remove = container.GetChild(0);

        container.RemoveChild(remove);
        remove.QueueFree();
      }

      container.AddChild(ResourceLoader.Load<PackedScene>(WindowsList[id]).Instantiate());
    }

    public void InitializeWindow(sbyte id)
    {
      Window = new Window(WindowsConfigurationMap[id]);
      Window.Initialize();
    }


    public T GetController<T>() where T : IObjectController
    {
      return Window.GetController<T>();
    }

    public T GetModel<T>() where T : IObjectModel
    {
      return Window.GetModel<T>();
    }
  }
}
