using Android.App;
using Android.Support.V4.App;
using Android.Views;

using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Views;

using TransitApp.Core.ViewModels;

namespace TransitApp.Droid.Views
{
    [Activity(Label = "Follows", Theme = "@style/MyTheme", Icon = "@android:color/transparent", ParentActivity = typeof(HomeView))]
	[MetaData("android.support.PARENT_ACTIVITY", Value = "transitapp.droid.views.HomeView")]
    public class FollowsView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.page_follows_view);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);            
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
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