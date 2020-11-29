using System;
using System.Windows.Forms;

namespace HydraClient
{
    static class Program
    {
        public static SessionInfo sessionInfo;
        public static MainForm main;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            sessionInfo = new SessionInfo(new CloudConnection("127.0.0.1", 8001));
            main = new MainForm();
            Application.Run(main);
        }
    }
}
