using System.Diagnostics;
using System.Windows;

namespace Vertaler
{
    /// <summary>
    /// Interaction logic for TranslatorWindow.xaml
    /// </summary>
    public partial class TranslatorWindow : Window
    {
        public TranslatorWindow()
        {
            InitializeComponent();
        }

        private void GitHubClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/mrousavy/Vertaler");
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            // TODO: FADE OUT/OTHER ANIMATION
            WindowState = WindowState.Minimized;
        }
    }
}
