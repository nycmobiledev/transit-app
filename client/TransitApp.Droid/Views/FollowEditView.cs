using Android.App;
using Android.Support.V4.App;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Droid.Views;
using TransitApp.Core.Services;
using TransitApp.Core.ViewModels;

namespace TransitApp.Droid.Views
{
    [Activity(Theme = "@style/MyTheme", Icon = "@android:color/transparent", ParentActivity = typeof(FollowsView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "transitapp.droid.views.FollowsView")]
    public class FollowEditView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            this.Title = ((FollowEditViewModel)this.ViewModel).Station.Name;
            SetContentView(Resource.Layout.page_followEdit_view);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            ((FollowEditViewModel)this.ViewModel).GetService<IFollowService>().AddFollows("101", new[] { "1", "2" });
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

