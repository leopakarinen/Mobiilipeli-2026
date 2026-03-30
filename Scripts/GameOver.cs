using Godot;
using System;

public partial class GameOver : Control
{
    [Export] private Button _PlayAgainButton;
    [Export] private Button _QuitButton;

    public override void _Ready()
    {
        _PlayAgainButton.Pressed += OnPlayAgainPressed;
        _QuitButton.Pressed += OnQuitPressed;
    }

    private void OnPlayAgainPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Main.tscn");
        // restarts game
    }

    private void OnQuitPressed()
    {
        GetTree().Quit();
        // closes game
    }
}