using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public interface IConnectionModel
    {
        Socket Socket { get; set; }
        string Username { get; set; }
        int Id { get; set; }
    }
}
