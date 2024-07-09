using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Karaoke.Infrastucture;

internal class Notifier : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string prop = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
