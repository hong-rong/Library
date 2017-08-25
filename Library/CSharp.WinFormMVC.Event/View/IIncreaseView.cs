using CSharp.WinFormMVC.Event.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinFormMVC.Event.View
{
    public delegate void ViewHandler<IView>(IView sender, ViewEventArgs e);

    public interface IIncreaseView
    {
        event ViewHandler<IIncreaseView> Changed;
        void SetController(IIncreaseController controller);
    }
}
