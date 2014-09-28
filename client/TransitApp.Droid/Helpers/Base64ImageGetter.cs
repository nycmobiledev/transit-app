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

namespace TransitApp.Droid
{
    public class Base64ImageGetter : Java.Lang.Object, Html.IImageGetter
    {
        public Android.Graphics.Drawables.Drawable GetDrawable(string source)
        {
            byte[] data = Convert.FromBase64String(source.Substring(source.IndexOf(",") + 1));
            Bitmap bitmap = BitmapFactory.DecodeByteArray(data, 0, data.Length);
            BitmapDrawable brawable = new BitmapDrawable(bitmap);
            brawable.SetBounds(0, 0, bitmap.Width, bitmap.Height);
            return brawable;
        }

        public System.IntPtr Handle
        {
            get { return base.Handle; }
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }
}
