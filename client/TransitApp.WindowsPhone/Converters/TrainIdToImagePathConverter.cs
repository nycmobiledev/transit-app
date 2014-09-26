using System;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.CrossCore.Converters;
using System.Globalization;

namespace TransitApp.WindowsPhone
{
    public class TrainIdToImagePathConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("/Resources/Train_{0}.png", value);
        }
    }
}
