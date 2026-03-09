using Godot;
using System;

public partial class FishSpawner : Node2D {

	[Export] PackedScene fish_scn;
	[Export] Marker2D[] spawn_points;
	[Export] float eps = 7f;

	float spawn_rate;

	float time_until_spawn = 0;

	public override void _Ready() {
		spawn_rate = eps;
	}

	public override void _Process(double delta) {

		if (time_until_spawn > spawn_rate) {
			Spawn();
			time_until_spawn = 0;
		} else {
			time_until_spawn += (float)delta;
		}
	}

	private void Spawn() {
		RandomNumberGenerator rng = new RandomNumberGenerator();
		Vector2 location = spawn_points[rng.Randi() % spawn_points.Length].GlobalPosition;
		Fishmover fish = (Fishmover)fish_scn.Instantiate();
		fish.GlobalPosition = location;
		GetTree().Root.AddChild(fish);
	}

}
