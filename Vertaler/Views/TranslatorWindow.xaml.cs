using System.Windows;

namespace Vertaler.Views
{
    /// <summary>
    /// Interaction logic for TranslatorWindow.xaml
    /// </summary>
    public partial class TranslatorWindow : Window
    {
        public TranslatorWindow()
        {
            InitializeComponent();
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            Left = screenWidth - Width;
            Top = screenHeight - Height;
            // TODO: OPEN ANIMATION
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            // TODO: CLOSE ANIMATION
            Close();
        }
    }
}
