using Godot;
using System;

public partial class Pausemenu : CanvasLayer
{

    [Export] private TextureButton _CloseButton;     // closes screen
	[Export] private TextureButton _MenuButton;      // changes scene to menu
	[Export] private TextureButton _PlayButton;

    public override void _Ready()
    {
        // Liitetään napit
        _CloseButton.Pressed += OnClosePressed;
		_MenuButton.Pressed += OnMenuPressed;
		_PlayButton.Pressed += OnPlayPressed;

        // Piilotetaan SettingsMenu aluksi
        Visible = false;
    }

    private void OnClosePressed()
    {
        Visible = false;
    }

	private void OnMenuPressed ()
	{
		GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
	}

	 private void OnPlayPressed()
    {
        Visible = false;
    }

}
