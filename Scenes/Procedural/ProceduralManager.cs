using Godot;
using System;
using System.Collections.Generic;

public class ProceduralManager : Spatial
{
  [Export] private PackedScene[] _sectionScenes;
  [Export] private int _initialSectionCount = 4;
  [Export] private float _sectionLength = 200;
  [Export] private float _destroyDistance = 790;
  [Export] private float _speed = 10f;

  private List<Spatial> _sections = new List<Spatial>();

  private bool _initialLoad = true;

  public override void _Ready()
  {
    if (_sectionScenes.Length == 0)
    {
      throw new Exception("Must provide at least one section scene.");
    }
  }

  public override void _Process(float delta)
  {
    if (_initialLoad)
    {
      for (var i = 0; i < _initialSectionCount; i++)
      {
        var sectionScene = _sectionScenes[GD.Randi() % _sectionScenes.Length];
        var section = sectionScene.Instance<Spatial>();
        var parent = GetParent();
        parent.AddChild(section);
        section.GlobalTranslation = new Vector3(GlobalTranslation.x, GlobalTranslation.y, GlobalTranslation.z + _sectionLength * i);
        _sections.Add(section);
      }

      _initialLoad = false;
    }

    var sections = _sections.ToArray();

    foreach (var section in sections)
    {
      if (GlobalTranslation.DistanceTo(section.GlobalTranslation) >= _destroyDistance)
      {
        GD.Print("Clearing old. Spawning new.");

        // remove old section
        section.QueueFree();
        _sections.Remove(section);

        // spawn new section
        var sectionScene = _sectionScenes[GD.Randi() % _sectionScenes.Length];
        var sectionInstance = sectionScene.Instance<Spatial>();
        GetParent().AddChild(sectionInstance);
        sectionInstance.GlobalTranslation = GlobalTranslation;
        _sections.Add(sectionInstance);
      }
      else
      {
        section.GlobalTranslation = new Vector3(section.GlobalTranslation.x, section.GlobalTranslation.y, section.GlobalTranslation.z + _speed * delta);
      }
    }
  }
}
