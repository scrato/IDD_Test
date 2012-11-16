using IDD.Client.Interfaces;
using IDD.Global;
using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDD.Client.Handler.Chat
{
    public class MessageModule : IModuleHandler
    {
        IAppContext _context;
        public MessageModule(IAppContext appcontext)
        {
            _context = appcontext;
        }
        public PaketType HandleType
        {
            get { return PaketType.Message; }
        }

        public void HandleMessage(byte[] content, int id, Socket socket, params object[] args)
        {
            string message = CommunicationHelper.DecodeString(content);
                

            //TODO: Von dem Ding hier wegkommen
            FormMessageOutput view = (FormMessageOutput)_context.GetObject<IMessageOutput>();
            IUserList list = _context.GetObject<IUserList>();
            User user = list.Where(x => x.Id == id).FirstOrDefault();
            string username = string.Empty;
            if(user!=null)
            {
                username = user.Username;
            }
            view.Invoke((MethodInvoker)delegate
            {
                view.showText(OutputType.Message, username, message );
            });
        }

        public void Do(params object[] args)
        {
            string message = args[0].ToString();
            if (message[0] == '/')
            { 
                excecuteCommand(message);
                return;
            }

            sendMessage(message);

        }

        private void sendMessage(string message)
        {
            IConnectionModel model = _context.GetObject<IConnectionModel>();
            message = "/bc "+ message;
           
            _context.GetObject<ISocketWriter>().SendMessage(PaketType.Message, message, model.Id, model.Socket);
        }

        private void excecuteCommand(string message)
        {
            throw new NotImplementedException();
        }
    }
}
