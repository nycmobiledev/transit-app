using System;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.CrossCore.Converters;
using System.Globalization;

namespace TransitApp.Core
{
	public class GeoLocationConverter : MvxValueConverter<MvxGeoLocation>
	{
		protected override object Convert(MvxGeoLocation location, Type targetType, object parameter, CultureInfo culture)
		{
			return string.Format ("lan: {0}, lon: {1}", location.Coordinates.Latitude, location.Coordinates.Longitude);
		}
	}

}

