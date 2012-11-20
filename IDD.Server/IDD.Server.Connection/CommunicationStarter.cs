using IDD.Global.Interfaces;
using IDD.Server.Communication.ClientHandling;
using IDD.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Server.Communication
{
    public class CommunicationStarter : ICommunicationStarter
    {
        private IAppContext _appcontext;
        private TcpListener _listener;
        public IClientList Clients { get; set; }

        public CommunicationStarter(IAppContext context)
        {
            _appcontext = context;
            Clients = _appcontext.GetObject<IClientList>();
        }

        public void Connect()
        {
            _listener = new TcpListener(IPAddress.Any, 51414);
            _listener.Start();
            Boolean cancel = false;

            while (!cancel)
            {
                {
                   
                   Socket s = _listener.AcceptSocket();
                     lock (Clients)
                     {
                    BackgroundWorker clientListenerWorker = new BackgroundWorker();
                    ISocketListener clientListener = _appcontext.
                                                        GetObject<ISocketListener>();
                    ITypeTranslator translator = _appcontext.
                                                        GetObject<ITypeTranslator>();
                    IEnumerable<IModuleHandler> modules = _appcontext.
                                                        GetAllObjects<IModuleHandler>();
                    clientListenerWorker.DoWork += new DoWorkEventHandler(clientListener.Start);
                    clientListenerWorker.RunWorkerAsync(s);


                    BackgroundWorker clientIsAliveWorker = new BackgroundWorker();

                    }


                }
            }
        }
    }
}
