using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTest.Controller;
using WinFormsTest.Model;

namespace WinFormsTest
{
    public interface IUserView
    {
        void AddUser(User user);
        void Clear();
        IList<string> GetSelectedUserIds();
        string FirstName { get; set; }
        string LastName { get; set; }
        string Id { get; set; }
        string Department { get; set; }
        Gender Gender { get; set; }
        void SetController(UserController userController);
        void SetSelectedUserInGrid(User user);
    }
}
