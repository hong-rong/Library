using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinFormMVC.Event.Model
{
    public interface IIncreaseModel
    {
        void Attach(IModelObserver observer);
        void Increase();
        void SetValue(int v);
    }
}
