#nullable enable

using System;
using System.ComponentModel;

namespace Ginox.BlackCauldron.Core
{
    public interface INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e);
    }
}

#nullable disable
