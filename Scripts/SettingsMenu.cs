using Godot;
using System;

public partial class SettingsMenu : CanvasLayer
{
    // Signal, jota MainMenu kuuntelee
    [Signal] public delegate void LanguageChangedEventHandler(string lang);

    [Export] private TextureButton _CloseButton;      // sulje menu
    [Export] private TextureButton _FinnishButton;    // suomi
    [Export] private TextureButton _EnglishButton;    // englanti

    public override void _Ready()
    {
        // Liitetään napit
        _CloseButton.Pressed += OnClosePressed;
        _FinnishButton.Pressed += OnFinnishPressed;
        _EnglishButton.Pressed += OnEnglishPressed;

        // Piilotetaan SettingsMenu aluksi
        Visible = false;
    }

    private void OnClosePressed()
    {
        Visible = false;
    }

    private void OnFinnishPressed()
    {
        // Lähetä signal MainMenu:lle
        EmitSignal("LanguageChanged", "fi");
        Visible = false; // sulje menu
    }

    private void OnEnglishPressed()
    {
        // Lähetä signal MainMenu:lle
        EmitSignal("LanguageChanged", "en");
        Visible = false; // sulje menu
    }
}