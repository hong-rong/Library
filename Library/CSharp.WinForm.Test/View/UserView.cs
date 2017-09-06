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
            _listViewUser.Columns.Clear();
            _listViewUser.Columns.Add("Id", 150, HorizontalAlignment.Left);
            _listViewUser.Columns.Add("First Name", 150, HorizontalAlignment.Left);
            _listViewUser.Columns.Add("Last Name", 150, HorizontalAlignment.Left);
            _listViewUser.Columns.Add("Department", 150, HorizontalAlignment.Left);
            _listViewUser.Columns.Add("Gender", 150, HorizontalAlignment.Left);

            _listViewUser.Items.Clear();

            foreach (var user in args.Users)
            {
                var row = _listViewUser.Items.Add(user.Id);
                row.SubItems.Add(user.FirstName);
                row.SubItems.Add(user.LastName);
                row.SubItems.Add(user.Department);
                row.SubItems.Add(user.Gender.ToString());
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoadUser != null)
            {
                LoadUser.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
