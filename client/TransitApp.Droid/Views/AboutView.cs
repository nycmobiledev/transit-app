using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using System;
using TransitApp.Core.ViewModels;

namespace TransitApp.Droid.Views.Fragments
{
    public class AboutView : MvxFragment
    {
        public AboutView()
        {
            this.RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.fragment_about, null);

            WebView tv = view.FindViewById<WebView>(Resource.Id.webview);
            tv.LoadData((this.ViewModel as AboutViewModel).Content, "text/html", "utf-8");
            return view;
        }
    }
}