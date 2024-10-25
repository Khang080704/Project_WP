using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class ValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int number)
            {
                if (number > 0)
                {
                    return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 4, 175, 112)); //green
                }
                else if (number < 0)
                {
                    return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0)); //red
                }
                else
                {
                    //Do nothing
                }
            }
            return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 0)); //black
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();

    }
}
