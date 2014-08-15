using Android.App;
using Android.Support.V4.App;
using Android.Views;

using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Views;

using TransitApp.Core.ViewModels;
using Android.Widget;
using System.Runtime.Remoting.Contexts;

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


//			var gridview = FindViewById<GridView> (Resource.Id.gridview);
//			gridview.Adapter = new ImageAdapter (this.BaseContext);

//			gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
//				Toast.MakeText (this, args.Position.ToString (), ToastLength.Short).Show ();
//			};
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

		public class ImageAdapter : BaseAdapter
		{
			Android.Content.Context context;

			public ImageAdapter (Android.Content.Context c)
			{
				context = c;
			}

			public override int Count {
				get { return thumbIds.Length; }
			}

			public override Java.Lang.Object GetItem (int position)
			{
				return null;
			}

			public override long GetItemId (int position)
			{
				return 0;
			}

			// create a new ImageView for each item referenced by the Adapter
			public override View GetView (int position, View convertView, ViewGroup parent)
			{
				ImageView imageView;

				if (convertView == null) {  // if it's not recycled, initialize some attributes
					imageView = new ImageView (context);
					imageView.LayoutParameters = new GridView.LayoutParams (85, 85);
					imageView.SetScaleType (ImageView.ScaleType.CenterCrop);
					imageView.SetPadding (8, 8, 8, 8);
				} else {
					imageView = (ImageView)convertView;
				}

				imageView.SetImageResource (thumbIds[position]);
				return imageView;
			}

			// references to our images
			int[] thumbIds = {
				Resource.Drawable.Train_1, Resource.Drawable.Train_2,
//				Resource.Drawable.sample_4, Resource.Drawable.sample_5,
//				Resource.Drawable.sample_6, Resource.Drawable.sample_7,
//				Resource.Drawable.sample_0, Resource.Drawable.sample_1,
//				Resource.Drawable.sample_2, Resource.Drawable.sample_3,
//				Resource.Drawable.sample_4, Resource.Drawable.sample_5,
//				Resource.Drawable.sample_6, Resource.Drawable.sample_7,
//				Resource.Drawable.sample_0, Resource.Drawable.sample_1,
//				Resource.Drawable.sample_2, Resource.Drawable.sample_3,
//				Resource.Drawable.sample_4, Resource.Drawable.sample_5,
//				Resource.Drawable.sample_6, Resource.Drawable.sample_7
			};
		}
    }
}