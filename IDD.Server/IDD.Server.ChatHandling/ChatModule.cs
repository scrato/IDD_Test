using IDD.Global;
using IDD.Global.Exceptions;
using IDD.Global.Interfaces;
using IDD.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Server.Handler.Chat
{
    public class ChatModule: IModuleHandler
    {
        private IAppContext _context;

        public ChatModule(IAppContext context)
        {
            _context = context;
        }



        public PaketType HandleType
        {
            get { return PaketType.Message; }
        }


        public void HandleMessage(byte[] content, int id, Socket socket, params object[] args)
        {
            string contentString = CommunicationHelper.DecodeString(content);
            string command = string.Empty;
            string message = string.Empty;
            foreach (char letter in contentString)
            {
                if (letter != ' ')
                    command += letter;
                else
                    break;
            }
            message = contentString.Substring(command.Length +1);

            switch (command)
            {
                case "/bc":
                    broadcastMessage(message, id);
                    break;
                case "/say":
                    sayMessage(message, id);
                    break;
                default:
                    throw new TypeNotKnownException(command);
            }
            IClientList clients = _context.GetObject<IClientList>();


        }

        private void sayMessage(string message, int senderid)
        {
            //Parsen
            string idString = string.Empty;
            foreach (char letter in message)
            {
                if (letter != ' ')
                    idString += letter;
                else
                    break;
            }

            int recieverid = Int32.Parse(idString);
            message = message.Substring(idString.Length +1);

            //Logging
            IMessageOutput output = _context.GetObject<IMessageOutput>();
            output.showText(OutputType.Message, senderid.ToString(), message, "privat");

            //Versenden
            ISocketWriter writer = _context.GetObject<ISocketWriter>();
            IConnectionModel client = _context.GetObject<IClientList>().Where(x => x.Id == recieverid).FirstOrDefault();
            writer.SendMessage(PaketType.PersonalMessage,
                                message,
                                senderid,
                                client.Socket);


        }

        private void broadcastMessage(string message, int senderid)
        {
            //Logging
            IMessageOutput output = _context.GetObject<IMessageOutput>();
            output.showText(OutputType.Message, senderid.ToString(), message, "an alle");

            //Versenden
            IClientList clientlist = _context.GetObject<IClientList>();
            ISocketWriter writer = _context.GetObject<ISocketWriter>();
            foreach (IConnectionModel client in clientlist)
            {
                writer.SendMessage(PaketType.Message, 
                                    message, 
                                    senderid, 
                                    client.Socket);
            }
        }




        public void Do(params object[] args)
        {
            throw new NotImplementedException();
        }


    }
}
