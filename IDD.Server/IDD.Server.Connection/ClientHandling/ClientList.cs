using IDD.Global;
using IDD.Global.Interfaces;
using IDD.Server.ClientHandling;
using IDD.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Server.Communication.ClientHandling
{
    public class ClientList : IClientList
    {
        private List<IConnectionModel> clients;
        public ClientList()
        {
            clients = new List<IConnectionModel>();
        }
        public IConnectionModel Add(Socket client)
        {
            IConnectionModel newClient = new ServerToClientModel()
                                                {
                                                    Socket = client,
                                                    Id = getNextAvailableClientId()
                                                };
            clients.Add(newClient);
            return newClient;
        }

        public int getNextAvailableClientId()
        {
           
            return (clients.Count == 0)? 0 : clients.Max(x => x.Id);
        }

        public IEnumerator<IConnectionModel> GetEnumerator()
        {
            return clients.GetEnumerator();
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return clients.GetEnumerator();
        }

    }
}
