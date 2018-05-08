using System;
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
        }

        private void CloseAnimationCompleted(object sender, EventArgs e)
        {
            Close();
        }
    }
}
