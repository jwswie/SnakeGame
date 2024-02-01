using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Snake Snake { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Snake = new Snake(5);
            Task.Run(() => Game());
        }
        
        private async Task Game() 
        {
            do
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    DrawSnake();
                });
                await Task.Delay(300);
            } while (Snake.MoveSnake());
            MessageBox.Show("End of the game");
            this.Close();
        }
        private void DrawSnake() 
        {
            MainGrid.Children.Clear();
            foreach (var body in Snake.SnakeBody)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Background = new SolidColorBrush(Colors.Black);
                Grid.SetColumn(stackPanel, body.x);
                Grid.SetRow(stackPanel, body.y);
                MainGrid.Children.Add(stackPanel);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Snake.GetDir() == 1 || Snake.GetDir() == 2)
            {
                if (e.Key == Key.W || e.Key == Key.Up)
                {
                    Snake.SetDir(0);
                }
                if (e.Key == Key.S || e.Key == Key.Down)
                {
                    Snake.SetDir(3);
                }
            }
            if (Snake.GetDir() == 0 || Snake.GetDir() == 3)
            {
                if (e.Key == Key.A || e.Key == Key.Left)
                {
                    Snake.SetDir(1);
                }
                if (e.Key == Key.D || e.Key == Key.Right)
                {
                    Snake.SetDir(2);
                }
            }
            
            
        }
    }
}