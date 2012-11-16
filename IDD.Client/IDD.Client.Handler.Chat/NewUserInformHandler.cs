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
    public  class NewUserInformHandler : IModuleHandler
    {

        IAppContext _context;

        public NewUserInformHandler(IAppContext context)
        {
            _context = context;
        }
        public PaketType HandleType
        {
            get { return PaketType.UserInformInfo; }
        }

        public void HandleMessage(byte[] content, int id, Socket socket, params object[] args)
        {
            string contentString = CommunicationHelper.DecodeString(content);
            IUserList list = _context.GetObject<IUserList>();
            string[] playerList = contentString.Split('\t');
            for (int i = 0; i < playerList.Length; i=i+2)
            {
                list.Add(new User()
                    {
                        Id = Int32.Parse(playerList[i]),
                        Username = playerList[i + 1]
                    });
            }
            string[] usernames = list.Select(x => x.Username).ToArray();

            FormMessageOutput view = (FormMessageOutput) _context.GetObject<IMessageOutput>();
            view.Invoke((MethodInvoker)delegate
            {
                view.showText(OutputType.InitializionInfo, usernames);
            });
        }

        public void Do(params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
