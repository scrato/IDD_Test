using IDD.Client.Communication;
using IDD.Client.Handler.Connection;
using IDD.Client.Interfaces;
using IDD.Client.Model;
using IDD.Global;
using IDD.Global.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Client.Application
{
    public class AppContext : UnityAppContext, IAppContext
    {

        
        public override void InitializeContainer(IUnityContainer _container)
        {
            AddObject<IAppContext>(this);
            AddType<ISocketListener, SocketListener>(RegistrationMode.CreateOnce);
            AddType<ISocketWriter, SocketWriter>(RegistrationMode.CreateOnce);
            AddType<ITypeTranslator, TypeTranslation>(RegistrationMode.CreateOnce);

            AddType<IConnector, Connector>(RegistrationMode.CreateOnce);
            AddType<IConnectionModel, ClientToServerModel>(RegistrationMode.CreateOnce);
            AddType<IClientToServerModel, ClientToServerModel>(RegistrationMode.CreateOnce);

            //Module
            //AddTypes<IModuleHandler, ChatModuleHandler>("Chat");
            AddTypes<IModuleHandler, ConnectionModule>("Connection");

        }
    }
}
