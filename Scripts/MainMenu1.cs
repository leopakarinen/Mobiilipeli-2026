using Godot;
using System;

public partial class MainMenu1 : Control
{
    public override void _Ready()
    {
        // Searches buttons
        TextureButton playButton = GetNode<TextureButton>("VBoxContainer/PlayButton");
        Button settingsButton = GetNode<Button>("VBoxContainer/SettingsButton");
        Button exitButton = GetNode<Button>("VBoxContainer/ExitButton");

        // Signals
        playButton.Pressed += OnPlayPressed;
        settingsButton.Pressed += OnSettingsPressed;
        exitButton.Pressed += OnExitPressed;
    }

    private void OnPlayPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Main.tscn"); // Changes to ingame scene
    }

	private void OnSettingsPressed()
{
    GD.Print("Settings painettu (ei vielä tehty)");
}

    private void OnExitPressed()
    {
        GetTree().Quit();
    }
}