using Godot;
using System;

public partial class GameOver : Control
{
    [Export] private TextureButton _RetryButton;
    [Export] private TextureButton _QuitButton;
    [Export] private TextureButton _MenuButton;

    public override void _Ready()
    {
        // Liitä napit
        _RetryButton.Pressed += OnRetryPressed;
        _QuitButton.Pressed += OnQuitPressed;
        _MenuButton.Pressed += OnMenuPressed;

        // Päivitä napit kielivalinnan mukaan
        UpdateImages();
    }

    // Päivittää napit suoraan Global.CurrentLang mukaan
    private void UpdateImages()
    {
        string lang = Global.CurrentLang; // haetaan kieli
        _RetryButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/retry_{lang}.png");
        _QuitButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/quit_{lang}.png");
        _MenuButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/menu_{lang}.png");
    }

    private void OnRetryPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Main.tscn");
    }

    private void OnMenuPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
    }

    private void OnQuitPressed()
    {
        GetTree().Quit();
    }
}