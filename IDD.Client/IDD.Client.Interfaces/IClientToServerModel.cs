using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Client.Interfaces
{
    public interface IClientToServerModel : IConnectionModel
    {
         string IP { get; set; }
         int Port { get; set; }
    }
}
