using Godot;
using System;

[Tool]
public class StickToSphere : Spatial
{
  [Export] private float _radius = 1f;

  public override void _Process(float delta)
  {
    if (Engine.EditorHint)
    {

      var parent = GetParent<Spatial>();
      if (parent == null) return;

      // var dir = parent.GlobalTranslation.DirectionTo(GlobalTranslation);
      // GlobalRotation = dir;

      LookAt(parent.GlobalTranslation, Vector3.Up);
    }
  }
}
