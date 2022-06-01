using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class Block: PictureBox
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set
            {
                x = value;
                this.Location = new System.Drawing.Point(x * Data.BlockWidth,
                    this.Location.Y);
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                this.Location = new System.Drawing.Point(this.Location.X,
                    y * Data.BlockWidth);
            }
        }

        public Block(int _x, int _y, Panel gamePanel, System.Drawing.Color color)
        {
            gamePanel.Controls.Add(this);

            this.Size = new System.Drawing.Size(Data.BlockWidth, Data.BlockHeight);
            this.BackColor = color;
            X = _x;
            Y = _y;
        }

        public new void Move(string direction)
        {
            switch (direction)
            {
                case "Up":
                    Y -= 1;
                    break;
                case "Down":
                    Y += 1;
                    break;
                case "Right":
                    X += 1;
                    break;
                case "Left":
                    X -= 1;
                    break;
            }
        }

        public void MoveTo(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
    }
}
