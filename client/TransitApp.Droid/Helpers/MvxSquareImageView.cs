using System;

using Android.Content;
using Android.Runtime;
using Android.Util;

using Cirrious.MvvmCross.Binding.Droid.Views;

namespace TransitApp.Droid.Helpers
{
    public class MvxSquareImageView : MvxImageView
    {
        public MvxSquareImageView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public MvxSquareImageView(Context context)
            : base(context)
        {
        }

       

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            this.SetMeasuredDimension(this.MeasuredWidth, this.MeasuredWidth);
        }
    }
}