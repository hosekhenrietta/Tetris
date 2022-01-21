using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tetris.Persistence;

namespace Tetris.Model
{
    public class FieldChangedEventArgs : EventArgs
    {
        public FieldChangedEventArgs()
        {
        }
    }
    public class GameOverEventArgs : EventArgs
    {
        public GameOverEventArgs()
        {
        }
    }
    class Model
    {
        Table tableModel;
        public int n;
        private Random _random;
        public Shape _shape;
        public int _ticks;
        private bool Paused;
        public Pair[] HereIsTheShape;

        public Interface dataAccess;


        public bool isPaused() { return Paused; }
        public void Pause() { Paused = !Paused; }

        public Table Table { get { return tableModel; } }

        public event EventHandler<FieldChangedEventArgs> FieldChanged;
        public event EventHandler<GameOverEventArgs> GameOver;
        public Model(Interface dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public void newGame(int n)
        {
            this.n = n;
            tableModel = new Table(n);
            _random = new Random();

            for (int i = 0; i < 16+1; i++)
            {
                for (int j = 0; j < n+2; j++)
                {
                    if (j == 0 || j == n + 1 || i == 16)
                    {
                        tableModel._table[i,j] = -1;
                    } else {
                        tableModel._table[i,j] = 0;
                    }
                }
            }

            ShapeMaker();
            Paused = false;

            Write();
        }

        public void ShapeMaker()
        {
            int r = _random.Next(4);

            _shape = new Shape(_random.Next(4));
            _shape.Write();

            int cBegin = n / 4;
            Pair tmp = new Pair(0, 0);
            HereIsTheShape = new Pair[] { tmp, tmp,tmp, tmp, tmp, tmp, tmp, tmp }; // elso 4 jelenlegi / utolso 4 elozo
            int p = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tableModel._table[i, cBegin + j] = _shape.Matrix[i, j];

                    if (tableModel._table[i, cBegin + j] == 1)
                    {
                        Pair _tmp = new Pair(i,cBegin + j);
                        HereIsTheShape[p] = _tmp;
                        Pair _Tmp = new Pair(i, cBegin + j);
                        HereIsTheShape[p+4] = _Tmp;
                        HereIsTheShape[i].Write();
                        p++;
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                HereIsTheShape[i].Write();
            }

        }

        #region Going somewhere or rotate

        public void FallDown()
        {
            //átmásoljuk jelenleg hol van, hogy le tudjuk majd nullázni
            for (int i = 4; i < 8; i++)
            {
                HereIsTheShape[i].x = HereIsTheShape[i - 4].x;
                HereIsTheShape[i].y = HereIsTheShape[i - 4].y;
            }

            // megadjuk az új értékeket, ha le lehet esni
            bool canFall = true;
            for (int i = 0; i < 4; i++)
            {
                if (!CanGo(HereIsTheShape[i].x + 1, HereIsTheShape[i].y))
                {
                    canFall = false;
                }
            }

            if (canFall)
            {
                for (int i = 0; i < 4; i++)
                {
                    HereIsTheShape[i].x = HereIsTheShape[i].x + 1;
                }

                // átvisszük az új pozíciókat a táblába
                for (int i = 4; i < 8; i++)
                {
                    tableModel._table[HereIsTheShape[i].x, HereIsTheShape[i].y] = 0;
                }

                for (int i = 0; i < 4; i++)
                {
                    tableModel._table[HereIsTheShape[i].x, HereIsTheShape[i].y] = 1;
                }

            }
            else
            {
                StopShape();
            }

            Write();

            // szólok a nézetnek, hogy megváltozott a tábla

            if (FieldChanged != null)
            {
                FieldChanged(this, new FieldChangedEventArgs());
            }
        


        }

        public void GoRight()
        {
            if (isPaused())
            {
                //átmásoljuk jelenleg hol van, hogy le tudjuk majd nullázni
                for (int i = 4; i < 8; i++)
                {
                    HereIsTheShape[i].x = HereIsTheShape[i - 4].x;
                    HereIsTheShape[i].y = HereIsTheShape[i - 4].y;
                }

                // megadjuk az új értékeket, ha lehet jobbra menni
                bool canGoRight = true;
                for (int i = 0; i < 4; i++)
                {
                    if (!CanGo(HereIsTheShape[i].x, HereIsTheShape[i].y + 1))
                    {
                        canGoRight = false;
                    }
                }

                if (canGoRight)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        HereIsTheShape[i].y = HereIsTheShape[i].y + 1;
                    }

                    // átvisszük az új pozíciókat a táblába
                    for (int i = 4; i < 8; i++)
                    {
                        tableModel._table[HereIsTheShape[i].x, HereIsTheShape[i].y] = 0;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        tableModel._table[HereIsTheShape[i].x, HereIsTheShape[i].y] = 1;
                    }

                }

                Write();

                // szólok a nézetnek, hogy megváltozott a tábla

                if (FieldChanged != null)
                {
                    FieldChanged(this, new FieldChangedEventArgs());
                }
            }
        }

