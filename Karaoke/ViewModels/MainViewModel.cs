using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Karaoke.Infrastucture;
using Karaoke.Models;
using Karaoke.Services;
using Microsoft.Win32;

namespace Karaoke.ViewModels;

internal partial class MainViewModel : Notifier
{
    private readonly AppSettings _settings;
    private readonly DispatcherTimer _timer;
    private bool _isAudioOpen = false;
    private bool _isTextOpen = false;
    private bool _isStoped = false;

    private List<TimeSpan> _timePoints = new();

    
    public MainViewModel()
    {
        _settings = SettingService.LoadSettings();
        _timer = new DispatcherTimer();
        Player = new MediaPlayer();

        _timer.Tick += (s, e) => UpdatePosition();

        Row = "Example";

        SelectedBackgroundColor =
            _settings.SelectedBackgroundColor != null
                ? (Color)ColorConverter.ConvertFromString(_settings.SelectedBackgroundColor)
                : Colors.Black;
        SelectedForegroundColor =
            _settings.SelectedForegroundColor != null
                ? (Color)ColorConverter.ConvertFromString(_settings.SelectedForegroundColor)
                : Colors.Black;

        SettingsVisibility = Visibility.Collapsed;

        _timePoints.Add(TimeSpan.Zero);
        TimePoints.Add(TimeSpan.Zero.ToString());
    }

    private void TogglePlayPause()
    {
        if (IsPlaying)
        {
            Player.Pause();
        }
        else
        {
            Player.Play();
            _timer.Start();
        }
        IsPlaying = !IsPlaying;
    }

    private void Rewind() => Player.Position = Player.Position.Subtract(TimeSpan.FromSeconds(10));

    private void FastForward() => Player.Position = Player.Position.Add(TimeSpan.FromSeconds(10));

    private void UpdatePosition() => CurrentPosition = Player.Position;
}
