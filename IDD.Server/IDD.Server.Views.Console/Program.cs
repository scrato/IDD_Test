using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using IDD.Global.Interfaces;
using IDD.Server.Communication;
using IDD.Server.Application;
using IDD.Server.Interfaces;

namespace IDD.Server.Views.Console
{
   
    public class Program : IMessageOutput
    {
        public static IAppContext AppContext { get; private set; }
        private static ICommunicationHandler _comm;

       
        static void Main(string[] args)
        {
            Program p = new Program();
            _comm = new CommunicationHandler(p, new AppContext());
            _comm.Connect();
         }

        public void showText(OutputType type, string text)
        {
            throw new NotImplementedException();
        }
    }
        
}
