namespace Tetris
{
    partial class View
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.newGameButton4 = new System.Windows.Forms.Button();
            this.newGameButton8 = new System.Windows.Forms.Button();
            this.newGameButton12 = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.pauseButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.rotateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Location = new System.Drawing.Point(6, 58);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(313, 658);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // newGameButton4
            // 
            this.newGameButton4.Location = new System.Drawing.Point(15, 12);
            this.newGameButton4.Name = "newGameButton4";
            this.newGameButton4.Size = new System.Drawing.Size(94, 29);
            this.newGameButton4.TabIndex = 1;
            this.newGameButton4.Text = "4 x 16";
            this.newGameButton4.UseVisualStyleBackColor = true;
            this.newGameButton4.Click += new System.EventHandler(this.newGameButton4_Click);
            // 
            // newGameButton8
            // 
            this.newGameButton8.Location = new System.Drawing.Point(115, 12);
            this.newGameButton8.Name = "newGameButton8";
            this.newGameButton8.Size = new System.Drawing.Size(94, 29);
            this.newGameButton8.TabIndex = 2;
            this.newGameButton8.Text = "8 x 16";
            this.newGameButton8.UseVisualStyleBackColor = true;
            this.newGameButton8.Click += new System.EventHandler(this.newGameButton8_Click);
            // 
            // newGameButton12
            // 
            this.newGameButton12.Location = new System.Drawing.Point(215, 12);
            this.newGameButton12.Name = "newGameButton12";
            this.newGameButton12.Size = new System.Drawing.Size(94, 29);
            this.newGameButton12.TabIndex = 3;
            this.newGameButton12.Text = "12 x 16";
            this.newGameButton12.UseVisualStyleBackColor = true;
            this.newGameButton12.Click += new System.EventHandler(this.newGameButton12_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timeTextBox
            // 
            this.timeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.timeTextBox.Enabled = false;
            this.timeTextBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeTextBox.Location = new System.Drawing.Point(339, 121);
            this.timeTextBox.Multiline = true;
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.ReadOnly = true;
            this.timeTextBox.Size = new System.Drawing.Size(93, 117);
            this.timeTextBox.TabIndex = 4;
            this.timeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseButton.Location = new System.Drawing.Point(339, 12);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(93, 44);
            this.pauseButton.TabIndex = 5;
            this.pauseButton.Text = " START ";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseBbutton_Click);
            // 
            // LeftButton
            // 
            this.LeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LeftButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LeftButton.Location = new System.Drawing.Point(343, 281);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(38, 34);
            this.LeftButton.TabIndex = 6;
            this.LeftButton.Text = "<";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RightButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RightButton.Location = new System.Drawing.Point(388, 281);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(38, 34);
            this.RightButton.TabIndex = 7;
            this.RightButton.Text = ">";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // rotateButton
            // 
            this.rotateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rotateButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rotateButton.Location = new System.Drawing.Point(365, 321);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(38, 34);
            this.rotateButton.TabIndex = 6;
            this.rotateButton.Text = "🔄";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(340, 442);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(77, 33);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.Location = new System.Drawing.Point(340, 481);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(77, 29);
            this.loadButton.TabIndex = 9;
            this.loadButton.Text = "load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.Filter = "Tetris (*.stl)|*.stl";
            this._saveFileDialog.Title = "Tetris game save";
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "Tetris (*.stl)|*.stl";
            this._openFileDialog.Title = "Tetris game load";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 728);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.rotateButton);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.newGameButton12);
            this.Controls.Add(this.newGameButton8);
            this.Controls.Add(this.newGameButton4);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "View";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button newGameButton4;
        private System.Windows.Forms.Button newGameButton8;
        private System.Windows.Forms.Button newGameButton12;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;

        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
    }
}

