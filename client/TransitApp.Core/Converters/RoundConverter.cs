using System;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.CrossCore.Converters;
using System.Globalization;

namespace TransitApp.Core
{
	public class DistanceConverter : MvxValueConverter<double>
	{
		protected override object Convert(double value, Type targetType, object parameter, CultureInfo culture)
		{
			return string.Format("{0}KM Away", Math.Round (value, 1));
		}
	}
}
