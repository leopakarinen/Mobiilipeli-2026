using Godot;
using System;

public partial class GameOver : Control
{
    [Export] private Button _PlayAgainButton;
    [Export] private Button _QuitButton;
    [Export] private Button _MainmenuButton;

    public override void _Ready()
    {
        _PlayAgainButton.Pressed += OnPlayAgainPressed;
        _QuitButton.Pressed += OnQuitPressed;
        _MainmenuButton.Pressed += OnMainmenuButtonPressed;
    }

    private void OnPlayAgainPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Main.tscn");
        // restarts game
    }

private void OnMainmenuButtonPressed()
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