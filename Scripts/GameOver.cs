using Godot;
using System;

public partial class GameOver : Control
{
    [Export] private TextureButton _RetryButton;
    [Export] private TextureButton _QuitButton;
    [Export] private TextureButton _MenuButton;

    public override void _Ready()
    {
        _RetryButton.Pressed += OnRetryPressed;
        _QuitButton.Pressed += OnQuitPressed;
        _MenuButton.Pressed += OnMenuPressed;
    }

    private void OnRetryPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Main.tscn");
        // restarts game
    }

private void OnMenuPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
        // goes to main menu
    }

    private void OnQuitPressed()
    {
        GetTree().Quit();
        // closes game
    }
}