        public void GoLeft()
        {
            if (isPaused())
            {
                //átmásoljuk jelenleg hol van, hogy le tudjuk majd nullázni
                for (int i = 4; i < 8; i++)
                {
                    HereIsTheShape[i].x = HereIsTheShape[i - 4].x;
                    HereIsTheShape[i].y = HereIsTheShape[i - 4].y;
                }

                // megadjuk az új értékeket, ha lehet jobbra menni
                bool canGoRight = true;
                for (int i = 0; i < 4; i++)
                {
                    if (!CanGo(HereIsTheShape[i].x, HereIsTheShape[i].y - 1))
                    {
                        canGoRight = false;
                    }
                }

                if (canGoRight)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        HereIsTheShape[i].y = HereIsTheShape[i].y - 1;
                    }

                    // átvisszük az új pozíciókat a táblába
                    for (int i = 4; i < 8; i++)
                    {
                        tableModel._table[HereIsTheShape[i].x, HereIsTheShape[i].y] = 0;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        tableModel._table[HereIsTheShape[i].x, HereIsTheShape[i].y] = 1;
                    }

                }

                Write();

                // szólok a nézetnek, hogy megváltozott a tábla

                if (FieldChanged != null)
                {
                    FieldChanged(this, new FieldChangedEventArgs());
                }
            }

        }

        public void Rotate()
        {
            if (isPaused())
            {

                _shape.Rotate();
                _shape.Write();

                // keressük a fenti bal oldali pontot közbe átmásoljuk hátra hol voltunk
                Pair begin = new Pair(n, 16);
                for (int i = 0; i < 4; i++)
                {
                    HereIsTheShape[i].Write();
                }
                for (int i = 0; i < 4; i++)
                {
                    if (HereIsTheShape[i].x < begin.x)
                    {
                        begin.x = HereIsTheShape[i].x;
                    }
                    if (HereIsTheShape[i].y < begin.y)
                    {
                        begin.y = HereIsTheShape[i].y;
                    }
                    System.Diagnostics.Debug.WriteLine("itt kezdodik " + begin.x + begin.y);
                    HereIsTheShape[i + 4].x = HereIsTheShape[i].x;
                    HereIsTheShape[i + 4].y = HereIsTheShape[i].y;
                }
                //ellenorzom hogy ahol lenne ott lehet e az alakzat és elmentem az első 4 helyre
                bool canRotate = true;
                int p = 0;
                System.Diagnostics.Debug.WriteLine("bemegyek a ciklusba 4 x 4");
                System.Diagnostics.Debug.WriteLine("ezen megyek vegeig");
                _shape.Write();
                System.Diagnostics.Debug.WriteLine("ezeken a helyeken van 1-es:");
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (_shape.Matrix[i, j] == 1)
                        {
                            System.Diagnostics.Debug.WriteLine(i + " " + j);

                            HereIsTheShape[p].x = i + begin.x;
                            HereIsTheShape[p].y = j + begin.y;
                            p++;
                            System.Diagnostics.Debug.WriteLine("Ebbe a kordinataban lesz a nagy table-ben:");
                            HereIsTheShape[p].Write();

                            if (!CanGo(begin.x + i, begin.x + j))
                            {
                                canRotate = false;
                                System.Diagnostics.Debug.WriteLine("nem tudok menni erre a helyre: ");
                                begin.Write();
                            }
                        }
                    }
                }
                // ha igen megcsinálom, ha nem, visszaírom a tömb első 4 elemét :
                // odaadom a tömbnek ezeket az új értékeket
                System.Diagnostics.Debug.WriteLine("tudok rotate? " + canRotate);
                if (canRotate)
                {
                    // lenullázom a jelenlegit és az újakra beírom az 1-eseket
                    for (int i = 4; i < 8; i++)
                    {
                        tableModel._table[HereIsTheShape[i].x, HereIsTheShape[i].y] = 0;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        tableModel._table[HereIsTheShape[i].x, HereIsTheShape[i].y] = 1;
                    }
                    System.Diagnostics.Debug.WriteLine("lenullázom a jelenlegit és az újakra beírom az 1-eseket");

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("else ág, tehat canrotate = false - bizonyitek: " + canRotate);
                    for (int i = 0; i < 4; i++)
                    {
                        HereIsTheShape[i].x = HereIsTheShape[i + 4].x;
                        HereIsTheShape[i].y = HereIsTheShape[i + 4].y;
                    }
                    System.Diagnostics.Debug.WriteLine("visszaállitottam az elso 4 elemet a régire");
                }

                // szólok a nézetnek, hogy megváltozott a tábla

                if (FieldChanged != null)
                {
                    FieldChanged(this, new FieldChangedEventArgs());
                }
                System.Diagnostics.Debug.WriteLine("rotate vége");
            }
        } 

        public bool CanGo(int x,int y) /// egesz sorra kell
        {
            if (x < 0 || x > 16 || y < 0 || y > n)
            {
                return false;
            }
            if (tableModel._table[x,y] == 0 || tableModel._table[x, y] == 1)
            {
                return true;
            } else
            {
                //if (tableModel._table[x, y] == -1 || tableModel._table[x, y] == 2)
                return false;
            }

        }

        #endregion

        //#region 
        public void StopShape()
        {
            Pair rows = new Pair(0, 16);
            // ahol van  jelenleg a shape, ott átváltoztatjuk az értékeit 2-re és csinálunk egy új alakzatot
            for (int i = 0; i < 4; i++)
            {
                tableModel._table[HereIsTheShape[i].x, HereIsTheShape[i].y] = 2;
                if (HereIsTheShape[i].x < rows.x)
                {
                    rows.x = HereIsTheShape[i].x;
                }
                if (HereIsTheShape[i].x > rows.x)
                {
                    rows.y = HereIsTheShape[i].y;
                }

            }

            CheckGame();
            ShapeMaker();

        }

        

        public void CheckGame()
        {
            for (int i = 0; i < 16; i++)
            {
                bool isFull = true;
                for (int j = 0; j < n + 2; j++)
                {
                    if (Table._table[i,j] !=2 && Table._table[i, j] != -1)
                    {
                        isFull = false;
                    }
                }

                if (isFull)
                {
                    DeleteRow(i);
                }
            }

            for (int i = 0; i < n+2; i++)
            {
                if (Table._table[2, i] == 2)
                {
                    Pause();
                    End();
                }
            }
        }
        public void DeleteRow(int x)
        {
            for (int i = x ; i > 0; i--)
            {
                for (int j = 0; j < n + 2; j++)
                {
                    Table._table[i, j] = Table._table[i - 1, j];
                }
                
            }

            // szólok a nézetnek, hogy megváltozott a tábla
            if (FieldChanged != null) { FieldChanged(this, new FieldChangedEventArgs()); }

        }
        

        public void End()
        {
             GameOver(this, new GameOverEventArgs());

        }
        public void Write()
        {
            for (int i = 0; i < 16+1; i++)
            {
                for (int j = 0; j < n+2; j++)
                {
                    System.Diagnostics.Debug.Write(tableModel._table[i, j] + " ");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
            System.Diagnostics.Debug.WriteLine("");
        }

        public async Task SaveGameAsync(String path)
        {
            if (dataAccess == null)
                throw new InvalidOperationException("No data access is provided");

            await dataAccess.SaveAsync(path, tableModel);
        }

        public async Task LoadGameAsync(String path)
        {
            if (dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            tableModel = await dataAccess.LoadAsync(path);
            newGame(tableModel._size.x);
            tableModel = await dataAccess.LoadAsync(path);
        }

    }

}
