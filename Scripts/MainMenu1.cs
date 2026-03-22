using Godot;
using System;

public partial class MainMenu1 : Control
{
        [Export] private TextureButton _PlayButton;
        [Export] private Button _Exitbutton;
        [Export] private Button _SettingsButton;
		[Export] private CanvasLayer _SettingsMenu;

        // options menu yleensä tehdään omaan sceneen elikkä ihan uus oma scene ja sitten copy pastetaan main menu sceneen
        // exporttaa sekin ja kato mikä on se root node
        // tässä esimerkissä se on canvaslayer


    public override void _Ready()
    {
        _PlayButton.Pressed += OnPlayButtonPressed;
        _Exitbutton.Pressed += OnQuitPressed;
        _SettingsButton.Pressed += OnOptionsPressed;

        // buttons are synced

		_SettingsMenu.Visible = false;
    }

    private void OnPlayButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Main.tscn");
        // changes scene
    }

    private void OnQuitPressed()
    {
        GetTree().Quit();

        // closes the game

    }

    private void OnOptionsPressed()
    {
		_SettingsMenu.Visible = true;
        // when settings button is pressed settings menu will open 
    }
}