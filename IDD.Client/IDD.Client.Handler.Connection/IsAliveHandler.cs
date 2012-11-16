using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Client.Handler.Connection
{
    public class IsAliveHandler : IModuleHandler
    {
        IAppContext _context;

        public IsAliveHandler(IAppContext context)
        {
            _context = context;
        }
        public PaketType HandleType
        {
            get { return PaketType.IsAliveRequest; }
        }

        public void HandleMessage(byte[] content, int id, Socket socket, params object[] args)
        {
            Stopwatch watch = (Stopwatch) args[0];
            int myid = _context.GetObject<IConnectionModel>().Id;
            watch.Restart();
            _context.GetObject<ISocketWriter>().SendTime(PaketType.IsAliveRequest, watch.ElapsedMilliseconds, myid, socket);
        }

        public void Do(params object[] args)
        {
            ISocketWriter writer = _context.GetObject<ISocketWriter>();
            writer.SendTime(PaketType.IsAliveRequest, 0, (int)args[0], (Socket)args[1]);
        }
    }
}
