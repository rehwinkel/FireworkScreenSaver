using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaverRemastered
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShowScreenSaver();
            Application.Run();
        }

        static void ShowScreenSaver()
        {
            foreach (Screen s in Screen.AllScreens)
            {
                Form1 form = new Form1(s.Bounds);
                form.Show();
            }
        }
    }
}
