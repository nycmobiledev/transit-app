using Cirrious.CrossCore;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using System;
using System.Collections.Generic;
using TransitApp.Core;

namespace TransitApp.WindowsPhone.Helpers
{
    public class ViewModelDialog : IViewModelDialog
    {
        public void Show<T>(IDictionary<string, string> paras) where T : IMvxViewModel
        {
            // Windows Phone is not Dialog in this version
            var viewDispatcher = MvxSingleton<IMvxMainThreadDispatcher>.Instance as IMvxViewDispatcher;
            viewDispatcher.ShowViewModel(new MvxViewModelRequest<T>(new MvxBundle(paras), null, null));            
        }
    }
}