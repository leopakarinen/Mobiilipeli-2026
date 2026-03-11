using Godot;
using System;

public partial class GameManager : Node
{
	#region Sinlgeleton
	//Get is public so gamemanager can get its hand on it from everywhere
	//Set is private so it cant be overwritten so easily
	public static GameManager Instance
	{
		get;
		private set;
	}

	public GameManager()
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
	}
	#endregion

	private int _score = 0;

	public void AddPoint()
	{
		_score += 1;

		GD.Print("Total point now: " + _score);
	}

}
