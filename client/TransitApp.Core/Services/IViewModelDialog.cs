using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;

namespace TransitApp.Core
{
    public interface IViewModelDialog
    {
        void Show<T>(IDictionary<string, string> paras) where T : IMvxViewModel;
    }
}
