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

            _view.LoadUser += UserView_LoadUser;
            _view.Changed += UserView_Changed;

            _model.Attach((IUserModelObserver)_view);
        }

        private void UserView_LoadUser(object sender, EventArgs args)
        {
            _model.LoadUsers();
        }

        private void UserView_Changed(IUserView sender, UserViewEventArgs args)
        {
            _model.UpdateUser(args.ChangedUser);
        }
    }
}
