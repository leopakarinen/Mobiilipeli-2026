using Godot;
using System;

public partial class Hazard : Area2D
{
    [Export] private float _speed = 100.0f;
    private bool hit = false;
    private Sprite2D _sprite;
    [Export] private Texture2D[] _hazardTextures;
    public override void _Ready()
    {
        _sprite = GetNode<Sprite2D>("Sprite2D");
        SetRandomTexture();
        AreaEntered += OnAreaEntered;
    }

    private void SetRandomTexture()
    {
        if (_sprite == null || _hazardTextures == null || _hazardTextures.Length == 0)
        return;

        RandomNumberGenerator rng = new RandomNumberGenerator();
        int index = rng.RandiRange(0, _hazardTextures.Length - 1);
        _sprite.Texture = _hazardTextures[index];
    }

    public override void _Process(double delta)
    {
        GlobalPosition += new  Vector2(0, _speed * (float)delta);
    }
    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            GameManager.Instance.LoseLife();  // Vähennetään pelaajan elämää
            QueueFree();                      // Poistetaan saapas pelistä
        }
    }

    public void OnAreaEntered (Node Area)
    {
        if (hit)
            return;
        if(Area.IsInGroup("Fish"))
        {
            hit = true;

            GameManager.Instance.LoseLife();
            GD.Print("Hit a fish");
            Area.CallDeferred("queue_free");
            CallDeferred("queue_free");
        }
    }
}