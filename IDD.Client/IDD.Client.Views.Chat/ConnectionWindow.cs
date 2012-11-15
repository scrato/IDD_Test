using IDD.Client.Interfaces;
using IDD.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDD.Client
{
    public partial class ConnectionWindow : Form
    {
        private Binding ipBinding;
        private Binding portBinding;
        public ConnectionWindow(IClientToServerModel config)
        {
            InitializeComponent();
             ipBinding = new Binding("Text", config, "IP");
             portBinding  = new Binding("Text", config, "Port");

             tbIP.DataBindings.Add(ipBinding);
             tbPort.DataBindings.Add(portBinding);
             tbNick.DataBindings.Add(new Binding("Text", config, "Username"));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void tbNick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Connect();
            }
        }


    }
}
