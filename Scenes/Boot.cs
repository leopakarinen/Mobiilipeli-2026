using Godot;
using System;

public partial class Boot : Area2D
{
    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            GameManager.Instance.LoseLife();  // Vähennetään pelaajan elämää
            QueueFree();                      // Poistetaan saapas pelistä
        }
    }
}