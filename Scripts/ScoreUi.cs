using Godot;
using System;

public partial class ScoreUi : Label
{

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		//connect to signal, changes the score
		GameManager.Instance.ScoreChanged += OnScoreChanged;
		OnScoreChanged(GameManager.Instance.Score);

    }



    public override void _ExitTree()
    {
		// Disconnect the signal
        if (GameManager.Instance != null)
		{
			GameManager.Instance.ScoreChanged -= OnScoreChanged;
		}
    }

	private void OnScoreChanged(int score)
	{
		Text = " " + score;

	}

}
