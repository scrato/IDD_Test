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
    public partial class MainView : Form, IMessageOutput
    {
        private IClientToServerModel _conn;
        private IAppContext _appContext;
        public MainView(IAppContext appContext)
        {
            InitializeComponent();
            _appContext = appContext;
            _conn = _appContext.GetObject<IClientToServerModel>();
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
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            say(tbText.Text);
            tbText.Clear();
        }       


        public void addText(string text, string username)
        {
            string result = String.Empty;
            result += "[" + DateTime.Now.ToShortTimeString() + "-" + username +"]: ";
            result += text;


            lbChat.Items.Add(result);
        }

        private void addUser(string username)
        {
            lbChat.Items.Add("Der User " + username +" hat den Chat betreten");
            lbUser.Items.Add(username);
        }

        private void tbText_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (tbText.Text != String.Empty))
            {
                say(tbText.Text);
                tbText.Clear();
            }
        }

        public void showText(OutputType type, string text)
        {
            throw new NotImplementedException();
        }
    }
}
