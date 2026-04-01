using Godot;
using System;

public partial class Tutorialscreen: CanvasLayer
{
 [Signal] public delegate void TutorialClosedEventHandler();
    [Export] private TextureButton _CloseButton;      // close menu

    public override void _Ready()
    {
        // Liitetään napit
        _CloseButton.Pressed += OnClosePressed;


        // Piilotetaan Menu aluksi
        Visible = false;
    }

    private void OnClosePressed()
    {
        Visible = false;

        EmitSignal(SignalName.TutorialClosed);
    }
}