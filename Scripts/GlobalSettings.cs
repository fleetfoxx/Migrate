using Godot;

public class GlobalSettings : Node
{
  public static string PATH = "/root/GlobalSettings";

  [Signal] public delegate void MusicVolumeChanged(float value);
  [Signal] public delegate void SFXVolumeChanged(float value);
  [Signal] public delegate void IsPausedChanged(bool value);

  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("pause"))
    {
      IsPaused = !IsPaused;
    }
  }

  private float _musicVolume = -25f; // db
  public float MusicVolume
  {
    get => _musicVolume;
    set
    {
      _musicVolume = value;
      EmitSignal(nameof(MusicVolumeChanged), _musicVolume);
    }
  }

  private float _sfxVolume = -25f; // db
  public float SFXVolume
  {
    get => _sfxVolume;
    set
    {
      _sfxVolume = value;
      EmitSignal(nameof(SFXVolumeChanged), _sfxVolume);
    }
  }

  private bool _isPaused = true; // default to true to show menu at startup
  public bool IsPaused
  {
    get => _isPaused;
    set
    {
      _isPaused = value;
      EmitSignal(nameof(IsPausedChanged), _isPaused);
    }
  }

}