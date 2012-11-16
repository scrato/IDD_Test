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
        private static ICommunicationHandler _comm;

       
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();

         }

        public void Start()
        {

            AppContext app = new AppContext();
            app.AddObject<IMessageOutput>(this);
            _comm = new CommunicationHandler(app);
            _comm.Connect();
        }
        public void showText(OutputType type, params string[] text)
        {
            switch (type)
            {
                case OutputType.Message:
                    System.Console.WriteLine("{0} sendet die Nachricht {1} - {2}",text[0],text[1],text[2]);
                    break;
                case OutputType.InitializionInfo:
                    foreach (var error in text)
	                    {
                            System.Console.WriteLine(error);
	                    }
                     
                    break;
                case OutputType.Error:
                    break;
                case OutputType.NewPlayer:
                    System.Console.WriteLine("{0} ist jetzt angemeldet", text[0]);
                    break;
                default:
                    break;
            }
        }
    }
        
}
