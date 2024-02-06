using System.Windows;

namespace SnakeGame
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

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow main = new GameWindow();
            this.Close();

            main.Show();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Magnificent game, designed by the greatest minds of mankind");
        }

        private void ScoreButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Your last score - {GameWindow._score}", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}