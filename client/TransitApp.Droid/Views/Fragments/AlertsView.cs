using Android.Views;

using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using TransitApp.Core.ViewModels;

namespace TransitApp.Droid.Views.Fragments
{
	public class AlertsView : MvxFragment
	{
		public AlertsView ()
		{
			this.RetainInstance = true;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			this.HasOptionsMenu = true;
			var ignored = base.OnCreateView (inflater, container, savedInstanceState);
			return this.BindingInflate (Resource.Layout.fragment_alerts, null);
		}

		public override void OnCreateOptionsMenu (IMenu menu, MenuInflater inflater)
		{
			inflater.Inflate (Resource.Menu.alert, menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case Resource.Id.menu_refresh:
				((AlertsViewModel)this.ViewModel).RefreshCommand.Execute (null);
				return true;
			case Resource.Id.menu_edit:
				((AlertsViewModel)this.ViewModel).EditCommand.Execute (null);
				return true;
			}

			return base.OnOptionsItemSelected (item);
		}
	}
}

