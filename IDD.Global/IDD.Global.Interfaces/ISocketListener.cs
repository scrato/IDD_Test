using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public interface ISocketListener
    {
        void Start(object sender, DoWorkEventArgs e);
        
        void Stop();
        void HandlePaket(PaketType type, byte[] content, int id);
    }
}
