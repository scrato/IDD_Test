using IDD.Global.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDD.Client.Interfaces
{
    public abstract class FormMessageOutput : Form, IMessageOutput
    {
        public abstract void showText(OutputType type, params string[] text);
    }
}
