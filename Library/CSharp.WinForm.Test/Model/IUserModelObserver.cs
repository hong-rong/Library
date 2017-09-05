using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinForm.Test.Model
{
    public interface IUserModelObserver
    {
        void UsersLoaded(IUserModel userModel, UserModelEventArgs args);
    }
}
