using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TestTaskWPF.Common
{
    /// <summary>
    /// Конвертер DateTime в int возраст
    /// </summary>
   public class DateToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            
            DateTime NeedDate =(DateTime) value;
            
            DateTime Today = DateTime.Today;
            // Calculate the age.
            var age = Today.Year - NeedDate.Year;

            // Go back to the year the person was born in case of a leap year
            if (NeedDate.Date > Today.AddYears(-age)) age--;
            return age;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
