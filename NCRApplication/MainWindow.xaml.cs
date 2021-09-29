using System;
using System.Linq;
using System.Windows;

namespace NCRApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string alert = string.Empty;
            if (string.IsNullOrEmpty(txtbox.Text))
                alert = "you have to type letters.";
            else
            {
                if (txtbox.Text.Length > 20)
                {
                    alert = "Text too long.";
                }
                if(!txtbox.Text.All(char.IsLetterOrDigit))
                        alert += "You can type only letter or digits.";               
            }
            if (alert != String.Empty)
                lblAlert.Content = alert;
            else
            {
                lblAlert.Content = "";
                MessageBox.Show(txtbox.Text, "Input Text", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
