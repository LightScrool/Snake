using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Snake
{
    internal static class Data
    {
        // Константы
        private static string fontFile = "./data/Showcard Gothic.ttf";
        private static int fontSize = 28;
        private static int blocksInField = 20;
        private static Color headColor = Color.FromArgb(188, 185, 114); // #BCB972;
        private static Color bodyColor = Color.FromArgb(237, 233, 176); // #EDE9B0;
        private static Color appleColor = Color.FromArgb(144, 71, 28); // #90471C;
        private static int[] snakeSpeedVariant = {8, 16, 24};
        private static int startSnakeLength = 3;
        private static int appleNumber = 3;

        public static int BlocksInField { get => blocksInField; }
        public static Color HeadColor { get => headColor; }
        public static Color BodyColor { get => bodyColor; }
        public static Color AppleColor { get => appleColor; }
        public static int[] SnakeSpeeds { get => snakeSpeedVariant; }
        public static int StartSnakeLength { get => startSnakeLength; }
        public static int AppleNumber { get => appleNumber; }

        // Инициализируемые поля
        private static Font mainFont;
        private static int gamePanelWidth;
        private static int gamePanelHeight;
        private static int blockWidth;
        private static int blockHeight;

        public static Font MainFont { get => mainFont; }
        public static int GamePanelWidth { get => gamePanelWidth; }
        public static int GamePanelHeight { get => gamePanelHeight; }
        public static int BlockWidth { get => blockWidth; }
        public static int BlockHeight { get => blockHeight; }

        // Свободно изменяемые поля
        public static int SnakeSpeed { get; set; }

        // Методы
        public static void LoadFont()
        {
            PrivateFontCollection customFont = new PrivateFontCollection();
            customFont.AddFontFile(fontFile);
            mainFont = new Font(customFont.Families[0], fontSize);
        }

        public static void InitSizes(Panel gamePanel)
        {
            gamePanelWidth = gamePanel.Width;
            gamePanelHeight = gamePanel.Height;
            blockWidth = GamePanelWidth / BlocksInField;
            blockHeight = GamePanelHeight / BlocksInField;
        }
    }
}
