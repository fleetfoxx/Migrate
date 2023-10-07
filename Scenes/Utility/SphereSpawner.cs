using Godot;
using System;
using System.Collections.Generic;

[Tool]
public class SphereSpawner : Spatial
{
  [Export] private PackedScene _sceneToSpawn;

  private float _radius;

  [Export(PropertyHint.Range, "0.1,1000,0.1")]
  public float Radius
  {
    get => _radius;
    set
    {
      _radius = value;
      Spawn();
    }
  }

  private int _density;

  [Export(PropertyHint.Range, "0,100,")]
  public int Density
  {
    get => _density;
    set
    {
      _density = value;
      Spawn();
    }
  }

  private List<Node> _instances = new List<Node>();
  private bool _isSpawned = false;

  public override void _Process(float delta)
  {
    if (!_isSpawned)
    {
      Spawn();
      _isSpawned = true;
    }
  }

  // https://math.stackexchange.com/a/1585996
  private void Spawn()
  {
    var parent = GetParent();
    if (parent == null) return;

    Vector3 pos;

    Despawn();

    for (var i = 0; i < _density; i++)
    {
      pos = GetRandomPointOnSphere();

      var instance = _sceneToSpawn.Instance<Spatial>();

      parent.AddChild(instance);

      // instance.Translation = pos;
      instance.LookAtFromPosition(GlobalTranslation + pos, GlobalTranslation, Vector3.Up);

      _instances.Add(instance);
    }
  }

  private Vector3 GetRandomPointOnSphere()
  {
    var random = new RandomNumberGenerator();
    random.Randomize();

    var x = random.Randfn();
    var y = random.Randfn();
    var z = random.Randfn();

    // ensure we don't generate a point at the origin
    while (x == 0 && y == 0 && z == 0)
    {
      x = random.Randfn();
      y = random.Randfn();
      z = random.Randfn();
    }

    return new Vector3(x, y, z).Normalized() * _radius;
  }

  private void Despawn()
  {
    foreach (var instance in _instances)
    {
      instance.QueueFree();
    }
    _instances = new List<Node>();
  }
}
