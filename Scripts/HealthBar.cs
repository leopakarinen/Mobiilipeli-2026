using Godot;
using System;
using System.Threading.Tasks;

public partial class HealthBar : HBoxContainer
{

	private AnimatedSprite2D [] hearts;
	private int previousLives;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hearts = new AnimatedSprite2D[]
		{

		GetNode<AnimatedSprite2D>("Heart1"),
		GetNode<AnimatedSprite2D>("Heart2"),
		GetNode<AnimatedSprite2D>("Heart3")
		};

		GameManager.Instance.LivesChanged += OnLivesChanged;

		previousLives = GameManager.Instance.Lives;

		UpdateHearts(previousLives);
	}

    public override void _ExitTree()
    {
        if (GameManager.Instance != null)
		{
			GameManager.Instance.LivesChanged -= OnLivesChanged;
		}
    }
	private async void OnLivesChanged(int lives)
	{
		if (lives < previousLives)
		{
			for (int i = lives; i < previousLives; i++)
			{
				await PlayLoseAnimation(i);
			}
		}
		UpdateHearts(lives);
		previousLives = lives;

	}

	private async Task PlayLoseAnimation(int index)
	{
		hearts[index].Play("Lose");
        await ToSignal(hearts[index], AnimatedSprite2D.SignalName.AnimationFinished);

	}

	private void UpdateHearts(int lives)
	{
		for (int i = 0; i < hearts.Length; i++ )
		{
			if (i < lives)
			{
			hearts[i].Visible = true;
			hearts[i].Play("Idle");
			}
			else
			{
				hearts[i].Visible = true;
			}
		}

	}
	  public void ResetHearts()
    {
        foreach (var heart in hearts)
        {
            heart.Visible = true;
            heart.Play("full"); // red heart
        }
        previousLives = hearts.Length;
    }


}
