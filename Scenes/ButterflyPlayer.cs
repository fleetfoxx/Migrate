using Godot;
using System;

public class ButterflyPlayer : Area
{
  [Export] private float _speed = 5f;

  public override void _Process(float delta)
  {
    // var roll = Input.GetAxis("turn_left", "turn_right");
    // var pitch = Input.GetAxis("turn_up", "turn_down");

    // GlobalTranslation = new Vector3(GlobalTranslation.x + roll * _speed * delta, GlobalTranslation.y, GlobalTranslation.z);
  }
}
