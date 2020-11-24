using HydraClassLibrary.Cloud;
using System;
using System.Windows.Forms;

namespace HydraClient
{
    static class Program
    {
        public static SessionInfo sessionInfo = new SessionInfo();
        public static ICloud cloudConnection = new LocalCloud();
        //public static CloudConnection cloudConnection = new CloudConnection("127.0.0.1", 8001);
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
