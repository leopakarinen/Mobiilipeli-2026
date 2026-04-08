using Godot;
using System;

public partial class MainMenu1 : Control
{
    [Export] private TextureButton _PlayButton;
    [Export] private TextureButton _ExitButton;
    [Export] private TextureButton _SettingsButton;
    [Export] private SettingsMenu _SettingsMenu; //  CanvasLayer-scene
    [Export] private Tutorialscreen _TutorialScreen;
    [Export] private TextureButton _VolumeButton;

    private bool _isMuted = false;

    public override void _Ready()
    {
        // adds buttons
        _PlayButton.Pressed += OnPlayButtonPressed;
        _ExitButton.Pressed += OnQuitPressed;
        _SettingsButton.Pressed += OnOptionsPressed;
        _TutorialScreen.TutorialClosed += OnTutorialClosed;
        _VolumeButton.Pressed += OnVolumePressed;

        // settings menu signal
        _SettingsMenu.LanguageChanged += OnLanguageChanged;

        // hides menu
        _SettingsMenu.Visible = false;

        // Updates buttons from Global
        UpdateImages();

        UpdateVolumeIcon(); // updates volume button icon
    }

    // Updates photo icons from global
    private void UpdateImages()
    {
        string lang = Global.CurrentLang;

        _PlayButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/play_{lang}.png");
        _ExitButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/exit_{lang}.png");
        _SettingsButton.TextureNormal = GD.Load<Texture2D>($"res://Assets/settings_{lang}.png");
    }

    // SettingsMenu signal
    private void OnLanguageChanged(string lang)
    {
        GD.Print("Kieli vaihdettiin: ", lang);
        Global.CurrentLang = lang; //  saves to Globaliin
        UpdateImages();            // updates buttons right away
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
        _SettingsMenu.Visible = !_SettingsMenu.Visible; // toggle visibility
    }
    private void OnVolumePressed()
{
    _isMuted = !_isMuted;

    int busIndex = AudioServer.GetBusIndex("Master");
    AudioServer.SetBusMute(busIndex, _isMuted);

    UpdateVolumeIcon();
}

private void UpdateVolumeIcon() // changes volume button icons
{
    if (_isMuted)
    {
        _VolumeButton.TextureNormal = GD.Load<Texture2D>("res://Assets/volume_off.png");
    }
    else
    {
        _VolumeButton.TextureNormal = GD.Load<Texture2D>("res://Assets/volume_on.png");
    }
}

}