using Godot;
using System;

public partial class MainmenuSuomi : Control
{
    [Export] private TextureButton _PlayButton;
    [Export] private TextureButton _ExitButton;
    [Export] private TextureButton _SettingsButton;
    [Export] private CanvasLayer _SettingsMenu;
    [Export] private TextureButton _SuomiButton;
    [Export] private TextureButton _EnglishButton;

    private string currentLang = "fi";

    public override void _Ready()
    {
        // Main menu napit
        _PlayButton.Pressed += OnPlayButtonPressed;
        _ExitButton.Pressed += OnQuitPressed;
        _SettingsButton.Pressed += OnOptionsPressed;

        // Settings menu napit
        _SuomiButton.Pressed += OnSuomiButtonPressed;
        _EnglishButton.Pressed += OnEnglishButtonPressed;

        _SettingsMenu.Visible = false;

        // Päivitä napit alkuun
        UpdateImages(currentLang);
    }

    private void OnPlayButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Main.tscn");
    }

    private void OnQuitPressed()
    {
        GetTree().Quit();
    }

    private void OnOptionsPressed()
    {
        _SettingsMenu.Visible = true;
    }

    private void OnSuomiButtonPressed()
    {
        currentLang = "fi";
        UpdateImages(currentLang);
    }

    private void OnEnglishButtonPressed()
    {
        currentLang = "en";
        UpdateImages(currentLang);
    }

    private void UpdateImages(string lang)
    {
        // Main menu napit
        _PlayButton.TextureNormal = GD.Load<Texture2D>($"res://ui/play_fi.png");
        _SettingsButton.TextureNormal = GD.Load<Texture2D>($"res://ui/settings_fi.png");
        _ExitButton.TextureNormal = GD.Load<Texture2D>($"res://ui/exit_fi.png");

        // Settings menu napit
        _SuomiButton.TextureNormal = GD.Load<Texture2D>($"res://ui/suomi_fi.png");
        _EnglishButton.TextureNormal = GD.Load<Texture2D>($"res://ui/english_en.png");
    }
}