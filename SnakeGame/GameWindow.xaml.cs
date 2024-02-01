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

        public GameWindow()
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
