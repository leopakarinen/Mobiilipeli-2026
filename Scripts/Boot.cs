using Godot;
using System;

public partial class Boot : Area2D
{
    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
    }

    public override void _Process(double delta)
    {
        GlobalPosition += new  Vector2(0, 100 * (float)delta);
    }
    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            GameManager.Instance.LoseLife();  // Vähennetään pelaajan elämää
            QueueFree();                      // Poistetaan saapas pelistä
        }
    }

    public void OnAreaEntered (Node Area)
    {
        if(Area.IsInGroup("Fish"))
        {
            GameManager.Instance.LoseLife();
            GD.Print("Hit a fish");
            Area.QueueFree();
            QueueFree();
        }
    }
}