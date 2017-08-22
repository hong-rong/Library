using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.WinForm.Controller;
using CSharp.WinForm.Model;

namespace CSharp.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IList<User> users = new List<User>();
            users.Add(new User("Vladimir", "Putin", "122", "Government of Russia", Gender.Male));
            users.Add(new User("Barack", "Obama", "123", "Government of USA", Gender.Male));
            users.Add(new User("Stephen", "Harper", "124", "Government of Canada", Gender.Male));
            users.Add(new User("Jean", "Charest", "125", "Government of Quebec", Gender.Male));
            users.Add(new User("David", "Cameron", "126", "Government of United Kingdom", Gender.Male));
            users.Add(new User("Angela", "Merkel", "127", "Government of Germany", Gender.Female));
            users.Add(new User("Nikolas", "Sarkozy", "128", "Government of France", Gender.Male));
            users.Add(new User("Silvio", "Berlusconi", "129", "Government of Italy", Gender.Male));
            users.Add(new User("Yoshihiko", "Noda", "130", "Government of Japan", Gender.Male));

            UserForm view = new UserForm();
            view.Visible = false;
            UserController controller = new UserController(view, users);
            controller.LoadView();
            view.ShowDialog();
            //Application.Run(view);
        }
    }
}
