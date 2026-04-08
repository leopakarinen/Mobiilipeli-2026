using Godot;

public partial class FishSpawner : Node2D
{
    [Export] private PackedScene fish_scn;
    [Export] private Marker2D[] spawn_points;
    [Export] private float minSpawnTime = 0.7f;
    [Export] private float maxSpawnTime = 2f;
    [Export] private float minAllowedSpawnTime = 0.3f;
    [Export] private float maxAllowedSpawnTime = 1.5f;

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

        fish.SetSpawnPosition(spawnPoint.GlobalPosition);

        int direction = spawnPoint.Name.ToString().Contains("Left") ? 1 : -1;
        fish.SetDirection(direction);
    }

    private void RandomizeSpawnTime()
    {
        int score = GameManager.Instance.Score;

        float difficulty = score * 0.05f;

        float currentMin = Mathf.Max(minAllowedSpawnTime, minSpawnTime - difficulty);
        float currentMax = Mathf.Max(maxAllowedSpawnTime, maxSpawnTime - difficulty);

        nextSpawnTime = rng.RandfRange(minSpawnTime, maxSpawnTime);
    }
}