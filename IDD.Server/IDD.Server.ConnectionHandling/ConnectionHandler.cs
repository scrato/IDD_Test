using IDD.Global;
using IDD.Global.Interfaces;
using IDD.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        public void HandleMessage(byte[] content, int id, Socket socket, params object[] args)
        {

            string username = CommunicationHelper.DecodeString(content);
            IMessageOutput output = _context.GetObject<IMessageOutput>();
            output.showText(OutputType.NewPlayer, username);

            ISocketWriter writer = _context.GetObject<ISocketWriter>();
            IClientList list = _context.GetObject<IClientList>();
            IConnectionModel newClient = list.Add(socket);
            newClient.Username = username;

            //Zuweisung der ID
            writer.SendInt(PaketType.ConnectionInfo, newClient.Id, -2, socket);
            writer.SendTime(PaketType.IsAliveRequest, 0, -2, socket);

            //Über bisherige Teilnehmer informieren
            string users = String.Empty;
            foreach (IConnectionModel Client in list)
            {
                users += Client.Id + "\t" + Client.Username + "\t";
            }
            users = users.Substring(0, users.Length - 1);
            writer.SendMessage(PaketType.UserInformInfo, users, -2, socket);
            
            
            //Andere über das Beitreten Informieren
            foreach (IConnectionModel Client in list)
            {
                writer.SendMessage(PaketType.NewPlayerInfo, newClient.Username, newClient.Id, Client.Socket);
            }
        }


        public void Do(params object[] args)
        {
            throw new NotImplementedException();
        }

    }
}
