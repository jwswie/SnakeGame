using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame
{
    public partial class MainWindow : Window
    {
        private const int Rows = 9;
        private const int Columns = 9;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameGrid();
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

        private Rectangle CreateSnakeSegment(int row, int column)
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
        }
    }
}