using CSharp.WinForm.Test.Controller;
using CSharp.WinForm.Test.Model;
using CSharp.WinForm.Test.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.WinForm.Test
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

            Form view = new UserView();
            IUserModel model = new UserModel();
            IUserModelController contoller = new UserModelController((IUserView)view, model);

            Application.Run(view);
        }
    }
}
