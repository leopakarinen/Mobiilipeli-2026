using Godot;

public partial class Fish : Area2D
{
    [Export] private float _maxSpeed = 60.0f;
    [Export] private float _minSpeed = 120.0f;
    [Export] private float _maxRandomSpeed = 200.0f;
    [Export] private float _wobbleAmount = 10f;
    [Export] private float _wobbleSpeed = 2f;


    private int _points = 1;

    private float _time = 0f;
    private float _baseY;
    private int _direction = 1;

    private AnimatedSprite2D _fish;

    private AudioStreamPlayer2D _clickSound;

    public override void _Ready()
    {
        _fish = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        _clickSound = GetNode<AudioStreamPlayer2D>("ClickSound");

        _clickSound.Bus = "SFX";

        RandomNumberGenerator rng = new RandomNumberGenerator();  // Sets a random speed for the fish. Value between _minSpeed - _maxRandomSpeed

       int score = GameManager.Instance.Score;
       float speedBonus = Mathf.Min(score * 2f, 100f);

        _maxSpeed = rng.RandfRange(_minSpeed + speedBonus, _maxRandomSpeed + speedBonus);

        SetRandomAnimation();

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

     private void SetRandomAnimation()
{
    if (_fish == null)
        return;

    RandomNumberGenerator rng = new RandomNumberGenerator();
    float roll = rng.Randf();

    string animationName;

    if (roll < 0.35f)
    {
        animationName = "Ahven";
        _points = 1;
    }
    else if (roll < 0.60f)
    {
        animationName = "Särki";
        _points = 2;
    }
    else if (roll < 0.80f)
    {
        animationName = "Hauki";
        _points = 2;
    }
    else if (roll < 0.90f)
    {
        animationName = "Lohi";
        _points = 3;
    }
    else {
        animationName = "Mamelukki";
        _points = 10;
    }

    _fish.Play(animationName);
}


	//Checks if a fish is pressed and adds a point to the player.
    public override async void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouse && mouse.Pressed)
        {
            _clickSound.Play();

            GameManager.Instance.AddPoints(_points);

            await ToSignal(_clickSound, "finished");

            QueueFree();
        }
    }
}