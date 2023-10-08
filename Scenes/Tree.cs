using Godot;
using System;

public class Tree : Spatial
{
  [Export] private NodePath[] _butterflies;

  [Export(PropertyHint.Range, "0.0,1.0,0.01")]
  private float _spawnChance = 0.5f;

  public override void _Ready()
  {
    for (var i = 0; i < _butterflies.Length; i++)
    {
      GetNode<ButterflyModel>(_butterflies[i]).Visible = GD.Randf() > _spawnChance;
    }
  }
}
