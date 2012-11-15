using IDD.Global;
using IDD.Global.Interfaces;
using IDD.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Server.Handler.Connection
{
    public class ConnectionHandler : IModuleHandler
    {
        private IAppContext _context;
        public ConnectionHandler(IAppContext context)
        {
            _context = context;
        }

        public PaketType HandleType
        {
            get { return PaketType.ConnectionInfo; }
        }

        public void HandleMessage(byte[] content, int id, IConnectionModel model)
        {
            model.Username = CommunicationHelper.DecodeString(content);
            ISocketWriter writer = _context.GetObject<ISocketWriter>();
            writer.SendInt(PaketType.ConnectionInfo, 55, -2, model.Socket); 
            IClientList list =  _context.GetObject<IClientList>();
            foreach (IConnectionModel Client in list)
            {
                writer.SendMessage(PaketType.NewPlayerInfo, model.Username, model.Id, Client.Socket);
            }
        }


        public void Do(object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
