using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.Winform.Async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _textBoxResult.Text += "waiting......\r\n";
        }

        private async void _buttonStart_Click(object sender, EventArgs e)
        {
            Task<string> result = AccessTheWebAsync();
            DoIndependentWork();
            //int contentLength = (await result).Length;
            _textBoxResult.Text += string.Format("Length of the downloaded string: {0}. \r\n", (await result).Length);
        }

        private Task<string> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            return client.GetStringAsync("http://msdn.microsoft.com");
        }

        private void DoIndependentWork()
        {
            _textBoxResult.Text += "doing independent work.........\r\n";
        }
    }
}
