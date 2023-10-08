using Godot;
using System;

public class MusicPlayer : AudioStreamPlayer
{
  public override async void _Ready()
  {
    var globalSettings = GetNode<GlobalSettings>(GlobalSettings.PATH);
    globalSettings.Connect(nameof(GlobalSettings.MusicVolumeChanged), this, nameof(HandleVolumeChanged));

    var mainNode = GetNode<Main>(Main.PATH);
    await ToSignal(mainNode, "ready");

    VolumeDb = globalSettings.MusicVolume;
  }

  private void HandleVolumeChanged(float value) => VolumeDb = value;
}
