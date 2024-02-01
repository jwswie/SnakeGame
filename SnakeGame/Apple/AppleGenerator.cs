using System;
using System.Collections.Generic;

namespace SnakeGame.Apple
{
    public class AppleGenerator
    {
        private readonly Random random;
        public AppleGenerator()
        {
            random = new Random();
        }
        public (int x, int y) Generate(List<(int x, int y)> snakeBody, int maxX, int maxY, int maxAttempts = 100)
        {
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                int x = random.Next(0, maxX);
                int y = random.Next(0, maxY);

                if (!snakeBody.Contains((x, y)))
                {
                    return (x, y);
                }
            }

            return (-1, -1);
        }
    }
}
