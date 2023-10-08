using Godot;
using System;

// [Tool]
public class Planet : Spatial
{
  // [Export] private float _speed = 1f;
  // [Export] private float _turnSpeed = 5f;
  // [Export] private bool _spinInEditor = false;
  // [Export] private NodePath _planetMeshPath;

  // private MeshInstance _planetMesh;
  // private GlobalSettings _globalSettings;


  // public override void _Ready()
  // {
  //   if (!Engine.EditorHint)
  //   {
  //     _globalSettings = GetNode<GlobalSettings>(GlobalSettings.PATH);
  //   }

  //   _planetMesh = GetNode<MeshInstance>(_planetMeshPath);
  //   GlobalRotation = Vector3.Zero;
  // }

  // public override void _Process(float delta)
  // {
  //   if (Engine.EditorHint)
  //   {
  //     if (_spinInEditor)
  //     {
  //       GlobalRotate(Vector3.Right, Mathf.Deg2Rad(_speed * delta));
  //     }
  //   }
  //   else
  //   {
  //     if (!_globalSettings.IsPaused)
  //     {
  //       // spin (forward)
  //       GlobalRotate(Vector3.Right, Mathf.Deg2Rad(_speed * delta));

  //       var axis = Input.GetAxis("turn_left", "turn_right");
  //       GlobalRotate(Vector3.Up, Mathf.Deg2Rad(axis * _turnSpeed * delta));
  //     }
  //   }
  // }
}
