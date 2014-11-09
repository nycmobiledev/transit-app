using Android.Views;

using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using TransitApp.Core.ViewModels;
using Android.Runtime;
using Android.OS;

namespace TransitApp.Droid.Views.Fragments
{
	public class AlertsView : MvxFragment
	{
        //private bool _isFirstTime = true;

        public AlertsView ()
		{
			this.RetainInstance = true;
		}

		/*
		public override void OnSaveInstanceState(Bundle outState)
		{
			//outState.PutString()
			base.OnSaveInstanceState (outState);

		}

		public override void OnResume(Bundle bundle)
		{

		}
		*/

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			this.HasOptionsMenu = true;
			base.OnCreateView (inflater, container, savedInstanceState);
			return this.BindingInflate (Resource.Layout.fragment_alerts, null);
		}

        //public override void OnResume()
        //{
        //    base.OnResume();

        //    if (_isFirstTime)
        //    {
        //        _isFirstTime = false;                
        //    }
        //    else
        //    {
        //        ((AlertsViewModel)this.ViewModel).RefreshCommand.Execute(null);
        //    }
        //}

		public override void OnCreateOptionsMenu (IMenu menu, MenuInflater inflater)
		{
			inflater.Inflate (Resource.Menu.alert, menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
//			case Resource.Id.menu_refresh:
//				((AlertsViewModel)this.ViewModel).RefreshCommand.Execute (null);
//				return true;
			case Resource.Id.menu_edit:
				((AlertsViewModel)this.ViewModel).GoToEditCommand.Execute (null);
				return true;
			}

			return base.OnOptionsItemSelected (item);
		}
	}
}

