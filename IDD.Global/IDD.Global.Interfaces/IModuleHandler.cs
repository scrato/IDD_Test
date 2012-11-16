using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public interface IModuleHandler
    {
         PaketType HandleType { get; }
         void HandleMessage(byte[] content, int id, Socket socket, params object[] args);
         void Do(params object[] args);
//void HandleMessage(byte[] content, int id, Socket socket);
         //void Do(params object[] args);
         
        
    }
}
