using IDD.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Client.Model
{
    public class ClientToServerModel : IClientToServerModel
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }

        public int Id { get; set; }

        public Socket Socket { get; set; } 
    }
}
