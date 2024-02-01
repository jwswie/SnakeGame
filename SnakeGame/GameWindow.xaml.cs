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
        private const int Rows = 9;
        private const int Columns = 9;
        Snake Snake { get; set; }

        public GameWindow()
        {
            InitializeComponent();
            InitializeGameGrid();
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
                await Task.Delay(500);
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

            //  сегменты змейки, еду и другие элементы игры в ячейки сетки

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
