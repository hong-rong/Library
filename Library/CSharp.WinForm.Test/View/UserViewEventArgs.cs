using CSharp.WinForm.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinForm.Test.View
{
    public class UserViewEventArgs : EventArgs
    {
        public User ChangedUser { get; set; }
    }
}
