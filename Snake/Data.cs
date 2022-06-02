using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.IO;

namespace Snake
{
    internal static class Data
    {
        // Константы
        private static string fontFile = "./data/Showcard Gothic.ttf";
        private static string recordsFile = "./data/records.txt";
        private static int blocksInField = 20;
        private static Color headColor = Color.FromArgb(188, 185, 114); // #BCB972;
        private static Color bodyColor = Color.FromArgb(237, 233, 176); // #EDE9B0;
        private static Color appleColor = Color.FromArgb(144, 71, 28); // #90471C;
        private static int[] snakeSpeedVariants = {6, 8, 10}; // Скорости на разных уровнях сложности
        private static int startSnakeLength = 3;
        private static int appleNumber = 3;

        public static int BlocksInField { get => blocksInField; }
        public static Color HeadColor { get => headColor; }
        public static Color BodyColor { get => bodyColor; }
        public static Color AppleColor { get => appleColor; }
        public static int[] SnakeSpeedVariants { get => snakeSpeedVariants; }
        public static int StartSnakeLength { get => startSnakeLength; }
        public static int AppleNumber { get => appleNumber; }

        // Инициализируемые поля
        private static int gamePanelWidth;
        private static int gamePanelHeight;
        private static int blockWidth;
        private static int blockHeight;
        private static List<int> recordList;

        public static int GamePanelWidth { get => gamePanelWidth; }
        public static int GamePanelHeight { get => gamePanelHeight; }
        public static int BlockWidth { get => blockWidth; }
        public static int BlockHeight { get => blockHeight; }
        public static List<int> RecordList { get => recordList; }

        // Методы
        public static void InitSizes(Panel gamePanel)
        {
            gamePanelWidth = gamePanel.Width;
            gamePanelHeight = gamePanel.Height;
            blockWidth = GamePanelWidth / BlocksInField;
            blockHeight = GamePanelHeight / BlocksInField;
        }

        public static Font GetMainFont(int size = 28)
        {
            PrivateFontCollection customFont = new PrivateFontCollection();
            customFont.AddFontFile(fontFile);
            return new Font(customFont.Families[0], size);
        }

        public static void LoadRecords()
        {
            if (recordList == null)
                recordList = new List<int>();

            StreamReader sr = new StreamReader(recordsFile);

            string line = sr.ReadLine();
            while (line != null)
            {
                recordList.Add(int.Parse(line));
                line = sr.ReadLine();
            }

            recordList.Sort();
            recordList.Reverse();

            sr.Close();
            Console.ReadLine();
        }

        public static void SaveRecords()
        {
            if (RecordList == null)
                return;

            StreamWriter sw = new StreamWriter(recordsFile, false);

            foreach (int record in RecordList)
            {
                string line = record.ToString();
                sw.WriteLine(line);
            }

            sw.Close();
        }

        public static void AddScoreToRecords(int score)
        {
            if (recordList.Count < 10)
            {
                recordList.Add(score);
                recordList.Sort();
                recordList.Reverse();
                return;
            }

            if (score < recordList.Last())
                return;

            int prevValue = score;
            for (int i = 0; i < recordList.Count; i++)
            {
                if (recordList[i] < prevValue)
                {
                    int temp = prevValue;
                    prevValue = recordList[i];
                    recordList[i] = temp;
                }
            }
        }
    }
}
