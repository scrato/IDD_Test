using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string Message):base(Message) {}

    }
}
