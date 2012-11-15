using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDD.Global.Interfaces
{
    public interface IMessageOutput
    {
        void showText(OutputType type, string text);
    }
    public enum OutputType
    {
        Message,
        InitializionInfo,
        Error
    }
}
