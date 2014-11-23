using Android.App;
using Android.Support.V4.App;
using Android.Views;

using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Views;

using TransitApp.Core.ViewModels;
using Android.Widget;
using System.Runtime.Remoting.Contexts;
using Cirrious.MvvmCross.Droid.Fragging;

namespace TransitApp.Droid.Views
{
	[Activity(Label = "Stations Followed", Icon = "@android:color/transparent", ParentActivity = typeof(HomeView))]
	[MetaData("android.support.PARENT_ACTIVITY", Value = "transitapp.droid.views.HomeView")]
    public class FollowsView : MvxFragmentActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.page_follows_view);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);   
        }

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			this.MenuInflater.Inflate (Resource.Menu.follows,menu);
			return base.OnCreateOptionsMenu (menu);
		}
     

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_new:
                    ((FollowsViewModel)this.ViewModel).GoToAddCommand.Execute(null);
                    return true;                    
                case Android.Resource.Id.Home:
                    NavUtils.NavigateUpFromSameTask(this);                    
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}