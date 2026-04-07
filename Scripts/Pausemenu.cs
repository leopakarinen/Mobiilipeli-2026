using Godot;
using System;

public partial class Pausemenu : CanvasLayer
{
    [Export] private TextureButton _MenuButton;
    [Export] private TextureButton _PlayButton;

    public override void _Ready()
    {
        // UI toimii vaikka peli on pausella
        ProcessMode = ProcessModeEnum.Always;

        _MenuButton.Pressed += OnMenuPressed;
        _PlayButton.Pressed += OnPlayPressed;

        Visible = false;
    }

    // 🔥 Tätä kutsutaan pause-napista
    public void OpenPauseMenu()
    {
        Visible = true;
        GetTree().Paused = true;
    }


    private void OnMenuPressed()
    {
        GetTree().Paused = false;
        GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
    }

    private void OnPlayPressed()
    {
        Visible = false;
        GetTree().Paused = false;
    }
}