using Godot;
using System;

public partial class SettingsMenu : CanvasLayer
{
    [Export] private Button _CloseButton; // liitä Inspectorissa CloseButton tähän

    public override void _Ready()
    {
        // Liitetään CloseButton piilottamaan koko SettingsMenu
        _CloseButton.Pressed += OnClosePressed;

        // Piilotetaan SettingsMenu aluksi
        Visible = false;
    }

    private void OnClosePressed()
    {
        Visible = false;
    }
}