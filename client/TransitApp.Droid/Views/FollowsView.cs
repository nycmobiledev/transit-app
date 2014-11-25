using Android.App;
using Android.Support.V4.App;
using Android.Views;

using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Views;

using TransitApp.Core.ViewModels;
using Android.Widget;
using System.Runtime.Remoting.Contexts;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

namespace TransitApp.Droid.Views
{
//	[Activity(Label = "Stations Followed", Icon = "@android:color/transparent", ParentActivity = typeof(HomeView))]
//	[MetaData("android.support.PARENT_ACTIVITY", Value = "transitapp.droid.views.HomeView")]
    public class FollowsView : MvxFragment
    {

		public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
    	{
			inflater.Inflate (Resource.Menu.follows,menu);
    		base.OnCreateOptionsMenu(menu, inflater);

    	}

    	public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
    	{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);
			return this.BindingInflate(Resource.Layout.page_follows_view, null);

    	}


		public override void OnViewCreated(View view, Android.OS.Bundle savedInstanceState)
    	{
    		base.OnViewCreated(view, savedInstanceState);
			HasOptionsMenu = true;

    	}

		public override void OnPause()
    	{
    		base.OnPause();

    	}

    	public override void OnResume()
    	{
    		base.OnResume();

			if ( IsAdded  )
			{
//				Activity.ActionBar.SetHomeButtonEnabled( false );
				//				Activity.ActionBar.SetHomeButtonEnabled( true );   
			}
    	}
    	
	

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_new:
                    ((FollowsViewModel)this.ViewModel).GoToAddCommand.Execute(null);
                    return true;                    
			case Android.Resource.Id.Home:
//				NavUtils.NavigateUpFromSameTask(Activity);   
				Activity.SupportFragmentManager.PopBackStack();
				return true;
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}