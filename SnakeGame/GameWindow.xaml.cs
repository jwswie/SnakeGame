using SnakeGame.AppleGenerator;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private int _score;
        private const int Rows = 9;
        private const int Columns = 9;
        private readonly Random _random;
        private Apple _currentApple;
        Snake Snake { get; set; }

        public GameWindow()
        {
            InitializeComponent();

            _random = new Random();

            InitializeGameGrid();

            Snake = new Snake(5);
            Task.Run(() => Game());

            _score = 0;
        }

        private void GenerateCoordinateApple(out int x, out int y)
        {
            x = _random.Next(0, Columns);
            y = _random.Next(0, Rows);
        }
        private void AddAppleToField()
        {
            GenerateCoordinateApple(out int x, out int y);

            _currentApple = new Apple(x, y, new StackPanel() { Background = Brushes.Red });

            Grid.SetColumn(_currentApple.AppleImage, _currentApple.X);
            Grid.SetRow(_currentApple.AppleImage, _currentApple.Y);
            gameGrid.Children.Add(_currentApple.AppleImage);
        }
        private async Task Game()
        {
            do
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    DrawSnake();
                });
                await Task.Delay(150);
            } while (Snake.MoveSnake());
            MessageBox.Show("End of the game");
            this.Close();
        }

        private void DrawSnake()
        {
            gameGrid.Children.Clear();
            foreach (var body in Snake.SnakeBody)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Background = new SolidColorBrush(Colors.Black);
                Grid.SetColumn(stackPanel, body.x);
                Grid.SetRow(stackPanel, body.y);
                gameGrid.Children.Add(stackPanel);

                if (Snake.SnakeBody[0].x == _currentApple.X && Snake.SnakeBody[0].y == _currentApple.Y)
                {
                    _score++;
                    Score.Text = "Score: " + _score.ToString();
                    AddAppleToField();
                }
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

            _currentApple = new Apple();

            AddAppleToField();
        }

        /* private Rectangle CreateSnakeSegment(int row, int column)
         {
             Rectangle segment = new Rectangle
             {
                 Width = CalculateCellSize(),
                 Height = CalculateCellSize(),
                 Fill = Brushes.Green
             };

             Grid.SetRow(segment, row);
             Grid.SetColumn(segment, column);

             return segment;
         }

         private Rectangle CreateFood(int row, int column)
         {
             Rectangle food = new Rectangle
             {
                 Width = CalculateCellSize(),
                 Height = CalculateCellSize(),
                 Fill = Brushes.Red
             };

             Grid.SetRow(food, row);
             Grid.SetColumn(food, column);

             return food;
         }

         private double CalculateCellSize()
         {
             return gameGrid.ActualWidth / Columns;
         }*/
    }
}
