using Godot;
using System;

public partial class SettingsMenu : CanvasLayer
{
    [Export] private TextureButton _CloseButton; // liitä Inspectorissa CloseButton tähän
    [Export] private TextureButton _FinnishButton;
    [Export] private TextureButton _EnglishButton;


    public override void _Ready()
    {
        // Liitetään CloseButton piilottamaan koko SettingsMenu
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
        Visible = false;
    }
    private void OnEnglishPressed()
    {
        Visible = false;
    }
}