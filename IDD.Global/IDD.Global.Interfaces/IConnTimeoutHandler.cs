using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public interface IConnTimeoutHandler
    {
        void Start();
        TimerCallback Callback
    void SendMessage(Socket socket);
    void HandleMessage(byte[] content, int id);    
    }
}
