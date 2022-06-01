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
        private Block a;

        public GameForm()
        {
            InitializeComponent();
            Data.InitSizes(gamePanel);
            this.Controls.Add(gamePanel);
            a = new Block(1, 1, gamePanel, Data.BodyColor);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            a.Move(e.KeyData.ToString());
        }
    }
}
