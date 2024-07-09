using Karaoke.Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Windows.Media;

namespace Karaoke.Services;

internal static class FileService
{
    public static void OpenAudioFile(MediaPlayer player, ref bool isOpen, Action<string> filePath, Action<TimeSpan> duration)
    {
        OpenFileDialog file = new();
        file.Filter = "Audio Files | *.mp3; *.wav; *.wma | MP3 Files | *.mp3 | WAV Files | *.wav | WMA Files | *.wma";

        if (file.ShowDialog() == true)
        {
            player.Open(new Uri(file.FileName));
            player.MediaOpened += (s, e) =>
            {
                if (player.NaturalDuration.HasTimeSpan) 
                {
                    duration(player.NaturalDuration.TimeSpan);
                }
            };
            isOpen = true;
            filePath(file.FileName);
        }
    }

    public static ObservableCollection<KaraokeModel> OpenTextFile(ref bool isOpen, Action<string> filePath)
    {
        ObservableCollection<KaraokeModel> text = new();

        OpenFileDialog file = new();
        file.Filter = "Text Files | *.txt;";

        if (file.ShowDialog() == true)
        {
            var alltext = File.ReadAllText(file.FileName);
            var rows = alltext.Split("\n");    
            
            foreach (var item in rows)
            {
                text.Add(new KaraokeModel { Row = item.Trim() });
            }

            isOpen = true;
            filePath(file.FileName);
        }
        return text;
    }
}
