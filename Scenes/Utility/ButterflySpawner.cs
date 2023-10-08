using Godot;
using System;
using System.Linq;

public class ButterflySpawner : Spatial
{
  [Export(PropertyHint.Range, "0.0,1.0,0.01")]
  private float _spawnChance = 0.5f;

  public override void _Ready()
  {
    var children = GetChildren();
    foreach (Spatial child in children)
    {
      child.Visible = GD.Randf() > _spawnChance;
    }
  }
}
