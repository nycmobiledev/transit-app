using System;
using System.Collections;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.CrossCore.Converters;
using System.Globalization;
using TransitApp.Core.Models;
using System.Collections.Generic;

namespace TransitApp.WindowsPhone
{
	public class IsFollowedToOpacityConverter : MvxValueConverter<bool, float>
	{
		protected override float Convert(bool isFollow, Type targetType, object parameter, CultureInfo culture)
		{
            return isFollow ? 1f : 0.3f;
		}
	}
}
