using Google.Cloud.Translation.V2;
using System.Collections.Generic;
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
        private ICommand _switchLanguagesCommand;
        private double _screenHeight;
        private double _screenWidth;
        private IEnumerable<Language> _languages;
        private Language _sourceLanguage;
        private Language _targetLanguage;
        private string _sourceText;
        private string _targetText;

        public ICommand GitHubCommand
        {
            get => _gitHubCommand;
            set => Set(ref _gitHubCommand, value);
        }
        public ICommand SwitchLanguagesCommand
        {
            get => _switchLanguagesCommand;
            set => Set(ref _switchLanguagesCommand, value);
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
        public IEnumerable<Language> Languages
        {
            get => _languages;
            set => Set(ref _languages, value);
        }
        public Language SourceLanguage
        {
            get => _sourceLanguage;
            set => Set(ref _sourceLanguage, value);
        }
        public Language TargetLanguage
        {
            get => _targetLanguage;
            set => Set(ref _targetLanguage, value);
        }
        public string SourceText
        {
            get => _sourceText;
            set => Set(ref _sourceText, value);
        }
        public string TargetText
        {
            get => _targetText;
            set
            {
                Set(ref _targetText, value);
                UpdateTranslation();
            }
        }
        #endregion

        public TranslatorViewModel()
        {
            Model = new TranslatorModel();
            GitHubCommand = new RelayCommand(GitHubAction);
            SwitchLanguagesCommand = new RelayCommand(SwitchLanguagesAction);

            var workArea = SystemParameters.WorkArea;
            ScreenWidth = workArea.Right;
            ScreenHeight = workArea.Bottom;
            //Initialize();
            Languages = Model.GetAllLanguages();
        }

        public async void Initialize()
        {
            Languages = await Model.GetAllLanguagesAsync();
        }

        private async void UpdateTranslation()
        {
            TargetText = await Model.TranslateAsync(SourceText, SourceLanguage, TargetLanguage);
        }

        private void GitHubAction(object o)
        {
            Process.Start("https://github.com/mrousavy/Vertaler");
        }

        private void SwitchLanguagesAction(object o)
        {
            var tmp = SourceLanguage;
            SourceLanguage = TargetLanguage;
            TargetLanguage = tmp;
        }
    }
}
