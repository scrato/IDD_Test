using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public interface IModuleHandler
    {
          PaketType HandleType { get; }
         void HandleMessage(byte[] content, int id, IConnectionModel model);
         void Do(object[] args);
    }
}
