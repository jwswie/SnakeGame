namespace SnakeGame.Apple
{
    public class AppleGenerator
    {
        public bool IsCoordinateOnFieldEdge(int x, int y)
        {
            int fieldWidth = 9;
            int fieldHeight = 9;

            return x == 0 || x == fieldWidth - 1 || y == 0 || y == fieldHeight - 1;
        }
    }
}
