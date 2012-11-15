using IDD.Global;
using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public void HandleMessage(byte[] content, int id, IConnectionModel model)
        {
            throw new NotImplementedException();
        }


        public void Do(object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
