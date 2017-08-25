﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.WinFormMVC.Event.Model
{
    public interface IModelObserver
    {
        void IncreaseValue(IIncreaseModel model, ModelEventArgs e);
    }
}
