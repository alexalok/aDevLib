using System;
using System.Runtime.CompilerServices;

namespace aDevLib.Classes
{
    public class PropertyChangedNotifier
    {
        protected void OnPropertyChanged([CallerMemberName] string? property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property!));
        }

        public event EventHandler<PropertyChangedEventArgs>? PropertyChanged;
    }

    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; }
    }
}