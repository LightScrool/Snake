using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal static class CurrentGameData
    {
        public static List<Block> AppleList { get; set; }
        public static int Score { get; set; }
        public static Snake CurrentSnake { get; set; }
        public static Panel GamePanel { get; set; }
        public static int SnakeSpeed { get; set; }
        public static void GenerateApples()
        {
            if (CurrentGameData.AppleList == null)
                CurrentGameData.AppleList = new List<Block>();

            Random rnd = new Random();
            int n = Data.AppleNumber - AppleList.Count;
            for (int i = 0; i < n; i++)
            {
                int x = rnd.Next(Data.BlocksInField);
                int y = rnd.Next(Data.BlocksInField);

                if (!(CurrentSnake.Exists(block => block.X == x && block.Y == y))
                    && !(AppleList.Exists(block => block.X == x && block.Y == y)))
                {
                    AppleList.Add(new Block(x, y, Data.AppleColor));
                }
            }
        }
    }
}
