using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Model;
using Tetris.Persistence;

namespace Tetris
{
    public partial class View : Form
    {
        private Button[,] _buttonGrid;
        private Tetris.Model.Model _model;
        private Interface _dataAccess;
        private int size;


        #region Start the game ( + Generate the Table)
        public View()
        {
            InitializeComponent();

            newGame(8);

            size = 8;

        }

        
        public void newGame(int n)
        {
            tableLayoutPanel.Controls.Clear();
            _dataAccess = new DataAccess();
            _model = new Tetris.Model.Model(_dataAccess);
            _model.newGame(n);
            GenerateTable(n);
            RefreshTable();
            timer.Start();
            newGameButton4.BackColor = Color.FromArgb(39, 17, 64);
            newGameButton4.ForeColor = Color.FromArgb(255, 255, 255);
            newGameButton8.BackColor = Color.FromArgb(39, 17, 64);
            newGameButton8.ForeColor = Color.FromArgb(255, 255, 255);
            newGameButton12.BackColor = Color.FromArgb(39, 17, 64);
            newGameButton12.ForeColor = Color.FromArgb(255, 255, 255);

            saveButton.BackColor = Color.FromArgb(39, 17, 64);
            saveButton.ForeColor = Color.FromArgb(255, 255, 255);

            loadButton.BackColor = Color.FromArgb(39, 17, 64);
            loadButton.ForeColor = Color.FromArgb(255, 255, 255);

            pauseButton.BackColor = Color.FromArgb(64, 17, 44);
            pauseButton.ForeColor = Color.FromArgb(255, 255, 255);


            LeftButton.BackColor = Color.FromArgb(171, 96, 139);
            LeftButton.ForeColor = Color.FromArgb(255, 255, 255);

            RightButton.BackColor = Color.FromArgb(171, 96, 139);
            RightButton.ForeColor = Color.FromArgb(255, 255, 255);

            rotateButton.BackColor = Color.FromArgb(171, 96, 139);
            rotateButton.ForeColor = Color.FromArgb(255, 255, 255);


            _model.FieldChanged += new EventHandler<FieldChangedEventArgs>(Model_FieldChanged);
            _model.GameOver += new EventHandler<GameOverEventArgs>(GameOver);


        }

        private void Model_FieldChanged(object sender, FieldChangedEventArgs e)
        {
            RefreshTable();
        }

        public void GenerateTable(int n)
        {
            tableLayoutPanel.RowCount = 16+1;
            tableLayoutPanel.ColumnCount = n+2;

            _buttonGrid = new Button[16+1, n+2];

            for (int i = 0; i < 16+1; i++)
            {
                for (int j = 0; j < n+2; j++)
                {

                    _buttonGrid[i, j] = new GridButton(i, j);
                    _buttonGrid[i, j].Enabled = false;
                    _buttonGrid[i, j].Dock = DockStyle.Fill;
                    _buttonGrid[i, j].BackColor = Color.White;
                    //_buttonGrid[i, j].MouseClick += new MouseEventHandler(ButtonGrid_MouseClick);

                    tableLayoutPanel.Controls.Add(_buttonGrid[i, j], j, i);
                }

            }

            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();

            for (Int32 i = 0; i < 16+1; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 1 / Convert.ToSingle(16)));
                // a sorok és oszlopok egyenlően, arányosan méreteződnek
            }
            for (Int32 j = 0; j < n+2; j++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1 / Convert.ToSingle(n)));
            }
        }

        private void View_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Button Clicks ( New Game + Pause + Arrows)
        private void newGameButton4_Click(object sender, EventArgs e)
        {
            this.size = 4;
            newGame(4);
        }
        private void newGameButton8_Click(object sender, EventArgs e)
        {
            this.size = 8;
            newGame(8);
        }
        private void newGameButton12_Click(object sender, EventArgs e)
        {
            this.size = 12;
            newGame(12);
        }
        private void pauseBbutton_Click(object sender, EventArgs e)
        {
            _model.Pause();
            if (_model.isPaused())
            {
                pauseButton.Text = " PAUSE ";
            }
            else
            {
                pauseButton.Text = " START ";
            }
        }
        private void RightButton_Click(object sender, EventArgs e)
        {
            _model.GoRight();
        }
        private void LeftButton_Click(object sender, EventArgs e)
        {
            _model.GoLeft();
        }
        private void rotateButton_Click(object sender, EventArgs e)
        {
            _model.Rotate();
        }
        

        #endregion

        #region The game is going on

        public void RefreshTable()
        {
            Color shapeColor = Color.FromArgb(118, 46, 132);
            Color basicColor = Color.FromArgb(226, 176, 255);
            Color frameColor = Color.FromArgb(74, 44, 84);
            for (int i = 0; i < _buttonGrid.GetLength(0); i++)
            {
                for (int j = 0; j < _buttonGrid.GetLength(1); j++)
                {
                    if (_model.Table.GetValue(i,j) == -1 )
                    {
                        _buttonGrid[i, j].BackColor = frameColor;
                    }
                    if (_model.Table.GetValue(i, j) == 1 || _model.Table.GetValue(i, j) == 2 )
                    {
                        _buttonGrid[i, j].BackColor = shapeColor;
                    }
                    if (_model.Table.GetValue(i, j) == 0)
                    {
                        _buttonGrid[i, j].BackColor = basicColor;
                    }
                }
            }
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (_model.isPaused())
            {
                //_model._ticks++;
                _model.Table._tick++;
                _model._ticks = _model.Table._tick;
                timeTextBox.Text = " ⏱️ " + _model._ticks.ToString() + " sec ";
                _model.FallDown();
            }
        }



        #endregion

        public void GameOver(object sender, GameOverEventArgs e)
        {
            
            MessageBox.Show("Time: " + _model._ticks.ToString(), "Game over!");
            newGame(_model.n);
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            if (!_model.isPaused())
            {
                if (_saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await _model.SaveGameAsync(_saveFileDialog.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Saving the game was unsuccessfull!" + Environment.NewLine + "Wrong path or libary can't be writeable.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void loadButton_Click(object sender, EventArgs e)
        {
            if (!_model.isPaused())
            {
                if (_openFileDialog.ShowDialog() == DialogResult.OK) // ha kiválasztottunk egy fájlt
                {
                    try
                    {
                        // játék betöltése
                        await _model.LoadGameAsync(_openFileDialog.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Game loading was unsuccessfull!" + Environment.NewLine + "Worng path or file type", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        _model.newGame(size);
                    }

                    tableLayoutPanel.Controls.Clear();

                    GenerateTable(size);

                    RefreshTable();
                }
            }
        }
    }
}
