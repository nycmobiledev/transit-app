// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the SplashScreen type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TransitApp.Droid
{
    using Android.App;
	using Android.Content;

    using Cirrious.MvvmCross.Droid.Views;

    /// <summary> 
    /// Defines the SplashScreen type.
    /// </summary>
    [Activity(Label = "Where Is My Subway", MainLauncher = true, Icon = "@drawable/icon", NoHistory = true, Theme = "@style/Theme.Splash")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen"/> class.
        /// </summary>
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}