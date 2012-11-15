
using IDD.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Client.Interfaces
{
    public interface IConnector
    {
        void Connect(IClientToServerModel conn);
    }
}
