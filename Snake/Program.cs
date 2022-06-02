using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Data.LoadRecords();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm());
        }

        public static void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Data.SaveRecords();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
