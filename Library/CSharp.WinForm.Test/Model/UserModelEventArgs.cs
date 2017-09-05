using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinForm.Test.Model
{
    public class UserModelEventArgs : EventArgs
    {
        public List<User> Users { get; set; }
    }
}
