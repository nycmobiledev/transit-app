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
    [Activity(Label = "Follows", Icon = "@android:color/transparent", ParentActivity = typeof(HomeView))]
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
                    //Wrong:
                    //var intent = new Intent(this, typeof(HomeView));
                    //intent.AddFlags(ActivityFlags.ClearTop);
                    //StartActivity(intent);
                    NavUtils.NavigateUpFromSameTask(this);

                    //if this could be launched externally:
                    /*
                     var upIntent = NavUtils.GetParentActivityIntent(this);
                    if (NavUtils.ShouldUpRecreateTask(this, upIntent))
                    {
                        Android.Support.V4.App.TaskStackBuilder.Create(this).
                            AddNextIntentWithParentStack(upIntent).
                            StartActivities();
                    }
                    else
                    {
                        NavUtils.NavigateUpTo(this, upIntent);  
                    }
                     */
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}