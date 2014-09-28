using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using Android.Views;
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

            TextView tv = view.FindViewById<TextView>(Resource.Id.txt_about);
            tv.TextFormatted = Html.FromHtml((this.ViewModel as AboutViewModel).Content, new Base64ImageGetter(), null);
            tv.MovementMethod = Android.Text.Method.LinkMovementMethod.Instance;
            return view;
        }        
    }
}