using Godot;

public partial class FishSpawner : Node2D
{
    [Export] private PackedScene fish_scn;
    [Export] private Marker2D[] spawn_points;
    [Export] private float minSpawnTime = 1f;
    [Export] private float maxSpawnTime = 4f;

    private float time_until_spawn = 0f;
    private float nextSpawnTime = 0f;
    private RandomNumberGenerator rng = new RandomNumberGenerator();

    public override void _Ready()
    {
        RandomizeSpawnTime();
    }

    public override void _Process(double delta)
    {
        time_until_spawn += (float)delta;

        if (time_until_spawn >= nextSpawnTime)
        {
            Spawn();
            time_until_spawn = 0f;
            RandomizeSpawnTime();
        }
    }

    private void Spawn()
    {
        if (fish_scn == null || spawn_points.Length == 0)
            return;

        int index = rng.RandiRange(0, spawn_points.Length - 1);
        Marker2D spawnPoint = spawn_points[index];

        Fish fish = fish_scn.Instantiate<Fish>();
        AddChild(fish);

        fish.GlobalPosition = spawnPoint.GlobalPosition;

        int direction = spawnPoint.Name.ToString().Contains("Left") ? 1 : -1;
        fish.SetDirection(direction);
    }

    private void RandomizeSpawnTime()
    {
        nextSpawnTime = rng.RandfRange(minSpawnTime, maxSpawnTime);
    }
}