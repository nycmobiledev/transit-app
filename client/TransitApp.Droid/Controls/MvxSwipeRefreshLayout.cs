using System;
using Android.Support.V4.Widget;
using Android.Util;
using System.Windows.Input;
using Android.Content;

namespace TransitApp.Droid.Controls
{ 
	public class MvxSwipeRefreshLayout : SwipeRefreshLayout
	{
		/// <summary>
		/// Gets or sets the refresh command.
		/// </summary>
		/// <value>The refresh command.</value>
		public ICommand RefreshCommand { get; set;}

		public MvxSwipeRefreshLayout(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init ();
		}

		public MvxSwipeRefreshLayout(Context context)
			: base(context)
		{
			Init ();
		}

	
		private void Init()
		{
			//This gets called when we pull down to refresh to trigger command
			this.Refresh += (object sender, EventArgs e) => {
				var command = RefreshCommand;
				if (command == null)
					return;

				command.Execute (null);
			};
		}

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
			SetColorSchemeResources(Resource.Color.srl_1, Resource.Color.srl_2, Resource.Color.srl_3, Resource.Color.srl_4);
        }
	}
}

