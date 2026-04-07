using Godot;
using System;

public partial class PauseButton : TextureButton
{
    [Export] private Pausemenu _PauseMenu;
	[Export] private TextureButton _PauseButton;

    public override void _Ready()
    {
        Pressed += OnPauseButtonPressed;
    }

    private void OnPauseButtonPressed()
    {
        _PauseMenu.OpenPauseMenu(); // 🔥 OIKEA tapa
    }
}

