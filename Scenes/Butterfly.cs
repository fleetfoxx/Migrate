using Godot;
using System;

public class Butterfly : RigidBody
{
  [Export] private NodePath _flapTimerPath;

  private const float MAX_ENERGY = 100f;

  private float _speed = 5f;
  private float _energy = MAX_ENERGY;
  private float _flapPower = 0.05f;
  private Vector3 _flapImpulse = new Vector3(0, 0.05f, 0);
  private float _boostPower = 0.2f;
  private Vector3 _boostImpulse = new Vector3(0, 0.2f, -0.01f);
  private int _consecutiveGoodFlaps = 0;
  private Timer _flapTimer;

  public override void _Ready()
  {
    _flapTimer = GetNode<Timer>(_flapTimerPath);
    LinearVelocity = Vector3.Forward * _speed;
  }

  public override void _PhysicsProcess(float delta)
  {
    if (Input.IsActionJustPressed("flap"))
    {
      if (_flapTimer.IsStopped())
      {
        _consecutiveGoodFlaps++;

        if (_consecutiveGoodFlaps == 3)
        {
          ApplyCentralImpulse(_boostImpulse);
          _consecutiveGoodFlaps = 0;
        }
        else
        {
          ApplyCentralImpulse(_flapImpulse);
        }

        _flapTimer.Start();
      }
      else
      {
        _consecutiveGoodFlaps = 0;
      }
    }
  }
}
