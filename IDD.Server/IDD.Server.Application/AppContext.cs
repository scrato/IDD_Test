using IDD.Global;
using IDD.Global.Interfaces;
using IDD.Server.ClientHandling;
using IDD.Server.Communication;
using IDD.Server.Communication.ClientHandling;
using IDD.Server.Handler.Chat;
using IDD.Server.Handler.Connection;
using IDD.Server.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Server.Application
{
    public class AppContext : UnityAppContext, IAppContext
    {
        public override void InitializeContainer(IUnityContainer _container)
        {
            AddObject<IAppContext>(this);
            AddType<ICommunicationHandler, CommunicationHandler>(RegistrationMode.CreateOnce);
            AddType<ITypeTranslator, TypeTranslation>(RegistrationMode.CreateOnce);

            // Client und ClientListener
            AddType<IClientList, ClientList>(RegistrationMode.CreateOnce);
            AddType<ISocketListener, SocketListener>(RegistrationMode.CreateOnce);
            AddType<ISocketWriter, SocketWriter>(RegistrationMode.CreateOnce);
            AddType<IConnectionModel, ServerToClientModel>(RegistrationMode.CreateAlways);


            //Module
            AddTypes<IModuleHandler, ChatModule>("Chat");
            AddTypes<IModuleHandler, ConnectionHandler>("Connection");

        }


    }
}
