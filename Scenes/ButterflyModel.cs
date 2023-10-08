using Godot;
using System;

public class ButterflyModel : Spatial
{
  [Export] private NodePath _animPath;

  private AnimationPlayer _anim;

  private const string ANIM_FLUTTER = "flutter";
  private const string ANIM_REST = "rest";

  public override void _Ready()
  {
    _anim = GetNode<AnimationPlayer>(_animPath);
    Rest();
  }

  public void Flutter()
  {
    _anim.Play(ANIM_FLUTTER);
  }

  public void Rest()
  {
    _anim.Play(ANIM_REST);
    var rand = GD.Randf() * _anim.CurrentAnimationLength;
    _anim.Seek(rand, true);
  }
}
