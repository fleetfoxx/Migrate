using Godot;
using System;

public class SFXPlayer : AudioStreamPlayer
{
  public override async void _Ready()
  {
    var globalSettings = GetNode<GlobalSettings>(GlobalSettings.PATH);
    globalSettings.Connect(nameof(GlobalSettings.SFXVolumeChanged), this, nameof(HandleVolumeChanged));

    var mainNode = GetNode<Main>(Main.PATH);
    await ToSignal(mainNode, "ready");

    VolumeDb = globalSettings.SFXVolume;
  }

  private void HandleVolumeChanged(float value) => VolumeDb = value;
}
