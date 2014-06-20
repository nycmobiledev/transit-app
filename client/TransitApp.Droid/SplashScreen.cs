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
	[Activity(Label = "Where Is My Subway", MainLauncher = true, Icon = "@drawable/icon", NoHistory = true)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen"/> class.
        /// </summary>
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

		protected override void OnCreate (Android.OS.Bundle bundle)
		{
			base.OnCreate (bundle);

			//capy db file
			var db = this.GetFileStreamPath("Subway.db");

			if (!db.Exists ()) {

				var readerStream = this.Resources.OpenRawResource (Resource.Raw.Subway);
				var writerStream = this.OpenFileOutput ("Subway.db", FileCreationMode.Append);

				byte[] buffer = new byte[1024];
				int length;
				while ((length = readerStream.Read (buffer, 0, 1024)) > 0) {
					writerStream.Write (buffer, 0, length);
				}
				writerStream.Flush ();

				readerStream.Close ();
				writerStream.Close ();
			}
		}
    }
}