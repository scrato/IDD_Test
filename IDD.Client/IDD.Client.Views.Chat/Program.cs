using IDD.Global.Interfaces;
using IDD.Client.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDD.Client.Views.Chat
{
    static class Program
    {
        public static IAppContext AppContext { get; private set; }
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

            
            AppContext = new AppContext();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainView(AppContext));
        }
    }
}
