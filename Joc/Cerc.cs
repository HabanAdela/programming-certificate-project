using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joc
{
    public class Cerc
    {
        public int X { get; set; } 
        public int Y { get; set; }
        public Color C { get; set; }

        public int MoveSpeedX { get; set; }
        public int MoveSpeedY { get; set; }
        
        public Cerc() { }

        public Cerc(int x, int y, int speedX, int speedY, Color c)
        {
            X = x;
            Y = y;
            C = c;
            MoveSpeedX = speedX;
            MoveSpeedY = speedY;
        }
    }
}
