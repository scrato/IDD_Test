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
        private IConnTimeoutHandler _timeouthandler;

        public SocketListener(ITypeTranslator translator, IModuleHandler[] modules, IAppContext context, IConnTimeoutHandler timeout)
        {
            _modules = modules.ToList();
            _translator = translator;
            _context = context;
            _timeouthandler = timeout;
            System.Timers.Timer _timer = new System.Timers.Timer();
            Timer time = new Timer();
            TimerCallback.
        }

        public void Stop()
        {
            _sender.CancelAsync();
        }

        public void Start(object sender, DoWorkEventArgs e)
        {
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
                     lock (_translator)
                    {
                        PaketType type = _translator.translateType(typeId);
                        //GetContent
                        content = CommunicationHelper.checkMessageContent(_socket);


                        //GetId
                        int newID = CommunicationHelper.checkMessageId(_socket);

                        HandlePaket(type, content, newID);
                    }



                    
                }
               }
            }
        }

        public void HandlePaket(PaketType type, byte[] content, int id)
        {

            //Bei einem IsAliveRequest der Timer dieses Threads zurücksetzen
            if(type == PaketType.IsAliveRequest)
            {
                _timeouthandler.HandleMessage(content, id);  
                return;
            }

            lock (_modules)
            {
            IModuleHandler module = _modules.Where<IModuleHandler>(x => x.HandleType == type).FirstOrDefault();
            if (module != null)
            {
                lock (module)
                {
                module.HandleMessage(content, id, _socket);
                }
            }
            else
                throw new ModuleNotImplementedException(type.ToString());
            }
        }

    }
}
