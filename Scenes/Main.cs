using Godot;
using System;
using System.Diagnostics;

public class Main : Spatial
{
  public override void _Ready()
  {
    GD.Print("game started");
    GD.Randomize();
  }
}
