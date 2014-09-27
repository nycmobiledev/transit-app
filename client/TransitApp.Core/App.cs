using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using TransitApp.Core.Services;
using TransitApp.Core.ViewModels;

namespace TransitApp.Core
{

    /// <summary>
    /// Define the App type.
    /// </summary>
    public class App : MvxApplication
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override void Initialize()
        {
            Cirrious.MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();

            this.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

#if MOCK
            Cirrious.CrossCore.Mvx.LazyConstructAndRegisterSingleton<IWebService, MockWebService>();
            Cirrious.CrossCore.Mvx.LazyConstructAndRegisterSingleton<IFollowService, MockFollowService>();

#else
            Cirrious.CrossCore.Mvx.LazyConstructAndRegisterSingleton<IWebService, WebService>();
            Cirrious.CrossCore.Mvx.LazyConstructAndRegisterSingleton<IFollowService, FollowService>();
#endif

            this.RegisterAppStart(new AppStart());            
        }        
    }

    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
            // thinking use setting, not Following is zero.
            if (Cirrious.CrossCore.Mvx.Resolve<IFollowService>().GetFollows().Count == 0)
            {
                this.ShowViewModel<SearchViewModel>(new { IsFirst = "true" });
            }
            else
            {
                this.ShowViewModel<HomeViewModel>();
            }
        }
    }
}