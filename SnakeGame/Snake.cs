using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        public class Body
        {
            public int x;
            public int y;
        }
        int dir;
        public List<Body> SnakeBody { get; set; }
        public Snake(int BodyLength) 
        {
            SnakeBody = new List<Body>();
            dir = 2;
            for (int i = 0; i < BodyLength; i++)
            {
                SnakeBody.Add(new Body() { x = 4-i, y = 4 });
            }
        }
        public void MoveSnake() 
        {

            switch (dir)
            {
                case 0:
                    for (int i = SnakeBody.Count - 1; i > 0; i--)
                    {
                        SnakeBody[i].y = SnakeBody[i-1].y;
                        SnakeBody[i].x = SnakeBody[i-1].x;
                    }
                    SnakeBody[0].y -=1;
                    break;
                case 1:
                    for (int i = SnakeBody.Count - 1; i > 0; i--)
                    {
                        SnakeBody[i].y = SnakeBody[i-1].y;
                        SnakeBody[i].x = SnakeBody[i-1].x;
                    }
                    SnakeBody[0].x -=1;
                    break;
                case 2:
                    for (int i = SnakeBody.Count - 1; i > 0; i--)
                    {
                        SnakeBody[i].y = SnakeBody[i-1].y;
                        SnakeBody[i].x = SnakeBody[i-1].x;
                    }
                    SnakeBody[0].x +=1;
                    break;
                case 3:
                    for (int i = SnakeBody.Count - 1; i > 0; i--)
                    {
                        SnakeBody[i].y = SnakeBody[i-1].y;
                        SnakeBody[i].x = SnakeBody[i-1].x;
                    }
                    SnakeBody[0].y +=1;
                    break;
            }
        }
    }
}
