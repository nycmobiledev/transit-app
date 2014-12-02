using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using TransitApp.Core.ViewModels;
using TransitApp.Droid.Helpers;
using TransitApp.Droid.Views.Fragments;
using Com.Uservoice.Uservoicesdk;
using TransitApp.Core.Services;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace TransitApp.Droid.Views
{
    [Activity(Label = "Home", LaunchMode = LaunchMode.SingleTop, ScreenOrientation = ScreenOrientation.Portrait)]
    public class HomeView : MvxFragmentActivity, IFragmentHost
    {
        private DrawerLayout _drawer;
        private MyActionBarDrawerToggle _drawerToggle;
        private string _drawerTitle;
        private string _title;
        private MvxListView _drawerList;
        private HomeViewModel m_ViewModel;

        public new HomeViewModel ViewModel
        {
            get { return this.m_ViewModel ?? (this.m_ViewModel = base.ViewModel as HomeViewModel); }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Android.Content.Context ctx = this.ApplicationContext;
            Java.Lang.Object svc = ctx.GetSystemService(ConnectivityService);
            SetContentView(Resource.Layout.page_home_view);

            this._title = this._drawerTitle = this.Title;
            this._drawer = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            this._drawerList = this.FindViewById<MvxListView>(Resource.Id.left_drawer);

            this._drawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityFlags.Start);

            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
            this.ActionBar.SetHomeButtonEnabled(true);

            //DrawerToggle is the animation that happens with the indicator next to the
            //ActionBar icon. You can choose not to use this.
            this._drawerToggle = new MyActionBarDrawerToggle(this, this._drawer,
                                                      Resource.Drawable.ic_drawer_light,
                                                      Resource.String.drawer_open,
                                                      Resource.String.drawer_close);

            //You can alternatively use _drawer.DrawerClosed here
            this._drawerToggle.DrawerClosed += delegate
            {
                this.ActionBar.Title = this._title;
                this.InvalidateOptionsMenu();
            };

            //You can alternatively use _drawer.DrawerOpened here
            this._drawerToggle.DrawerOpened += delegate
            {
                this.ActionBar.Title = this._drawerTitle;
                this.InvalidateOptionsMenu();
            };

            this._drawer.SetDrawerListener(this._drawerToggle);

            this.RegisterForDetailsRequests();

            if (null == savedInstanceState)
            {
                this.ViewModel.SelectMenuItemCommand.Execute(this.ViewModel.MenuItems[0]);
            }

            UserVoice.Init(new Com.Uservoice.Uservoicesdk.Config("nycmobiledev.uservoice.com"), this);
        }

        /// <summary>
        /// Use the custom presenter to determine if we can navigate forward.
        /// </summary>
        private void RegisterForDetailsRequests()
        {
            var customPresenter = Mvx.Resolve<ICustomPresenter>();
            customPresenter.Register(typeof(AlertsViewModel), this);
            customPresenter.Register(typeof(AboutViewModel), this);
            customPresenter.Register(typeof(HelpViewModel), this);
            customPresenter.Register(typeof(FollowsViewModel), this);
        }

        /// <summary>
        /// Read all about this, but this is a nice way if there were multiple
        /// fragments on the screen for us to decide what and where to show stuff
        /// See: http://enginecore.blogspot.ro/2013/06/more-dynamic-android-fragments-with.html
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool Show(MvxViewModelRequest request)
        {
            try
            {
                MvxFragment frag = this.SupportFragmentManager.FindFragmentById(Resource.Id.content_frame) as MvxFragment;
                if (frag != null && frag.ViewModel.GetType() == request.ViewModelType)
                {
                    return true;
                }

                string title;
				var fragmentTransaction = this.SupportFragmentManager.BeginTransaction();
                if (request.ViewModelType == typeof(AlertsViewModel))
                {
                    frag = new AlertsView();
                    frag.ViewModel = ViewModel.AlertsViewModel;
					this._drawerList.SetItemChecked(this.ViewModel.MenuItems.FindIndex(m => m.Section == request.ViewModelType), true);
					fragmentTransaction = fragmentTransaction.Replace( Resource.Id.content_frame, frag );
                    title = "Schedule";
                }
				else if (request.ViewModelType == typeof(FollowsViewModel))
				{
					title = "Stations Followed";
					frag = new FollowsView();
					frag.ViewModel = new FollowsViewModel(Mvx.Resolve<IFollowService>(), Mvx.Resolve<IMvxMessenger>());
					fragmentTransaction = fragmentTransaction
						.SetCustomAnimations(Resource.Animation.slide_in_bottom,Android.Resource.Animation.FadeOut,Android.Resource.Animation.FadeIn, Resource.Animation.slide_out_bottom)
						.Replace(Resource.Id.content_frame, frag)
						.AddToBackStack(title);
					ActionBar.SetDisplayHomeAsUpEnabled(true);

				}
                else if (request.ViewModelType == typeof(AboutViewModel))
                {
                    frag = new AboutView();
                    frag.ViewModel = ViewModel.AboutViewModel;
					this._drawerList.SetItemChecked(this.ViewModel.MenuItems.FindIndex(m => m.Section == request.ViewModelType), true);
					fragmentTransaction = fragmentTransaction.Replace( Resource.Id.content_frame, frag );
                    title = "About";
                }else if (request.ViewModelType == typeof(HelpViewModel))
                {			
                    //Break rule, HelpViewModel doesn't have Android View.
					UserVoice.LaunchUserVoice(this);
					return true;
                }
                else
                {
                    return false;
                }

                //Normally we would do this, but we already have it


                fragmentTransaction.Commit();
                
                this.ActionBar.Title = this._title = title;

                return true;
            }
            catch (RemoteException ex)
            {
                string str = ex.Message;
                return false;
            }
            finally
            {
                this._drawer.CloseDrawer(this._drawerList);
            }
        }



        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            this._drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            this._drawerToggle.OnConfigurationChanged(newConfig);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //MenuInflater.Inflate(Resource.Menu.main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            var drawerOpen = this._drawer.IsDrawerOpen(this._drawerList);
            //when open down't show anything
            for (int i = 0; i < menu.Size(); i++)
                menu.GetItem(i).SetVisible(!drawerOpen);

            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (this._drawerToggle.OnOptionsItemSelected(item))
                return true;

            return base.OnOptionsItemSelected(item);
        }
    }
}