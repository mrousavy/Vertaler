using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Vertaler.Implementation;

namespace Vertaler.ViewModels
{
    public class TrayIconViewModel : ViewModelBase
    {
        #region Properties
        private ICommand _leftClickCommand;
        private ICommand _settingsCommand;
        private ICommand _closeCommand;

        public ICommand LeftClickCommand
        {
            get => _leftClickCommand;
            set => Set(ref _leftClickCommand, value);
        }

        public ICommand SettingsCommand
        {
            get => _settingsCommand;
            set => Set(ref _settingsCommand, value);
        }

        public ICommand CloseCommand
        {
            get => _closeCommand;
            set => Set(ref _closeCommand, value);
        }
        #endregion

        public TrayIconViewModel()
        {
            LeftClickCommand = new RelayCommand(LeftClickAction);
            SettingsCommand = new RelayCommand(SettingsAction);
            CloseCommand = new RelayCommand(CloseAction);
        }

        private void LeftClickAction(object o)
        {
            Process.Start("https://github.com");
        }

        private void SettingsAction(object o)
        {
            // TODO: Show settings
        }

        private void CloseAction(object o)
        {
            Application.Current.Shutdown();
        }
    }
}
