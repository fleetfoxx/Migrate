using Godot;
using System;
using System.Diagnostics;

public class Main : Spatial
{
  public static string PATH = "/root/Main";

  public override void _Ready()
  {
    GD.Print("game started");
    GD.Randomize();
  }
}
