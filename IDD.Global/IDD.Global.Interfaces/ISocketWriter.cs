using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public interface ISocketWriter
    {

        void SendStream(PaketType type,Stream content, int id, Socket socket);
        void SendBytes(PaketType type, byte[] content, int id, Socket socket);
        void SendMessage(PaketType type, string content, int id, Socket socket);
        void SendInt(PaketType type, int content, int id, Socket socket);
    }
}
