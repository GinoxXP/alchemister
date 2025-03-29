using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ginox.BlackCauldron.Core
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event INotifyPropertyChanged.PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
