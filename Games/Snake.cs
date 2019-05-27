using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Games
{
    class Snake
    {
        Snake_Parts[] snake_part;
        int snake_growth;
        Direction Our_direction;

        public Snake()
        {
            snake_part = new Snake_Parts[3];
            snake_growth = 3;
            snake_part[0] = new Snake_Parts(150, 150);
            snake_part[1] = new Snake_Parts(160, 150);
            snake_part[2] = new Snake_Parts(170, 150);

        }

        public void Move(Direction direction)
        {
            Our_direction = direction;
            if(direction != null)
            {
                for (int i = snake_part.Length-1; i > 0; i--) // yılan başı bir şeyi takip etmeyecek ama arkadakiler öndekini takip edecek
                {
                    snake_part[i] = new Snake_Parts(snake_part[i - 1].x_, snake_part[i - 1].y_); // birbirini takip edecek
                }
                snake_part[0] = new Snake_Parts(snake_part[0].x_ + direction._x, snake_part[0].y_ + direction._y);
            }
        }

        public void Grow()
        {
            Array.Resize(ref snake_part, snake_part.Length + 1);
            snake_part[snake_part.Length-1] = new Snake_Parts(snake_part[snake_part.Length-2].x_-Our_direction._x,snake_part [snake_part.Length - 2].y_ - Our_direction._y);
            snake_growth++;
        }

        public Point GetPos(int number)
        {
            return new Point(snake_part[number].x_, snake_part[number].y_);
        }
    }

    class Snake_Parts
    {
        public int x_; // read only bir kere tanımladıktan sonra değiştiremiyoruz 
        public int y_;
        public readonly int size_x;
        public readonly int size_y;
        public Snake_Parts(int x, int y)
        {
            x_ = x;
            y_ = y;
            size_x = 10;
            size_y = 10;
        }
    }

    class Direction
    {
        public readonly int _x;
        public readonly int _y;
        public Direction(int x, int y)
        {
            _x = x;
            _y = y;
            
        }
    }
}
        



