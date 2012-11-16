using IDD.Client.Interfaces;
using IDD.Global;
using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDD.Client.Handler.Chat
{
   public  class PlayerAddModule : IModuleHandler
    {
        private IAppContext _context;
        public PlayerAddModule(IAppContext context)
        {
            _context = context;
            _context.AddType<IUserList, UserList>(RegistrationMode.CreateOnce);
        }
        public PaketType HandleType
        {
            get { return PaketType.NewPlayerInfo; }
        }

        public void HandleMessage(byte[] content, int id, Socket socket, params object[] args)
        {
            string username = CommunicationHelper.DecodeString(content);
            _context.GetObject<IUserList>().Add(new User()
                {
                    Id = id,
                    Username = username
                });


            IConnectionModel model = _context.GetObject<IConnectionModel>();
            if (model.Id != id)
            { 
            //TODO: Von dem Ding hier wegkommen
            FormMessageOutput view = (FormMessageOutput) _context.GetObject<IMessageOutput>();
            view.Invoke((MethodInvoker)delegate
            {
                view.showText(OutputType.NewPlayer, username);
            });
            }
        }

        public void Do(params object[] args)
        {
            string message = String.Empty;
           if((args != null) && (args.Length>0))
               message = args[0].ToString();
            IConnectionModel model = _context.GetObject<IConnectionModel>();
            _context.GetObject<ISocketWriter>().SendMessage(PaketType.Message, message, model.Id, model.Socket);
        }
    }
}
