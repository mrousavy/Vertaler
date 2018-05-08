using System.ComponentModel;
using System.Runtime.CompilerServices;
using Vertaler.Annotations;

namespace Vertaler.Interfaces
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string callerName = null)
        {
            if (field?.Equals(value) == true)
                return;

            field = value;
            OnPropertyChanged(callerName);
        }
    }
}
