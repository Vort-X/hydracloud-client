using HydraClassLibrary;
using HydraClassLibrary.Cloud;
using System;
using System.Windows.Forms;

namespace HydraClient
{
    static class Program
    {
        public static SessionInfo sessionInfo = new SessionInfo();
        public static ICloud cloudConnection = new LocalCloud();
        public static MainForm main;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            main = new MainForm();
            Application.Run(main);
        }
    }
}
