using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTest.Controller;
using WinFormsTest.Model;

namespace WinFormsTest
{
    public partial class UserForm : Form, IUserView
    {
        private UserController _controller;

        public UserForm()
        {
            InitializeComponent();
        }
        
        #region IUserView

        public void SetController(UserController userController)
        {
            _controller = userController;
        }

        public void SetSelectedUserInGrid(User user)
        {
            foreach (ListViewItem item in _listViewUser.Items)
            {
                if (item.Text == user.Id)
                {
                    item.Selected = true;
                }
            }
        }

        public void AddUser(User user)
        {
            var row = _listViewUser.Items.Add(user.Id);
            row.SubItems.Add(user.FirstName);
            row.SubItems.Add(user.LastName);
            row.SubItems.Add(user.Department);
            row.SubItems.Add(Enum.GetName(typeof(Gender), user.Gender));
        }

        public void Clear()
        {
            _listViewUser.Columns.Clear();
            _listViewUser.Columns.Add("Id", 150, HorizontalAlignment.Left);
            _listViewUser.Columns.Add("First Name", 150, HorizontalAlignment.Left);
            _listViewUser.Columns.Add("Last Name", 150, HorizontalAlignment.Left);
            _listViewUser.Columns.Add("Department", 150, HorizontalAlignment.Left);
            _listViewUser.Columns.Add("Gender", 150, HorizontalAlignment.Left);

            _radioButtonMale.Checked = true;

            _listViewUser.Items.Clear();
        }

        public IList<string> GetSelectedUserIds()
        {
            var selectedUserIds = new List<string>();
            foreach (var selectedItem in _listViewUser.SelectedItems)
            {
                selectedUserIds.Add(((User)selectedItem).Id);
            }
            return selectedUserIds;
        }

        public string FirstName
        {
            get { return _textBoxFirstName.Text; }
            set { _textBoxFirstName.Text = value; }
        }

        public string LastName
        {
            get { return _textBoxLastName.Text; }
            set { _textBoxLastName.Text = value; }
        }

        public string Id
        {
            get { return _textBoxId.Text; }
            set { _textBoxId.Text = value; }
        }

        public string Department
        {
            get { return _textBoxDepartment.Text; }
            set { _textBoxDepartment.Text = value; }
        }

        public Gender Gender
        {
            get
            {
                if (_radioButtonMale.Checked)
                {
                    return Gender.Male;
                }
                if (_radioButtonFemale.Checked)
                {
                    return Gender.Female;
                }
                throw new InvalidOperationException("Invlid Gender");
            }
            set
            {
                if (value == Gender.Male)
                {
                    _radioButtonMale.Checked = true;
                }
                if (value == Gender.Female)
                {
                    _radioButtonFemale.Checked = true;
                }
                throw new InvalidOperationException("Invlid Gender" + value);
            }
        }

        #endregion

        private void _buttonAddUser_Click(object sender, EventArgs e)
        {
            _textBoxFirstName.Clear();
            _textBoxLastName.Clear();
            _textBoxId.Clear();
            _textBoxDepartment.Clear();
            _radioButtonMale.Checked = true;
            _radioButtonMale.Checked = false;
        }

        private void _buttonRemoveUser_Click(object sender, EventArgs e)
        {
            _controller.RemoveUsers();
        }

        private void _buttonRegisterUser_Click(object sender, EventArgs e)
        {
            _controller.AddUser();
        }
    }
}
