using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinFormMVC.Event.Model
{
    public class ModelEventArgs : EventArgs
    {
        public int NewValue { get; set; }
    }
}
