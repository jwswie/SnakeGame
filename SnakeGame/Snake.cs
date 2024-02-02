using System.Collections.Generic;

namespace SnakeGame
{
    public class Snake
    {
        public class Body // Каждая часть змеи имеет две координаты
        {
            public int x;
            public int y;
        }

        int dir { get; set; } // Направление движения змеи
        public List<Body> SnakeBody { get; set; } // Тело змеи

        public Snake(int BodyLength) 
        {
            SnakeBody = new List<Body>();
            dir = 2;

            for (int i = 0; i < BodyLength; i++)
            {
                SnakeBody.Add(new Body() { x = 4 - i, y = 4 });
            }
        }

        public bool MoveSnake() // Движение змейки
        {
            switch (dir)
            {
                case 0: // Вперёд
                    for (int i = SnakeBody.Count - 1; i > 0; i--)
                    {
                        SnakeBody[i].y = SnakeBody[i - 1].y;
                        SnakeBody[i].x = SnakeBody[i - 1].x;
                    }
                    SnakeBody[0].y -= 1;
                    break;

                case 1: // Влево
                    for (int i = SnakeBody.Count - 1; i > 0; i--)
                    {
                        SnakeBody[i].y = SnakeBody[i - 1].y;
                        SnakeBody[i].x = SnakeBody[i - 1].x;
                    }
                    SnakeBody[0].x -= 1;
                    break;

                case 2: // Вправо
                    for (int i = SnakeBody.Count - 1; i > 0; i--)
                    {
                        SnakeBody[i].y = SnakeBody[i - 1].y;
                        SnakeBody[i].x = SnakeBody[i - 1].x;
                    }
                    SnakeBody[0].x += 1;
                    break;

                case 3: // Назад
                    for (int i = SnakeBody.Count - 1; i > 0; i--)
                    {
                        SnakeBody[i].y = SnakeBody[i - 1].y;
                        SnakeBody[i].x = SnakeBody[i - 1].x;
                    }
                    SnakeBody[0].y += 1;
                    break;
            }
            for (int i = 1; i < SnakeBody.Count; i++)
                if (((SnakeBody[0].x == SnakeBody[i].x) && (SnakeBody[0].y == SnakeBody[i].y)) || SnakeBody[0].x == 9 || SnakeBody[0].y == 9 || SnakeBody[0].x == -1 || SnakeBody[0].y == -1)
                    return false;
            return true;
        }

        public void SetDir(int dir)
        {
            this.dir = dir;
        }

        public int GetDir()
        {
            return dir;
        }
    }
}