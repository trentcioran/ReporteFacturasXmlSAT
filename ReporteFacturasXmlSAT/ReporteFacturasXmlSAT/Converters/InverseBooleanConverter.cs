﻿using System;
using System.Windows.Data;

namespace ReporteFacturasXmlSAT.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        #region IValueConverter Members


        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return !System.Convert.ToBoolean(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}