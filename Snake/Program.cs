using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Snake
{
    internal static class Program
    {
        public static Font mainFont;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            LoadFont();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm());
        }

        public static void LoadFont()
        {
            const string fontFile = "Showcard Gothic.ttf";
            const int fontSize = 28;

            PrivateFontCollection customFont = new PrivateFontCollection();
            customFont.AddFontFile(fontFile);
            mainFont = new Font(customFont.Families[0], fontSize);
        }
    }
}
