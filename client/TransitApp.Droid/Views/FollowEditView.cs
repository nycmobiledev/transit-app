using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Droid.Views;
using TransitApp.Core.Services;
using TransitApp.Core.ViewModels;

namespace TransitApp.Droid.Views
{
    public class FollowEditView : MvxDialogFragment
    {
        public override Dialog OnCreateDialog(Bundle savedState)
        {
            base.EnsureBindingContextSet(savedState);

            var view = this.BindingInflate(Resource.Layout.page_followEdit_view, null);

            var dialog = new AlertDialog.Builder(Activity);
            dialog.SetTitle(((FollowEditViewModel)this.ViewModel).Station.Name);            
            dialog.SetView(view);
            dialog.SetNegativeButton("Cancel", (s, a) => { });
            dialog.SetPositiveButton("Save", (s, a) =>
                (this.ViewModel as FollowEditViewModel).SaveCommand.Execute(null)
            );
            
            return dialog.Create();
        }
    }
}

