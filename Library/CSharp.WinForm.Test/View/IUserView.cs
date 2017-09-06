using CSharp.WinForm.Test.Controller;
using CSharp.WinForm.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinForm.Test.View
{
    public delegate void ViewHandler<IView>(IView sender, UserViewEventArgs args);

    public delegate void LoadUser(object sender, EventArgs args);

    public interface IUserView
    {
        event ViewHandler<IUserView> Changed;

        event LoadUser LoadUser;

        void UsersLoaded(object sender, UserModelEventArgs args);

        void SetController(IUserModelController controller);
    }
}
