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
            easyButton.Font = Data.MainFont;
            mediumButton.Font = Data.MainFont;
            hardButton.Font = Data.MainFont;
        }

        private void DifficultyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {

        }

        private void mediumButton_Click(object sender, EventArgs e)
        {

        }

        private void hardButton_Click(object sender, EventArgs e)
        {

        }
    }
}
