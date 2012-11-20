using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Server.Interfaces
{
    public  interface ICommunicationStarter
    {
          void Connect();
        
    }
}
