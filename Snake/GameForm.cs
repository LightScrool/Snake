using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            this.Controls.Add(gamePanel);
            Data.InitSizes(gamePanel);
            CurrentGameData.GamePanel = gamePanel;

            CurrentGameData.SnakeSpeed = Data.SnakeSpeedVariants[0];
            CurrentGameData.CurrentSnake = new Snake();
            CurrentGameData.GenerateApples();


        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            CurrentGameData.CurrentSnake.Direction = e.KeyData.ToString();
            CurrentGameData.CurrentSnake.Move();
        }
    }
}
