using Godot;
using System;

public partial class MainMenu1 : Control
{
    [Export] private TextureButton _PlayButton;
    [Export] private TextureButton _ExitButton;
    [Export] private TextureButton _SettingsButton;
    [Export] private SettingsMenu _SettingsMenu; // viittaus erilliseen CanvasLayer-sceneen
    [Export] private Tutorialscreen _TutorialScreen;

    public override void _Ready()
    {
        // Liitä napit
        _PlayButton.Pressed += OnPlayButtonPressed;
        _ExitButton.Pressed += OnQuitPressed;
        _SettingsButton.Pressed += OnOptionsPressed;
        _TutorialScreen.TutorialClosed += OnTutorialClosed;

        // Liitä SettingsMenu:n signal
        _SettingsMenu.LanguageChanged += OnLanguageChanged;

        // Piilotetaan SettingsMenu aluksi
        _SettingsMenu.Visible = false;

        // Päivitä napit Global-kielen mukaan
        UpdateImages();
    }

    // Päivittää kaikkien nappien kuvat Global.CurrentLang:n mukaan
    private void UpdateImages()
    {
        string lang = Global.CurrentLang; // 🔥 käytetään Globalia

        _PlayButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/play_{lang}.png");
        _ExitButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/exit_{lang}.png");
        _SettingsButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/settings_{lang}.png");
    }

    // SettingsMenu ilmoittaa signalilla
    private void OnLanguageChanged(string lang)
    {
        GD.Print("Kieli vaihdettiin: ", lang);
        Global.CurrentLang = lang; // 🔥 tallennetaan Globaliin
        UpdateImages();            // päivitä napit heti
    }

    private void OnPlayButtonPressed()
    {
        _TutorialScreen.Visible = true;
    }

    private void OnTutorialClosed()
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