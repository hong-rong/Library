using CSharp.WinFormMVC.Event.Controller;
using CSharp.WinFormMVC.Event.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.WinFormMVC.Event.View
{
    public partial class IncreaseView : Form, IIncreaseView, IModelObserver
    {
        private IIncreaseController _controller;
        public event ViewHandler<IIncreaseView> Changed;

        public IncreaseView()
        {
            InitializeComponent();
        }

        public void SetController(IIncreaseController controller)
        {
            _controller = controller;
        }

        public void IncreaseValue(IIncreaseModel model, ModelEventArgs e)
        {
            _textBoxIncreasedValue.Text = "" + e.NewValue;
        }

        private void _textBoxIncreasedValue_TextChanged(object sender, EventArgs e)
        {
            if (Changed != null)
            {
                try
                {
                    Changed.Invoke(this, new ViewEventArgs { Value = int.Parse(_textBoxIncreasedValue.Text) });
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter a valid number");
                }
            }
        }

        private void _buttonIncrease_Click(object sender, EventArgs e)
        {
            _controller.IncreaseValue();
        }
    }
}