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

namespace IDD.Client.Communication
{
    public class Connector : IConnector
    {
        public IAppContext _appcontext;

        public Connector(IAppContext appcontext)
        {
            _appcontext = appcontext;
        }
        public void Connect(IClientToServerModel _conn)
        {
            TcpClient tcpClient = new TcpClient();
                ISocketListener serverListener = _appcontext.
                                                GetObject<ISocketListener>();

                ITypeTranslator translator = _appcontext.
                                             GetObject<ITypeTranslator>();

                IEnumerable<IModuleHandler> modules = _appcontext.
                                            GetAllObjects<IModuleHandler>();

                tcpClient.Connect(_conn.IP, _conn.Port);
                _conn.Socket = tcpClient.Client;
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += new DoWorkEventHandler(serverListener.Start);
                bgw.RunWorkerAsync(_conn.Socket);

                IModuleHandler connHandler = _appcontext.GetAllObjects<IModuleHandler>().Where(x => x.HandleType == PaketType.ConnectionInfo).FirstOrDefault();
                if (connHandler != null)
                    connHandler.Do(null);




        }
    }
}
