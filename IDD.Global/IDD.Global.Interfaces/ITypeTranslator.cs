using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public  interface ITypeTranslator
    {
          int translateType(PaketType type);
         PaketType translateType(int typeId);
    }
}
