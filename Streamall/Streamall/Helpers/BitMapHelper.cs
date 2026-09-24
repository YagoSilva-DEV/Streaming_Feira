using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Streamall.Helpers
{
    internal class BitMapHelper : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            if (value == null)
                return null;

            string path = value.ToString();

            if (string.IsNullOrWhiteSpace(path))
                return null;

            try
            {
                BitmapImage image = new BitmapImage();

                image.BeginInit();
                image.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                image.Freeze();

                return image;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (NotSupportedException)
            {
                return null;
            }
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
