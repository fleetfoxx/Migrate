using Godot;
using System;

public class ButterflyPlayer : Spatial
{
  [Export] private float _speed = 5f;
  [Export] private float _turnSpeed = 5f;
  [Export] private float _flightAltitude = 104;
  [Export] private float _groundAltitude = 100.1f;
  [Export] NodePath _playerPath;
  [Export] NodePath _butterflyModelPath;
  [Export] NodePath _areaPath;

  private GlobalSettings _globalSettings;
  private ButterflyModel _butterflyModel;
  private Spatial _player;

  public override void _Ready()
  {
    _globalSettings = GetNode<GlobalSettings>(GlobalSettings.PATH);
    _butterflyModel = GetNode<ButterflyModel>(_butterflyModelPath);
    _player = GetNode<Spatial>(_playerPath);

    var area = GetNode<Area>(_areaPath);

    area.Connect("area_entered", this, nameof(HandleAreaEntered));
    area.Connect("area_exited", this, nameof(HandleAreaExited));
  }

  public override void _Process(float delta)
  {
    if (_globalSettings.IsPaused)
    {
      // fly toward ground
      var target = new Vector3(_player.Translation.x, _groundAltitude, _player.Translation.z);
      _player.Translation = _player.Translation.MoveToward(target, _speed * delta);
    }
    else
    {
      // fly toward flight altitude
      var target = new Vector3(_player.Translation.x, _flightAltitude, _player.Translation.z);
      _player.Translation = _player.Translation.MoveToward(target, _speed * delta);


      RotateObjectLocal(Vector3.Left, Mathf.Deg2Rad(_speed * delta));
      // RotationDegrees = new Vector3(RotationDegrees.x - _speed * delta, RotationDegrees.y, RotationDegrees.z);

      var axis = Input.GetAxis("turn_left", "turn_right");
      RotateObjectLocal(Vector3.Down, Mathf.Deg2Rad(axis * _turnSpeed * delta));
      // RotationDegrees = new Vector3(RotationDegrees.x, RotationDegrees.y - axis * _turnSpeed * delta, RotationDegrees.z);
    }
  }

  private void HandleAreaEntered(Area area)
  {
    GD.Print("grounded");
    _butterflyModel.Rest();
  }

  private void HandleAreaExited(Area area)
  {
    GD.Print("flying");
    _butterflyModel.Flutter();
  }
}
