using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using IDD.Global;
using System.Threading;
using IDD.Global.Interfaces;
using IDD.Client.Interfaces;
namespace IDD.Client
{
    public partial class MainView : FormMessageOutput
    {
        private IClientToServerModel _conn;
        private IAppContext _appContext;
        public MainView(IAppContext appContext)
        {
            InitializeComponent();
            _appContext = appContext;
            _conn = (IClientToServerModel)_appContext.GetObject<IConnectionModel>();
            _conn.IP = "127.0.0.1";
            _conn.Port = 51414;
            _conn.Username = "Default";
        }





        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verbindenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionWindow window = new ConnectionWindow(_conn);
            if (window.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _appContext.GetObject<IConnector>().Connect(_conn);
            }
        }


        private void say(string p)
        {
            IModuleHandler module = _appContext.GetAllObjects<IModuleHandler>()
                                    .Where(x => x.HandleType == PaketType.Message)
                                    .FirstOrDefault();
            module.Do(p);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            say(tbText.Text);
            tbText.Clear();
        }


        public override void showText(OutputType type, params string[] text)
        {
            string result = String.Empty;
            switch (type)
            {
                case OutputType.Message:
                    lbChat.Items.Add("[" + DateTime.Now.ToShortTimeString() + "-" + text[0] + "]: " + text[1]);
                    break;
                case OutputType.InitializionInfo:
                    foreach (string user in text)
                    {
                        lbUser.Items.Add(user);
                    }
                    break;
                case OutputType.Error:
                    break;
                case OutputType.NewPlayer:
                    lbChat.Items.Add("[Spieler " + text[0] + " ist dazugekommen]");
                    break;
                default:
                    break;
            }
        }

        private void tbText_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (tbText.Text != String.Empty))
            {
                say(tbText.Text);
                tbText.Clear();
            }
        }

    }
}
