using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joc
{
    internal class Setari
    {
        public static int Height { get; set; }
        public static int Width { get; set; }
        public static string directie;
        public Setari()
        {
            Width = 16;
            Height = 16;
            directie = "left";
        }
    }
}
