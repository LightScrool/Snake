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
    public partial class DifficultyForm : Form
    {
        public DifficultyForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(Program.OnFormClosing);
            easyButton.Font = Data.GetMainFont();
            mediumButton.Font = Data.GetMainFont();
            hardButton.Font = Data.GetMainFont();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            CurrentGameData.SnakeSpeed = Data.SnakeSpeedVariants[0];
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            CurrentGameData.SnakeSpeed = Data.SnakeSpeedVariants[1];
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            CurrentGameData.SnakeSpeed = Data.SnakeSpeedVariants[2];
            this.Hide();
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }
    }
}
