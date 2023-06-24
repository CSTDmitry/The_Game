using Godot;

public partial class GlobalSignals : Node
{
	//Windows signals
	[Signal] public delegate void InitializeWindowsContainerEventHandler(sbyte id);
	[Signal] public delegate void WindowChangeEventHandler(sbyte id, Node container);

	//Structures signals
	[Signal] public delegate void StructureClickEventHandler(sbyte id);

	//Drone signals
	[Signal] public delegate void DroneClickEventHandler();
	[Signal] public delegate void StructureItemCallEventHandler(sbyte id);
}
