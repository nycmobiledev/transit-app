using System;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.CrossCore.Converters;
using System.Globalization;

namespace TransitApp.Core
{
	public class ArriveTimeConverter : MvxValueConverter<DateTime, string>
	{
		protected override string Convert(DateTime date, Type targetType, object parameter, CultureInfo culture)
		{
			return (date - DateTime.UtcNow).TotalMinutes.ToString ("N0");
		}
	}
}

