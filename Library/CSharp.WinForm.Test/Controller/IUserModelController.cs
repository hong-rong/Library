using CSharp.WinForm.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinForm.Test.Controller
{
    public interface IUserModelController
    {
        Task<List<User>> LoadUserAsync();
    }
}
