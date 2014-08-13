// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the Setup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using TransitApp.Droid.Helpers;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;


namespace TransitApp.Droid
{
    using Android.Content;

    using Cirrious.MvvmCross.Droid.Platform;
    using Cirrious.MvvmCross.ViewModels;
    using Android.Widget;

    /// <summary>
    ///    Defines the Setup type.
    /// </summary>
    public class Setup : MvxAndroidSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setup"/> class.
        /// </summary>
        /// <param name="applicationContext">The application context.</param>
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        /// <summary>
        /// Creates the app.
        /// </summary>
        /// <returns>An instance of IMvxApplication.</returns>
        protected override IMvxApplication CreateApp()
        {
			return new Core.App();
        }

		protected override IMvxAndroidViewPresenter CreateViewPresenter()
		{
			var customPresenter = new CustomPresenter();
			Mvx.RegisterSingleton<ICustomPresenter>(customPresenter);
			return customPresenter;
		}
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<ImageView>("Alpha", v => new ImageViewAlphaTargetBinding(v)); base.FillTargetFactories(registry);}
    }
}