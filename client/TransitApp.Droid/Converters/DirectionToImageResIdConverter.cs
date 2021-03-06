using System;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.CrossCore.Converters;
using System.Globalization;

namespace TransitApp.Droid
{
	public class DirectionToImageResIdConverter : MvxValueConverter<string, int>
	{
		public const string NORTH = "N";
		public const string SOUTH = "S";

		protected override int Convert(string aDirection, Type targetType, object parameter, CultureInfo culture)
		{
			return NORTH == aDirection ? Resource.Drawable.ic_publish_grey600_24dp : Resource.Drawable.ic_file_download_grey600_24dp ;
		}
	}
}
