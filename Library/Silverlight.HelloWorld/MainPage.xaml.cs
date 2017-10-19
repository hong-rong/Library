using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Silverlight.HelloWorld
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.StudentViewModel studentViewModelObject = new ViewModel.StudentViewModel();
            studentViewModelObject.LoadStudents();
            //StudentViewControl.DataContext = studentViewModelObject;
        }

        private void useDomButton_Click(object sender, RoutedEventArgs e)
        {
            ScriptObject myJsObject = HtmlPage.Window.GetProperty("myJsObject") as ScriptObject;
            string[] propertyNames = { "answer", "message", "modifyHeading", "performReallyComplexCalculation" };

            foreach (var propertyName in propertyNames)
            {
                object value = myJsObject.GetProperty(propertyName);
                Debug.WriteLine("{0}: {1} ({2})", propertyName, value, value.GetType());
            }

            object result = myJsObject.Invoke("performReallyComplexCalculation", 11, 31);
            HtmlElement h1 = HtmlPage.Document.GetElementById("heading");
            h1.SetProperty("innerHTML", "Text from C# (without JavaScript's help)");
            h1.SetStyleAttribute("height", "200px");
        }
    }
}
