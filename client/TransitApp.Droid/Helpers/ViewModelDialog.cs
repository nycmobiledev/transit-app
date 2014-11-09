using Android.App;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using Android.Views;
using TransitApp.Core;
using Cirrious.MvvmCross.Views;
using System;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using Cirrious.MvvmCross.Droid.Fragging;

namespace TransitApp.Droid
{
    public class ViewModelDialog : IViewModelDialog
    {
        public void Show<T>(IDictionary<string, string> paras) where T : IMvxViewModel
        {
            MvxFragmentActivity activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity as MvxFragmentActivity;

            var container = Mvx.Resolve<IMvxViewsContainer>();
            var viewType = container.GetViewType(typeof(T));
            var dialog = Activator.CreateInstance(viewType) as MvxDialogFragment;

            //var locator = Mvx.Resolve<IMvxViewModelLocator>();

            IMvxViewModel viewModel = Activator.CreateInstance<T>();
            viewModel.Init(new MvxBundle(paras));
            dialog.ViewModel = viewModel;
            dialog.Show(activity.SupportFragmentManager, "Testing");
        }
    }
}