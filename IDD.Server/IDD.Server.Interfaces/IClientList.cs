using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Server.Interfaces
{
    public interface IClientList : IEnumerable<IConnectionModel>
    {
        IConnectionModel Add(Socket client);
        int getNextAvailableClientId();
    }
}
