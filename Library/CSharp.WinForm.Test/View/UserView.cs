using CSharp.WinForm.Test.Controller;
using CSharp.WinForm.Test.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.WinForm.Test.View
{
    public partial class UserView : Form, IUserView, IUserModelObserver
    {
        private IUserModelController _controller;

        public UserView()
        {
            InitializeComponent();
        }

        public event ViewHandler<IUserView> Changed;

        public event LoadUser LoadUser;

        public void SetController(Controller.IUserModelController controller)
        {
            _controller = controller;
        }

        public void UsersLoaded(IUserModel userModel, UserModelEventArgs args)
        {
            foreach (var user in args.Users)
            {
                System.Diagnostics.Debug.WriteLine(user.Id);
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (LoadUser != null)
            {
                LoadUser.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
