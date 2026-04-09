using Godot;
using System;

public partial class GameOverScoreLabel : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Text = "Score:\n" + GameManager.Instance.Score;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.

}
