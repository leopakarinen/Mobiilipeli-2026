using Godot;
using System;

public partial class MainMenu1 : Control
{
    [Export] private TextureButton _PlayButton;
    [Export] private TextureButton _ExitButton;
    [Export] private TextureButton _SettingsButton;
    [Export] private SettingsMenu _SettingsMenu; // viittaus erilliseen CanvasLayer-sceneen

    private string currentLang = "fi"; // oletuskieli

    public override void _Ready()
    {
        // Main Menu napit
        _PlayButton.Pressed += OnPlayButtonPressed;
        _ExitButton.Pressed += OnQuitPressed;
        _SettingsButton.Pressed += OnOptionsPressed;

        // Liitetään SettingsMenu:n signal
        _SettingsMenu.LanguageChanged += OnLanguageChanged;

        // Piilotetaan SettingsMenu aluksi
        _SettingsMenu.Visible = false;

        // Päivitä napit oletuskielelle
        currentLang = "fi";  // oletus suomi
        UpdateImages(currentLang);
    }

    // Päivittää kaikkien nappien kuvat valitun kielen mukaan
    private void UpdateImages(string lang)
    {
        _PlayButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/play_{lang}.png");
        _ExitButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/exit_{lang}.png");
        _SettingsButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/settings_{lang}.png");
    }

    // SettingsMenu ilmoittaa signalilla
    private void OnLanguageChanged(string lang)
    {   GD.Print("Kieli vaihdettiin: ", lang);
        currentLang = lang;
        UpdateImages(lang);
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
        _SettingsMenu.Visible = !_SettingsMenu.Visible; // toggle näkyvyys
    }
}