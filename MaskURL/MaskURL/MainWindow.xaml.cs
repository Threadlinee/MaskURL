using System;
using System.Windows;

namespace MaskURLTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            // Grab user input
            string original = txtOriginal.Text.Trim();
            string fake = txtFake.Text.Trim();

            fake = fake.Replace("https://", "").Replace("http://", "").Replace("/", "");

            if (string.IsNullOrEmpty(original) || string.IsNullOrEmpty(fake))
            {
                MessageBox.Show("Both fields are required!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                Uri realUri = new Uri(original);

                string maskedUrl = $"https://{fake}@{realUri.Host}{realUri.PathAndQuery}";

                txtOutput.Text = maskedUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid original URL.\n\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
