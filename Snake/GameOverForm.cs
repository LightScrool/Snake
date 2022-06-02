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
    public partial class GameOverForm : Form
    {
        public GameOverForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(Program.OnFormClosing);
            titleLable.Font = Data.GetMainFont();
            scoreLabel.Font = Data.GetMainFont(18);
            scoreLabel.Text = $"Your score: {CurrentGameData.Score}";
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
        }
    }
}
