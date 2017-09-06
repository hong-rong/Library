using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinForm.Test.Model
{
    public interface IUserModel
    {
        event CSharp.WinForm.Test.Model.UserModel.UserModelHandler Loaded;

        void LoadUsers();

        Task<List<User>> LoadUsersAsyc();

        void UpdateUser(User user);
    }
}
