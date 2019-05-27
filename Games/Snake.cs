using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class Snake
    {
        Snake_Parts[] snake_part;

        public Snake()
        {
            snake_part = new Snake_Parts[3];
            snake_part[0] = new Snake_Parts(150, 150);
            snake_part[1] = new Snake_Parts(160, 150);
            snake_part[2] = new Snake_Parts(170, 150);

        }

        public void Move(Direction direction)
        {

        }

        public void Grow()
        {

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
        public readonly int x_;
        public readonly int y_;
        public Direction(int x, int y)
        {
            x_ = x;
            y_ = y;
            
        }
    }
}
        



