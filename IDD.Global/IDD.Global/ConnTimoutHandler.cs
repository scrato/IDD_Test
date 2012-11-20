using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global
{
    public class ConnTimoutHandler : IConnTimeoutHandler
    {
        public Socket Socket { get; set; } 
        public void SendMessage(Socket socket)
        {
            throw new NotImplementedException();
        }

        public void HandleMessage(byte[] content, int id)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
