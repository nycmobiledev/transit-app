using System;
using System.Collections;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.CrossCore.Converters;
using System.Globalization;
using TransitApp.Core.Models;
using System.Collections.Generic;

namespace TransitApp.Droid
{
	public class IsFollowedToAlphaConverter : MvxValueConverter<bool, int>
	{
		protected override int Convert(bool isFollow, Type targetType, object parameter, CultureInfo culture)
		{
            return isFollow ? 255 : 64;
		}
	}
}
