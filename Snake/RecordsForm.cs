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
    public partial class RecordsForm : Form
    {
        public RecordsForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(Program.OnFormClosing);
            InitRecordLabels();
        }

        private void InitRecordLabels()
        {
            const int x = 310;
            const int startY = 90;
            const int difY = 30;
            const int fontSize = 18;
            const int width = 100;
            const int height = 30;
            Color textColor = Color.FromArgb(191, 184, 109);

            List<Label> labelList = new List<Label>();
            for (int i = 0; i < Data.RecordList.Count; i++)
            {
                Label label = new Label();
                panel1.Controls.Add(label);

                label.AutoSize = false;
                label.Size = new Size(width, height);
                label.Location = new Point(x, startY + difY * (i));

                label.Text = $"{i + 1}. {Data.RecordList[i]}";
                label.Font = Data.GetMainFont(fontSize);
                label.ForeColor = textColor;

                labelList.Add(label);
            }
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
        }
    }
}
