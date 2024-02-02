using System.Windows.Controls;

namespace SnakeGame.AppleGenerator
{
    public class Apple
    {
        public Apple()
        {
            X = 0;
            Y = 0;
            AppleImage = new StackPanel();
        }
        public Apple(int x, int y, StackPanel image)
        {
            X = x;
            Y = y;
            AppleImage = image;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public StackPanel AppleImage { get; set; }
    }
}
