using CSharp.WinFormMVC.Event.Model;
using CSharp.WinFormMVC.Event.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinFormMVC.Event.Controller
{
    public class IncreaseController : IIncreaseController
    {
        private IIncreaseView _view;
        private IIncreaseModel _model;

        public IncreaseController(IIncreaseView view, IIncreaseModel model)
        {
            _view = view;
            _model = model;

            _view.SetController(this);
            _view.Changed += View_Changed;
            _model.Attach((IModelObserver)_view);
        }

        public void View_Changed(IIncreaseView view, ViewEventArgs e)
        {
            _model.SetValue(e.Value);
        }

        public void IncreaseValue()
        {
            _model.Increase();
        }
    }
}
