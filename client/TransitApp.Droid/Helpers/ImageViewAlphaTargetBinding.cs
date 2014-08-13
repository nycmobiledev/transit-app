using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Target;

namespace TransitApp.Droid
{
    public class ImageViewAlphaTargetBinding : MvxAndroidTargetBinding
    {
        public ImageViewAlphaTargetBinding(ImageView target)
            : base(target)
        {
        }

        protected override void SetValueImpl(object target, object value)
        {
            var imageView = (ImageView)target;
            imageView.SetAlpha((int)value);
        }

        public override Type TargetType
        {
            get { return typeof(int); }
        }
    }
}