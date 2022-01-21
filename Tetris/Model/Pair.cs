using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Model
{
    public class Pair
    {
        public int x { get; set; }
        public int y { get; set; }
        public Pair(int first, int second)
        {
            this.x = first;
            this.y = second;
        }
        public void Write()
        {
            System.Diagnostics.Debug.WriteLine(x + " - " + y);
        }
    }
}
