using Godot;
using System;
using Godot.Collections;

public partial class Fishmover : Node
{
	//Direction of the movement. -1 = left, 1 = right.
	[Export] private int _direction = 1;

	/// <summary>
	/// possible to drag vehicle nodes into the list in editor
	/// </summary>
	[Export] private Array<Fish> _fishes = null;

	public override void _Process(double delta)
	{
		foreach(Fish fish in _fishes)
		{
			if(fish==null) continue;
			//decide movement type
			if (fish.IsMovingBetweenPoints())
			{
				fish.MoveBetweenPoints((float)delta);
			}
			else
			{
			fish.Move(_direction, (float)delta);
			}
		}
	}
}
