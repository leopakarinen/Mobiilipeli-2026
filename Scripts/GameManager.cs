using Godot;
using System;

public partial class GameManager : Node
{
	#region Singleton
	//Get is public so gamemanager can get its hand on it from everywhere
	//Set is private so it cant be overwritten so easily
	public static GameManager Instance
	{
		get;
		private set;
	}

	public int Score {

		get {return _score; }
	}

	public override void _Ready()
	{
		//Singleton promises that only one alien is could be made at a time
		if(Instance == null)
		{
			// if there is no alien, then be this the alien
			Instance = this;
		}
		else if (Instance != this)
		{
			//alien has been made already, destroy alien which have been made just now
			QueueFree();
			return;
		}

		ResetLives();
	}
	#endregion

	private int _score = 0;
	private int _lives = 3;

	public int Lives
	{
    	get { return _lives; }
	}

	[Signal] public delegate void LivesChangedEventHandler(int lives);
	[Signal] public delegate void ScoreChangedEventHandler(int score);
	public void AddPoints(int amount)
	{
		_score += amount;

		EmitSignal(SignalName.ScoreChanged, _score);

		GD.Print("Gained " + amount +  " points. Total score now: " + _score);
	}
	public void LoseLife()   // new metod that tells if player loses a life
	{
		_lives -= 1;

		EmitSignal(SignalName.LivesChanged, _lives);


		GD.Print("Lives left: " + _lives);

		if (_lives <= 0)
		{
			CallDeferred(nameof(GameOverScreen));
		}
	}


	public void ResetLives()
	{
		_lives = 3;
		_score = 0;

		EmitSignal(SignalName.LivesChanged, _lives);
		EmitSignal(SignalName.ScoreChanged, _score);
	}

	private void GameOverScreen()
	{
		GetTree().ChangeSceneToFile("res://Scenes/game_over.tscn");

	}
}
