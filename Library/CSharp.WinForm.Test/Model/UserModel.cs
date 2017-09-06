using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinForm.Test.Model
{
    public class UserModel : IUserModel
    {
        public delegate void UserModelHandler(object sender, UserModelEventArgs args);
        public event UserModelHandler Loaded;

        private List<User> _users;

        public Task<List<User>> LoadUsersAsyc()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                return ReadUsers();
            });
        }

        public void LoadUsers()
        {
            var users = ReadUsers();
            _users = users;
            if (Loaded != null)
            {
                Loaded.Invoke(this, new UserModelEventArgs() { Users = users });
            }
        }

        private List<User> ReadUsers()
        {
            List<User> users = new List<User>();
            foreach (var line in File.ReadLines(@"C:\GitHub\user.txt"))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var parts = line.Trim().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var user = new User()
                    {
                        Id = parts[0],
                        FirstName = parts[1],
                        LastName = parts[2],
                        Department = parts[3],
                        Gender = (Gender)Enum.Parse(typeof(Gender), parts[4])
                    };
                    users.Add(user);
                }
            }

            return users;
        }

        public void UpdateUser(User user)
        {
            if (_users != null)
            {
                User u1 = _users.SingleOrDefault(u => u.Id == user.Id);
                if (u1 != null)
                {
                    u1.FirstName = user.FirstName;
                }
            }
        }
    }
}
