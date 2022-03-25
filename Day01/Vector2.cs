using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public class Vector2
    {
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return new string($"{X};{Y}");
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
