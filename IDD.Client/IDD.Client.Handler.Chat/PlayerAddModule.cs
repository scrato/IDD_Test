using IDD.Global;
using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Client.Handler.Chat
{
    class PlayerAddModule : IModuleHandler
    {
        private IAppContext _context;
        public PlayerAddModule(IAppContext context)
        {
            _context = context;
            _context.AddType<IUserList, UserList>();
        }
        public PaketType HandleType
        {
            get { return PaketType.NewPlayerInfo; }
        }

        public void HandleMessage(byte[] content, int id, IConnectionModel model)
        {
            string username = CommunicationHelper.DecodeString(content);
            _context.GetObject<IUserList>().Add(new User()
                {
                    Id = id,
                    Username = username
                });
        }

        public void Do(object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
