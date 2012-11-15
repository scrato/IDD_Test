using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global
{
    public class SocketWriter : ISocketWriter
    {
        IAppContext _context;
        public SocketWriter(IAppContext context, IModuleHandler[] modules)
        {
            _context = context;
        }
        public void SendBytes(PaketType type, byte[] content, int id, Socket socket)
        {
            ITypeTranslator translator = _context.GetObject<ITypeTranslator>();
            int typeId = translator.translateType(type);
            byte[] packet = CommunicationHelper.createPaket(content, typeId, id);
            lock (socket)
            {
                socket.Send(packet);
            }
        }

        public void SendMessage(PaketType type, string content, int id, Socket socket)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] contentBytes = enc.GetBytes(content);
            SendBytes(type, contentBytes, id, socket);
        }

        public void SendStream(PaketType type, Stream content, int id, Socket socket)
        {
            byte[] contentBytes = new byte[content.Length];
            content.Read(contentBytes, 0, (int)content.Length - 1);
            SendBytes(type, contentBytes, id, socket);
        }


        public void SendInt(PaketType type, int content, int id, Socket socket)
        {
            byte[] contentBytes = BitConverter.GetBytes(content);
            SendBytes(type, contentBytes, id, socket);
        }
    }
}
