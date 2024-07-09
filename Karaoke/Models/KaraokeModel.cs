using Karaoke.Infrastucture;
using Microsoft.Xaml.Behaviors.Media;

namespace Karaoke.Models;

internal class KaraokeModel : Notifier
{
    public double Time { get; set; }
    public string Row {  get; set; }
}
