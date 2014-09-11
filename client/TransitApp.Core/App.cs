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
            Cirrious.CrossCore.Mvx.LazyConstructAndRegisterSingleton<IWebService,WebService>();   
            Cirrious.CrossCore.Mvx.LazyConstructAndRegisterSingleton<IFollowService,FollowService>();   
#endif

            //// Start the app with the First View Model.                       
            this.RegisterAppStart<HomeViewModel>();
        }

		public static string DatabasePath { get; set;}
    }
}