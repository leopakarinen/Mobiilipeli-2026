using Godot;
using System;

public partial class Fish : Area2D
{

	[Export] private float _maxSpeed = 60.0f;

	//determines whether the vehicle moves in a fixed direction(false) or between two points(true)
	[Export] private bool _moveBetweenPoints = false;
	//set in editor cordinates
	[Export] private Vector2 _pointA;
	[Export] private Vector2 _pointB;

	private Vector2 _currentTarget;
	// Called when the node enters the scene tree for the first time.
	//If we choose to move between points the character is moved to point A
	// the target is point b
	public override void _Ready()
	{

		if(_moveBetweenPoints)
		{
			GlobalPosition = _pointA; //start point
			_currentTarget = _pointB; // initial target
		}
	}
	/// <summary>
	/// Detects tap / mouse click on the fish
	/// </summary>

    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouse && mouse.Pressed)
		{
			GD.Print("fish clicked");
			QueueFree();
		}
		if (@event is InputEventScreenTouch touch && touch.Pressed)
		{
			GD.Print("fish clicked");
			QueueFree();
		}
    }
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	/// <summary>
	/// Moves the vehicle to a direction defined by attribute "direction" with speed _maxSpeed
	/// </summary>
	/// <param name="direction">The direction of the movement. -1 = left 1 = right</param>
	/// <param name="deltatime">the time since the previous frame</param>

	public void Move(int direction, float deltatime)
	{
		if (direction < -1 || direction > 1)
		{
			//Direction is not valid. Nothing to do.
			return;
		}

		Vector2 movement = new Vector2(direction, 0) * _maxSpeed * deltatime;
		Translate(movement);
	}
	/// <summary>
	/// Moves vehicle between two points at a fixed pace
	/// Automatically reverses direction when reaching target
	/// </summary>
	/// <param name="MoveBetweenPoins"></param>
	public void MoveBetweenPoints(float deltatime)
	{
		Vector2 direction = (_currentTarget - GlobalPosition).Normalized();
		Vector2 movement = direction * _maxSpeed * deltatime;
		Translate(movement);


		//chech if the target is reached
		if(GlobalPosition.DistanceTo(_currentTarget) < _maxSpeed * deltatime)
		{
			//swhich target
			if (GlobalPosition == _currentTarget)
            {
                if (_currentTarget == _pointB)
                {
                    QueueFree();
                    return;
                }
            }


		}
	}
	/// <summary>
	/// Returns whether this vehicle is set to move between points
	/// used by VehicleRunner to determine which movement method to use
	/// </summary>
	/// <returns>IsMovingBetweenPoints</returns>
	public bool IsMovingBetweenPoints()
	{
		return _moveBetweenPoints;
	}

}
