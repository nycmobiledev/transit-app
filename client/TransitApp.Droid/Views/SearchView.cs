using Android.App;
using Android.Support.V4.App;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Droid.Views;
using TransitApp.Core.ViewModels;

namespace TransitApp.Droid.Views
{
    [Activity(Label = "Search", Icon = "@android:color/transparent", ParentActivity = typeof(FollowsView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "transitapp.droid.views.FollowsView")]
    public class SearchView : MvxActivity
    {
        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.page_search);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
        }        

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    var viewModel = this.ViewModel as SearchViewModel;
                    if (viewModel.IsStartViewModel)
                    {
                        viewModel.GoToHomeViewModel();
                    }
                    else
                    {
                        NavUtils.NavigateUpFromSameTask(this);
                    }
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}

