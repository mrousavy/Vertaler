using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Vertaler.Implementation;
using Vertaler.Models;

namespace Vertaler.ViewModels
{
    public class TranslatorViewModel : ViewModelBase
    {
        #region Properties
        public TranslatorModel Model { get; }
        private ICommand _gitHubCommand;
        private double _screenHeight;
        private double _screenWidth;

        public ICommand GitHubCommand
        {
            get => _gitHubCommand;
            set => Set(ref _gitHubCommand, value);
        }
        public double ScreenWidth
        {
            get => _screenWidth;
            set => Set(ref _screenWidth, value);
        }
        public double ScreenHeight
        {
            get => _screenHeight;
            set => Set(ref _screenHeight, value);
        }
        #endregion

        public TranslatorViewModel()
        {
            Model = new TranslatorModel();
            GitHubCommand = new RelayCommand(GitHubAction);

            var workArea = SystemParameters.WorkArea;
            ScreenWidth = workArea.Right;
            ScreenHeight = workArea.Bottom;
        }

        private void GitHubAction(object o)
        {
            Process.Start("https://github.com/mrousavy/Vertaler");
        }
    }
}
