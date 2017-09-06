using CSharp.WinForm.Test.Model;
using CSharp.WinForm.Test.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinForm.Test.Controller
{
    public class UserModelController : IUserModelController
    {
        private readonly IUserView _view;
        private readonly IUserModel _model;

        public UserModelController(IUserView userView, IUserModel userModel)
        {
            _view = userView;
            _model = userModel;

            _view.SetController(this);
            _view.Changed += UserView_Changed;
            _model.Loaded += _view.UsersLoaded;
        }

        public Task<List<User>> LoadUserAsync()
        {
            return _model.LoadUsersAsyc();
        }

        private void UserView_Changed(IUserView sender, UserViewEventArgs args)
        {
            _model.UpdateUser(args.ChangedUser);
        }
    }
}
