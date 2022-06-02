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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            label1.Font = Data.GetMainFont();
            startButton.Font = Data.GetMainFont();
            recordsButton.Font = Data.GetMainFont();
            exitButton.Font = Data.GetMainFont();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DifficultyForm difficultyForm = new DifficultyForm();
            difficultyForm.Show();
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
