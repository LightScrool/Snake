using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal class Snake
    {
        private List<Block> blockList = new List<Block>();
        private string direction;
        private bool isAlive;

        public int Length { get => blockList.Count; }

        public string Direction
        {
            get => direction;

            set
            {
                if (value != "Up"
                && value != "Down"
                && value != "Right"
                && value != "Left")
                {
                    return;
                }
                if (value == "Up" && Direction == "Down"
                || value == "Down" && Direction == "Up"
                || value == "Right" && Direction == "Left"
                || value == "Left" && Direction == "Right")
                {
                    return;
                }
                direction = value;
            }
        }

        public bool IsAlive { get => isAlive;}

        public Snake()
        {
            isAlive = true;
            Direction = "Right";

            int y = Data.BlocksInField / 2;
            int x = (Data.BlocksInField - Data.StartSnakeLength) / 2 + Data.StartSnakeLength / 2;
            blockList.Add(new Block(x--, y, Data.HeadColor));

            for (int i = 1; i < Data.StartSnakeLength; i++)
            {
                blockList.Add(new Block(x--, y, Data.BodyColor));
            }
        }

        public void Move()
        {
            int newPosX = blockList[0].X;
            int newPosY = blockList[0].Y;

            blockList[0].Move(Direction);

            // Каждый блок с индексом i >= 1 встаёт на место блока с индексом i-1
            for (int i = 1; i < blockList.Count; i++)
            {
                int posX = blockList[i].X;
                int posY = blockList[i].Y;
                blockList[i].MoveTo(newPosX, newPosY);

                newPosX = posX;
                newPosY = posY;
            }

            DeathCheck();
            EatAppleCheck();
        }

        public void DeathCheck()
        {
            Block head = blockList[0];

            bool wallsCheck = head.X >= 0
                && head.Y >= 0
                && head.X < Data.BlocksInField
                && head.Y < Data.BlocksInField;

            int lastHeadCoords = blockList.FindLastIndex(block => block.X == head.X && block.Y == head.Y);
            
            isAlive = wallsCheck && (lastHeadCoords == 0);
        }

        public void EatAppleCheck()
        {
            if (CurrentGameData.AppleList == null)
                return;

            // В отличие от SelfEatenCheck, съедение яблок проверяется по хвосту, а не по голове змейки
            int tailIndex = blockList.Count - 1;
            int tailX = blockList[tailIndex].X;
            int tailY = blockList[tailIndex].Y;

            int n = CurrentGameData.AppleList.Count;
            for (int i = 0; i < n; i++)
            {
                Block apple = CurrentGameData.AppleList[i];
                if (apple.X == tailX && apple.Y == tailY)
                {
                    CurrentGameData.Score++;
                    apple.DestructBlock();
                    CurrentGameData.AppleList.RemoveAt(i);
                    CurrentGameData.GenerateApples();
                    blockList.Add(new Block(tailX, tailY, Data.BodyColor));
                }
            }
        }

        public bool Exists(Predicate<Block> match)
        {
            return blockList.Exists(match);
        }
    }
}
