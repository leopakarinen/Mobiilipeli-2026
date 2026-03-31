using Godot;
using System;

public partial class HazardSpawner : Node2D
{
	[Export] private PackedScene hazardScene;
	[Export] private float spawnInterval = 5f; // time between spawns
	private float timer = 0f; // checks if spawnInterval has been reached
	private RandomNumberGenerator rng = new RandomNumberGenerator();

    public override void _Process(double delta)
    {
        timer += (float)delta;

		if (timer >= spawnInterval)
		{
			SpawnHazard();
			timer = 0f;
		}
    }

	private void SpawnHazard()
	{
		if(hazardScene == null)
		return;

		Node2D hazard = hazardScene.Instantiate<Node2D>();
		AddChild(hazard);

		Vector2 screenSize = GetViewportRect().Size;
		float randomX = rng.RandfRange(250, 900);

		hazard.GlobalPosition = new Vector2(randomX, -100);
	}


}
