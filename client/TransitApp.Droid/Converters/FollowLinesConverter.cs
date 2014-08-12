using System;
using System.Collections;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.CrossCore.Converters;
using System.Globalization;
using TransitApp.Core.Models;
using System.Collections.Generic;

namespace TransitApp.Droid
{
    public class FollowLinesConverter : MvxValueConverter<Follow, IEnumerable<LineIcon>>
	{
		protected override IEnumerable<LineIcon> Convert(Follow follow, Type targetType, object parameter, CultureInfo culture)
		{
			var icons = new List<LineIcon> ();

            foreach (var item in follow.Station.Lines)
            {
                
            }

//			foreach (var item in follow.Startion.Line) {
//				
//			}
				return icons;
		}
	}
}
