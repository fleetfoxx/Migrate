using Godot;
using System;

public class ButterflyNpc : Area
{
  [Export] private float _speed = 1f;
  [Export] private float _targetRange = 5f;

  private Vector3 _origin;
  private Vector3 _target;

  public override void _Ready()
  {
    _origin = GlobalTranslation;
    _target = _origin;
  }

  public override void _Process(float delta)
  {
    if (GlobalTranslation.DistanceTo(_target) < 0.0001f)
    {
      var randX = _origin.x + (float)GD.RandRange(-_targetRange, _targetRange);
      var randY = _origin.y + (float)GD.RandRange(-_targetRange, _targetRange);
      var randZ = _origin.z + (float)GD.RandRange(-_targetRange, _targetRange);
      _target = new Vector3(randX, randY, randZ);
    }

    GlobalTranslation = GlobalTranslation.MoveToward(_target, _speed);
  }
}
