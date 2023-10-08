using Godot;
using System;

public class ButterflyFact : Control
{
  [Export] private NodePath _animPath;

  private GlobalSettings _globalSettings;
  private AnimationPlayer _anim;

  public override void _Ready()
  {
    _globalSettings = GetNode<GlobalSettings>(GlobalSettings.PATH);
    _globalSettings.Connect(nameof(GlobalSettings.IsPausedChanged), this, nameof(HandleIsPausedChanged));

    _anim = GetNode<AnimationPlayer>(_animPath);
    _anim.Connect("animation_finished", this, nameof(HandleAnimationFinished));
  }

  private void HandleIsPausedChanged(bool isPaused)
  {
    if (!isPaused)
    {
      _anim.Play("fade");
    }
  }

  private void HandleAnimationFinished(string anim_name)
  {
    QueueFree();
  }
}
