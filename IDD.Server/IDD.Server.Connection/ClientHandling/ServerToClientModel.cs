using IDD.Global.Interfaces;
using IDD.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Server.ClientHandling
{
    public class ServerToClientModel : IConnectionModel
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public Socket Socket { get; set; }
    }
}
