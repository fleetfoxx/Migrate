using Godot;
using System;

[Tool]
public class Planet : Spatial
{
  [Export] private float _speed = 1f;
  [Export] private float _turnSpeed = 5f;
  [Export] private bool _spinInEditor = false;
  [Export] private NodePath _planetMeshPath;

  private MeshInstance _planetMesh;

  public override void _Ready()
  {
    _planetMesh = GetNode<MeshInstance>(_planetMeshPath);
  }

  public override void _Process(float delta)
  {
    if (Engine.EditorHint)
    {
      if (_spinInEditor)
      {
        GlobalRotate(Vector3.Right, Mathf.Deg2Rad(_speed * delta));
      }
    }
    else
    {
      // spin (forward)
      GlobalRotate(Vector3.Right, Mathf.Deg2Rad(_speed * delta));

      var axis = Input.GetAxis("turn_left", "turn_right");
      GlobalRotate(Vector3.Up, Mathf.Deg2Rad(axis * _turnSpeed * delta));
      // _planetMesh.GlobalRotate(Vector3.Back, Mathf.Deg2Rad(axis * _speed * delta));
    }
  }
}
