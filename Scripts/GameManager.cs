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
	public void AddPoint()
	{
		_score += 1;

		GD.Print("Total point now: " + _score);
	}
	public void LoseLife()   // new metod that tells if player loses a life
	{
		_lives -= 1;

		EmitSignal(SignalName.LivesChanged, _lives);

		GD.Print("Lives left: " + _lives);

		if (_lives <= 0)
		{
			GameOver();
		}
	}

	private void GameOver()  // when player has lost all lives game ends
	{
		GD.Print("Game Over");

		ResetLives();

		CallDeferred(nameof(ReloadScene));
	}

	private void ReloadScene()
	{
		GetTree().ReloadCurrentScene();
	}

	public void ResetLives()
	{
		_lives = 3;
		_score = 0;

		EmitSignal(SignalName.LivesChanged, _lives);
	}
}
