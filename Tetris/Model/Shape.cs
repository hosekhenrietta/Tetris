using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Model
{
    public class Shape
    {
        private int s;
        public int[,] Matrix;

        public Shape(int szam)
        {
            s = szam;
            if (s == 0)
            {
                Matrix = new int[,] { { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            }
            else if (s == 1)
            {
                Matrix = new int[,] { { 1, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            }
            else if (s == 2)
            {
                Matrix = new int[,] { { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, };
            }
            else if (s == 3)
            {
                Matrix = new int[,] { { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 0, 0, 0 } };
            }
        }

        //int[,] Matrix = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 1, 1, 1, 0 } };
        //{ { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 1, 0, 0 }, { 1, 1, 0, 0 } };
        //{ { 0, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 0 } };
        //{ { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 0, 0, 0 } };
        public void Write()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    System.Diagnostics.Debug.Write(Matrix[i, j] + " ");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
            System.Diagnostics.Debug.WriteLine("");
        }
        public Int32 GetS() { return s; }
        public void SetS(int szam) { s = szam; }
        public void Rotate()
        {
            int[,] tmp = new int[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tmp[j, 3 - i] = Matrix[i, j];
                }
            }
            bool r_null = true;
            bool c_null = true;
            int row = 0; //elso sor
            int column = 0; //első oszlop
            while (r_null || c_null)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (tmp[row, i] != 0)
                    {
                        r_null = false;
                    }

                    if (tmp[i, column] != 0)
                    {
                        c_null = false;
                    }

                }

                if (r_null)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            tmp[i - 1, j] = tmp[i, j];
                            tmp[i, j] = 0;
                        }
                    }
                }
                if (c_null)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 1; j < 4; j++)
                        {
                            tmp[i, j - 1] = tmp[i, j];
                            tmp[i, j] = 0;
                        }
                    }
                }

                Matrix = tmp;


            }


        }
    }
}
