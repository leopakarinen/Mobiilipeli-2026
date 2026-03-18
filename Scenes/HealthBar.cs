using Godot;
using System;

public partial class HealthBar : HBoxContainer
{

	private TextureRect [] hearts;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hearts = new TextureRect[]
		{

		GetNode<TextureRect>("Heart1"),
		GetNode<TextureRect>("Heart2"),
		GetNode<TextureRect>("Heart3")
		};

		GameManager.Instance.LivesChanged += OnLivesChanged;

		UpdateHearts(GameManager.Instance.Lives);
	}

	private void OnLivesChanged(int lives)
	{
		UpdateHearts(lives);

	}

	private void UpdateHearts(int lives)
	{
		for (int i = 0; i < hearts.Length; i++ )
		{
			hearts[i].Visible = i < lives;
		}

	}


}
