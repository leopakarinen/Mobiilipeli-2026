using Godot;

public partial class Fish : Area2D
{
    [Export] private float _maxSpeed = 60.0f;
    private int _direction = 1;

    private Sprite2D _fish;

    public override void _Ready()
    {
        _fish = GetNode<Sprite2D>("Sprite2D");
        UpdateFlip();
    }

    public override void _Process(double delta)
	{
    Vector2 movement = new Vector2(_direction, 0) * _maxSpeed * (float)delta;
    GlobalPosition += movement;

    Vector2 screenSize = GetViewportRect().Size;

    if (GlobalPosition.X < -80 || GlobalPosition.X > screenSize.X + 80) //Checks where a fish is destroyed.
    {
        GD.Print("A fish escaped!");
        QueueFree(); // removes the fish
    }
	}

    public void SetDirection(int direction)
    {
        _direction = direction;
        UpdateFlip();
    }

	//Checks which direction the fish is going and based on that flips the sprite.
    private void UpdateFlip()
    {
        if (_fish == null) return;

        if (_direction == 1)
            _fish.FlipH = true;
        else
            _fish.FlipH = false;
    }


	//Checks if a fish is pressed and adds a point to the player.
    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouse && mouse.Pressed)
        {
            GameManager.Instance.AddPoint();
            QueueFree();
        }
    }
}