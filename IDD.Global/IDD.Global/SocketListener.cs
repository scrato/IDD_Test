using IDD.Global.Exceptions;
using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private IConnectionModel _model;

        public SocketListener(ITypeTranslator translator, IModuleHandler[] modules, IConnectionModel model )
        {
            _modules = modules.ToList();
            _translator = translator;
            _model = model;
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
            Socket socket = (Socket)e.Argument;
            _model.Socket = socket;

            while (!_sender.CancellationPending)
            {
                if (socket.Available > 0)
                {
                lock (socket)
                {
                
                    //GetType
                    int typeId = CommunicationHelper.checkMessageType(socket);
                    if (typeId == -1) return;
                    PaketType type = _translator.translateType(typeId);


                    //GetContent
                    content = CommunicationHelper.checkMessageContent(socket);


                    //GetId
                    int id = CommunicationHelper.checkMessageId(socket);

                    HandlePaket(type, content, id);

                    
                }
               }
                Thread.Sleep(2000);
            }
        }

        public void HandlePaket(PaketType type, byte[] content, int id)
        {
            IModuleHandler module = _modules.Where<IModuleHandler>(x => x.HandleType == type).FirstOrDefault();
            if (module != null)
                module.HandleMessage(content, id, _model);
            else
                throw new ModuleNotImplementedException(type.ToString());
        }

    }
}
