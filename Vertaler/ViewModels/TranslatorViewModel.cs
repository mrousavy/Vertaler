using System.Diagnostics;
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

        public ICommand GitHubCommand
        {
            get => _gitHubCommand;
            set => Set(ref _gitHubCommand, value);
        }
        #endregion

        public TranslatorViewModel()
        {
            Model = new TranslatorModel();
            GitHubCommand = new RelayCommand(GitHubAction);
        }

        private void GitHubAction(object o)
        {
            Process.Start("https://github.com/mrousavy/Vertaler");
        }
    }
}
