using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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
            Snake = new Snake(4);
            Task.Run(() => Game());
        }
        private async Task Game() 
        {
            for (int i = 0; i < 10; i++)
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    DrawSnake();
                });
                await Task.Delay(1000);
                Snake.MoveSnake();
            }
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
    }
}
