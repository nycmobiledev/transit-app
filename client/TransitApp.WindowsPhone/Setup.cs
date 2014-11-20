// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the Setup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TransitApp.WindowsPhone
{
    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.BindingEx.WindowsShared;
    using Cirrious.MvvmCross.ViewModels;
    using Cirrious.MvvmCross.WindowsPhone.Platform;
    using Microsoft.Phone.Controls;
    using TransitApp.Core;
    using TransitApp.Core.Interfaces;
    using TransitApp.WindowsPhone.Helpers;

    /// <summary>
    ///    Defines the Setup type.
    /// </summary>
    public class Setup : MvxPhoneSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setup"/> class.
        /// </summary>
        /// <param name="rootFrame">The root frame.</param>
        public Setup(PhoneApplicationFrame rootFrame)
            : base(rootFrame)
        {
        }

        /// <summary>
        /// Creates the app.
        /// </summary>
        /// <returns>An instance of IMvxApplication.</returns>
        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterSingleton<IViewModelDialog>(() => new ViewModelDialog());
            Mvx.RegisterSingleton<IMessageDialog>(() => new WP8MessageDialog());
            Mvx.RegisterSingleton<IConnectivity>(() => new NetworkConnectivityHelper());
            return new Core.App();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            var builder = new MvxWindowsBindingBuilder();
            builder.DoRegistration();
        }
    }
}