using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(Program.OnFormClosing);

            this.Controls.Add(gamePanel);
            Data.InitSizes(gamePanel);
            CurrentGameData.GamePanel = gamePanel;
            CurrentGameData.ScoreLabel = scoreLabel;

            CurrentGameData.Score = 0;
            CurrentGameData.CurrentSnake = new Snake();
            CurrentGameData.GenerateApples();

            timer.Tick += new EventHandler(GameTick);
            timer.Interval = 1000 / CurrentGameData.SnakeSpeed;
            timer.Start();
        }

        private void GameTick(object sender, EventArgs e)
        {
            CurrentGameData.CurrentSnake.Move();
            if (!CurrentGameData.CurrentSnake.IsAlive)
            {
                timer.Stop();
                CurrentGameData.AppleList = new List<Block>();
                Data.AddScoreToRecords(CurrentGameData.Score);
                this.Hide();
                GameOverForm gameOverForm = new GameOverForm();
                gameOverForm.Show();
            }
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            CurrentGameData.CurrentSnake.Direction = e.KeyData.ToString();
        }
    }
}
