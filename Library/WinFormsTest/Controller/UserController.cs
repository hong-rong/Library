using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.WinForm.Model;

namespace CSharp.WinForm.Controller
{
    public class UserController
    {
        private readonly IUserView _view;
        private readonly List<User> _users;

        public UserController(IUserView view, IList<User> users)
        {
            _view = view;
            _users = users.ToList();
            _view.SetController(this);
        }

        public void LoadView()
        {
            _view.Clear();
            foreach (var user in _users)
            {
                _view.AddUser(user);
            }
            _view.SetSelectedUserInGrid(_users[0]);
        }
        
        public void RemoveUsers()
        {
            var removedUserId = _view.GetSelectedUserIds();
            foreach (var id in removedUserId)
            {
                _users.Remove(_users.Single(u => u.Id == id));
            }
        }

        public void AddUser()
        {
            _users.Add(new User
            {
                FirstName = _view.FirstName,
                LastName = _view.LastName,
                Id = _view.Id,
                Department = _view.Department,
                Gender = _view.Gender
            });
        }
    }
}
