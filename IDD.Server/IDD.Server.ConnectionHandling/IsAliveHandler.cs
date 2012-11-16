using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Server.Handler.Connection
{
    public class IsAliveHandler : IModuleHandler
    {
        private IAppContext _context;
        private Stopwatch _watch;

        public IsAliveHandler(IAppContext context)
        {
            _context = context;
            _watch = new Stopwatch();
        }
        public PaketType HandleType
        {
            get { return PaketType.IsAliveRequest; }
        }



        public void HandleMessage(byte[] content, int id, Socket socket, params object[] args)
        {
            Stopwatch counter = (Stopwatch)args[0];
            long ms = counter.ElapsedMilliseconds;
            counter.Restart();
            ISocketWriter writer = _context.GetObject<ISocketWriter>();
            writer.SendTime(PaketType.IsAliveRequest, ms, id, socket);
        }

        public void Do(params object[] args)
        {
            ISocketWriter writer = _context.GetObject<ISocketWriter>();
            writer.SendTime(PaketType.IsAliveRequest, 0, (int) args[0], (Socket) args[1]);
        }
    }
}
