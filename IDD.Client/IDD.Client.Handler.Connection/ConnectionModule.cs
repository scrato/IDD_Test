using IDD.Global;
using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Client.Handler.Connection
{
    public class ConnectionModule : IModuleHandler
    {
        private IAppContext _context;
        public ConnectionModule(IAppContext context)
        {
            _context = context;
        }

        public PaketType HandleType
        {
            get { return PaketType.ConnectionInfo; }
        }

        public void HandleMessage(byte[] content, int id, Socket socket, params object[] args)
        {

            int myID = BitConverter.ToInt32(content,0);
            IConnectionModel model = _context.GetObject<IConnectionModel>();
            model.Id = myID;  
            
        }

        public void Do(params object[] args)
        {
            ISocketWriter writer = _context.GetObject<ISocketWriter>();
            IConnectionModel model = _context.GetObject<IConnectionModel>();
            writer.SendMessage(HandleType, model.Username, -1, model.Socket);
        }
    }
}
