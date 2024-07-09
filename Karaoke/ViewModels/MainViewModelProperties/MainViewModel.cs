using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Karaoke.Infrastucture;
using Karaoke.Models;
using Karaoke.Services;

namespace Karaoke.ViewModels;

internal partial class MainViewModel : Notifier
{
    public MediaPlayer Player { get; private set; }
    public ObservableCollection<KaraokeModel> Rows { get; set; } = new();
    public ObservableCollection<string> TimePoints { get; set; } = new();
    public string Row { get; set; }
    public string AudioFilePath { get; set; }
    public string TextFilePath { get; set; }
    public int AllTimes { get; set; }
    public Color SelectedForegroundColor { get; set; }
    public Color SelectedBackgroundColor { get; set; }
    public Visibility SettingsVisibility { get; set; }
    public TimeSpan CurrentPosition { get; set; }
    public TimeSpan Duration { get; set; }
    public double Volume { get; set; }
    public bool IsPlaying { get; set; }
    public string SelectedMarker { get; set; }
    public ICommand CloseAnimation =>
        new Command(x =>
        {
            Player.Stop();
            Player.Close();
            AnimationService.CloseAnimation(x as Border);
        });
    public ICommand MinimizeCommand => new Command(x => AnimationService.Minimize(x as Border));
    public ICommand MaximizeCommand => new Command(x => AnimationService.Maximize(x as Border));
    public ICommand OpenAudioFileCommand =>
        new Command(x =>
        {
            Player.Stop();
            Player.Close();
            FileService.OpenAudioFile(
                Player,
                ref _isAudioOpen,
                file => AudioFilePath = file,
                duration => Duration = duration
            );
        });
    public ICommand OpenTextFileCommand =>
        new Command(x =>
            Rows = FileService.OpenTextFile(ref _isTextOpen, file => TextFilePath = file)
        );
    public ICommand OpenSettingsCommand =>
        new Command(x => AnimationService.FadeSettings(x as Border));
    public ICommand SaveColorCommand =>
        new Command(x =>
        {
            _settings.SelectedBackgroundColor = SelectedBackgroundColor.ToString();
            _settings.SelectedForegroundColor = SelectedForegroundColor.ToString();
            SettingService.SaveSettings(_settings);

            MessageBox.Show(
                "Colors saved successfully",
                "Succsess",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        });
    public ICommand ApplyAllTimesCommand =>
        new Command(x =>
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                Rows[i].Time = AllTimes;
            }
        });
    public ICommand PlayCommand =>
        new Command(
            async x =>
            {
                _isStoped = false;

                Player.Stop();
                Player.Play();

                foreach (var item in Rows)
                {
                    Row = item.Row;
                    await Task.Delay((int)(item.Time * 1000));
                    if (_isStoped)
                    {
                        Row = "Thank you!";
                        break;
                    }
                }
                IsPlaying = true;
            },
            x => _isAudioOpen && _isTextOpen
        );
    public ICommand PauseCommand =>
        new Command(
            x =>
            {
                Player.Stop();
                _isStoped = true;
                IsPlaying = false;
            },
            x => IsPlaying
        );
    public ICommand PlayPauseCommand => new Command(x => TogglePlayPause(), x => _isAudioOpen);
    public ICommand SelectedMarkerCommand => new Command(x => SelectedMarker = x as string);
    public ICommand DeleteMarkerCommand =>
        new Command(
            x =>
            {
                if (SelectedMarker != TimePoints[0])
                {
                    TimePoints.Remove(SelectedMarker);
                    SelectedMarker = "";
                }
            },
            x => !string.IsNullOrEmpty(SelectedMarker)
        );
    public ICommand RewindCommand => new Command(x => Rewind());
    public ICommand FastForwardCommand => new Command(x => FastForward());
    public ICommand ClearMarkersCommand =>
        new Command(x =>
        {
            TimePoints.Clear();
            _timePoints.Clear();
            _timePoints.Add(TimeSpan.Zero);
            TimePoints.Add(TimeSpan.Zero.ToString());
        });
    public ICommand AddTimePointCommand =>
        new Command(x =>
        {
            if (IsPlaying)
            {
                _timePoints.Add(CurrentPosition);
                TimePoints.Add(
                    $"{CurrentPosition.Seconds}:{CurrentPosition.Milliseconds / 10}  =>"
                        + $"  {(_timePoints[^1] - _timePoints[^2]).Seconds}"
                        + $":{(_timePoints[^1] - _timePoints[^2]).Milliseconds / 10}"
                );
            }
        });
}
