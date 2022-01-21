using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Model;

namespace Tetris.Persistence
{
    public class Table
    {
        public int[,] _table;
        public Pair _size;
        public int _tick;

        public Table(int n)
        {
            _table = new int[16+1,n+2];
            _size = new Pair(16 + 1, n + 2);
            _tick = 0;
        }
        public int GetValue(int i,int j)
        {
            return _table[i, j];
        }
    }
       
}
