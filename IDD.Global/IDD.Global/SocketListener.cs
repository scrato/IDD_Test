using IDD.Global.Exceptions;
using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IDD.Global
{
    public class SocketListener : ISocketListener
    {
        private BackgroundWorker _sender;
        private ITypeTranslator _translator;
        private List<IModuleHandler> _modules;
        private Socket _socket;
        private IAppContext _context;
        private Stopwatch connectionTimer;
        private int Id=-3;

        public SocketListener(ITypeTranslator translator, IModuleHandler[] modules, IAppContext context)
        {
            connectionTimer = new Stopwatch();
            _modules = modules.ToList();
            _translator = translator;
            _context = context;
        }

        public void Stop()
        {
            _sender.CancelAsync();
        }

        public void Start(object sender, DoWorkEventArgs e)
        {
            connectionTimer.Start();
            _sender = (BackgroundWorker) sender;
            _sender.WorkerSupportsCancellation = true;

            byte[] content;
            _socket = (Socket)e.Argument;

            while (!_sender.CancellationPending)
            {
                if (_socket.Available > 0)
                {
                    lock (_socket)
                {
                
                    //GetType
                    int typeId = CommunicationHelper.checkMessageType(_socket);
                    if (typeId == -1) return;
                    PaketType type = _translator.translateType(typeId);


                    //GetContent
                    content = CommunicationHelper.checkMessageContent(_socket);


                    //GetId
                    int newID = CommunicationHelper.checkMessageId(_socket);

                    HandlePaket(type, content, newID);

                    
                }
               }
                if (connectionTimer.ElapsedMilliseconds > 20000)
                {
                    Stop();
                }
            }
        }

        public void HandlePaket(PaketType type, byte[] content, int id)
        {

            IModuleHandler module = _modules.Where<IModuleHandler>(x => x.HandleType == type).FirstOrDefault();
            if (module != null)
            {
                object[] obj = null;
                switch (type)
                {
                    case PaketType.IsAliveRequest:
                        obj = new object[1];
                        obj[0] = connectionTimer;
                        break;
                    default:
                        break;
                }
                lock (module)
                {
                module.HandleMessage(content, id, _socket, obj);
                }
            }
            else
                throw new ModuleNotImplementedException(type.ToString());
        }

    }
}
