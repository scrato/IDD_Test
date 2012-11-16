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
        private static IAppContext _context;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {



            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            _context = new AppContext();
            MainView view = new MainView(_context);
            _context.AddObject<IMessageOutput>(view);


            System.Windows.Forms.Application.Run(view);
        }
    }
}
