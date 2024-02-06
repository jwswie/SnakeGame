using System.Windows.Controls;

namespace SnakeGame
{
    public class Apple
    {
        public int X = 0;
        public int Y = 0;

        public StackPanel AppleImage = new StackPanel();

      /*  public Apple()
        {
            X = 0;
            Y = 0;
            AppleImage = new StackPanel();
        }*/

        public Apple(int x, int y, StackPanel image)
        {
            X = x;
            Y = y;
            AppleImage = image;
        }
        
    }
}