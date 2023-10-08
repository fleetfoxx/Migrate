using Godot;
using System;

public class ButterflyPlayer : Area
{
  [Export] private float _speed = 5f;
  [Export] private float _flightAltitude = 104;
  [Export] private float _groundAltitude = 100.1f;
  [Export] NodePath _butterflyModelPath;

  private GlobalSettings _globalSettings;
  private ButterflyModel _butterflyModel;

  public override void _Ready()
  {
    _globalSettings = GetNode<GlobalSettings>(GlobalSettings.PATH);
    _butterflyModel = GetNode<ButterflyModel>(_butterflyModelPath);

    Connect("area_entered", this, nameof(HandleAreaEntered));
    Connect("area_exited", this, nameof(HandleAreaExited));
  }

  public override void _Process(float delta)
  {
    if (_globalSettings.IsPaused)
    {
      // fly toward ground
      var target = new Vector3(GlobalTranslation.x, _groundAltitude, GlobalTranslation.z);
      GlobalTranslation = GlobalTranslation.MoveToward(target, _speed * delta);
    }
    else
    {
      // fly toward flight altitude
      var target = new Vector3(GlobalTranslation.x, _flightAltitude, GlobalTranslation.z);
      GlobalTranslation = GlobalTranslation.MoveToward(target, _speed * delta);
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
