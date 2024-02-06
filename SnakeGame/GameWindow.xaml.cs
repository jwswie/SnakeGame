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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        static public int _score;
        private const int Rows = 9;
        private const int Columns = 9;
        private Random _random = new Random();
        private Apple _currentApple;

        Snake Snake { get; set; }

        public GameWindow()
        {
            InitializeComponent();
            InitializeGameGrid();

            Snake = new Snake(5);
            Task.Run(() => Game());

            _score = 0;
        }

        private async Task Game()
        {
            do
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    DrawSnake();
                });
                await Task.Delay(500);
            } while (Snake.MoveSnake());

            Dispatcher.Invoke(() =>
            {
                MessageBox.Show("Game Over", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow main = new MainWindow();
                main.Show();

                this.Close();
            });
        }

        private void DrawSnake()
        {
            gameGrid.Children.Clear();

            Grid.SetColumn(_currentApple.AppleImage, _currentApple.X);
            Grid.SetRow(_currentApple.AppleImage, _currentApple.Y);
            gameGrid.Children.Add(_currentApple.AppleImage);

            foreach (var body in Snake.SnakeBody)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Background = new SolidColorBrush(Colors.Black);
                Grid.SetColumn(stackPanel, body.x);
                Grid.SetRow(stackPanel, body.y);
                gameGrid.Children.Add(stackPanel);
            }

            // Проверка, съела ли змея яблоко
            if (Snake.SnakeBody[0].x == _currentApple.X && Snake.SnakeBody[0].y == _currentApple.Y)
            {
                _score++;
                scoreText.Text = _score.ToString();
                AddAppleToField();

                Snake.Grow(); // Увеличиваем длину змейки
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

        private void InitializeGameGrid()
        {
            gameGrid.ShowGridLines = true;

            for (int i = 0; i < Rows; i++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < Columns; i++)
            {
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            AddAppleToField();
        }

        private void GenerateAppleCoordinates(out int x, out int y)
        {
            x = _random.Next(0, Columns);
            y = _random.Next(0, Rows);
        }

        private void AddAppleToField()
        {
            GenerateAppleCoordinates(out int x, out int y);

            _currentApple = new Apple(x, y, new StackPanel() { Background = (Brush)new BrushConverter().ConvertFromString("Red")});

            Grid.SetColumn(_currentApple.AppleImage, _currentApple.X);
            Grid.SetRow(_currentApple.AppleImage, _currentApple.Y);
            gameGrid.Children.Add(_currentApple.AppleImage);
        }
    }
}