using CSharp.WinFormMVC.Event.Controller;
using CSharp.WinFormMVC.Event.Model;
using CSharp.WinFormMVC.Event.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.WinFormMVC.Event
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form view = new IncreaseView();
            IIncreaseModel model = new IncreaseModel();
            IIncreaseController controller = new IncreaseController((IIncreaseView)view, model);
            Application.Run(view);
        }
    }
}
