using Godot;

public partial class Fish : Area2D
{
    [Export] private float _maxSpeed = 60.0f;
    [Export] private float _minSpeed = 120.0f;
    [Export] private float _maxRandomSpeed = 200.0f;
    [Export] private float _wobbleAmount = 10f;
    [Export] private float _wobbleSpeed = 2f;
    [Export] private Texture2D[] _fishTextures;

    private int _points = 1;

    private float _time = 0f;
    private float _baseY;
    private int _direction = 1;

    private Sprite2D _fish;

    public override void _Ready()
    {
        _fish = GetNode<Sprite2D>("Sprite2D");

        RandomNumberGenerator rng = new RandomNumberGenerator();
        _maxSpeed = rng.RandfRange(_minSpeed, _maxRandomSpeed);

        SetRandomTexture();

        UpdateFlip();
    }

    public void SetSpawnPosition(Vector2 position)
    {
        GlobalPosition = position;
        _baseY = position.Y;
    }

    public override void _Process(double delta)
	{
    _time += (float)delta;

    //horizontal movement
    float moveX = _direction * _maxSpeed * (float)delta;

    //vertical wobble
    float wobbleY = Mathf.Sin(_time * _wobbleSpeed) * _wobbleAmount;

    GlobalPosition = new Godot.Vector2 (GlobalPosition.X + moveX, _baseY + wobbleY);

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

     private void SetRandomTexture()
    {
        if (_fish == null || _fishTextures == null || _fishTextures.Length < 4)
            return;

        RandomNumberGenerator rng = new RandomNumberGenerator();
        float roll = rng.Randf();

        int index;

        if (roll < 0.35f)
            index = 0; //common
        else if (roll < 0.60f)
            index = 1; //common
        else if (roll < 0.80f)
            index = 2; //common
        else 
            index = 3; //uncommon

        _fish.Texture = _fishTextures[index];

        switch (index)
        {
            case 0:
                _points = 1;
                break;
            case 1:
                _points = 2;
                break;
            case 2:
                _points = 2;
                break;
            case 3:
                _points = 3;
                break;
        }
    }


	//Checks if a fish is pressed and adds a point to the player.
    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouse && mouse.Pressed)
        {
            GameManager.Instance.AddPoints(_points);
            QueueFree();
        }
    }
}