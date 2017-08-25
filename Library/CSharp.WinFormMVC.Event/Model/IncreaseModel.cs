using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinFormMVC.Event.Model
{
    public class IncreaseModel : IIncreaseModel
    {
        public delegate void IncreaseModelHandler<IModel>(IModel sender, ModelEventArgs e);
        public event IncreaseModelHandler<IIncreaseModel> Changed;
        private int _value;

        public void Attach(IModelObserver observer)
        {
            Changed += observer.IncreaseValue;
        }

        public void Increase()
        {
            _value++;
            if (Changed != null)
            {
                Changed.Invoke(this, new ModelEventArgs { NewValue = _value });
            }
        }

        public void SetValue(int v)
        {
            _value = v;
        }
    }
}