using Godot;
using System;

public class PauseMenu : Control
{
  [Export] private NodePath _musicSliderPath;
  [Export] private NodePath _sfxSliderPath;
  [Export] private NodePath _resumeButtonPath;
  [Export] private NodePath _exitButtonPath;
  [Export] private NodePath _animPath;

  private GlobalSettings _globalSettings;
  private Slider _musicSlider;
  private Slider _sfxSlider;
  private Button _resumeButton;
  private Button _exitButton;
  private AnimationPlayer _anim;

  public override async void _Ready()
  {
    _globalSettings = GetNode<GlobalSettings>(GlobalSettings.PATH);
    _globalSettings.Connect(nameof(GlobalSettings.IsPausedChanged), this, nameof(HandleIsPausedChanged));

    _anim = GetNode<AnimationPlayer>(_animPath);

    _musicSlider = GetNode<Slider>(_musicSliderPath);
    _musicSlider.Connect("value_changed", this, nameof(HandleMusicVolumeChanged));

    _sfxSlider = GetNode<Slider>(_sfxSliderPath);
    _sfxSlider.Connect("value_changed", this, nameof(HandleSFXVolumeChanged));

    _resumeButton = GetNode<Button>(_resumeButtonPath);
    _resumeButton.Connect("pressed", this, nameof(HandleResumeButtonClicked));

    _exitButton = GetNode<Button>(_exitButtonPath);
    _exitButton.Connect("pressed", this, nameof(HandleExitButtonClicked));

    var mainNode = GetNode<Main>(Main.PATH);
    await ToSignal(mainNode, "ready");

    _musicSlider.Value = _globalSettings.MusicVolume;
    _sfxSlider.Value = _globalSettings.SFXVolume;
    Visible = _globalSettings.IsPaused;
  }

  private void Resume()
  {
    Visible = false;
    _globalSettings.IsPaused = false;
  }

  private void HandleIsPausedChanged(bool isPaused)
  {
    Visible = isPaused;

    if (isPaused)
    {
      _anim.PlayBackwards("fade");
    }
    else
    {
      _anim.Play("fade");
    }
  }
  private void HandleMusicVolumeChanged(float value) => _globalSettings.MusicVolume = value;
  private void HandleSFXVolumeChanged(float value) => _globalSettings.SFXVolume = value;
  private void HandleExitButtonClicked() => GetTree().Quit();
  private void HandleResumeButtonClicked() => Resume();
}
