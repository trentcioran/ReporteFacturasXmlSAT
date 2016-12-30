using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace ReporteFacturasXmlSAT.Converters
{
    [ContentProperty("Converters")]
    public class GroupConverter : IValueConverter, IMultiValueConverter
    {
        public IMultiValueConverter MultiValueConverter { get; set; }

        private List<IValueConverter> _converters = new List<IValueConverter>();
        public List<IValueConverter> Converters
        {
            get { return _converters; }
            set { _converters = value; }
        }

        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GroupConvert(value, Converters);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GroupConvertBack(value, Converters.ToArray().Reverse());
        }

        private static object GroupConvert(object value, IEnumerable<IValueConverter> converters)
        {
            return converters.Aggregate(value, (acc, conv) =>
                    conv.Convert(acc, typeof(object), null, null));
        }

        private static object GroupConvertBack(object value, IEnumerable<IValueConverter> converters)
        {
            return converters.Aggregate(value, (acc, conv) =>
                    conv.ConvertBack(acc, typeof(object), null, null));
        }
        #endregion

        #region IMultiValueConverter Members
        private readonly InvalidOperationException _multiValueConverterUnsetException =
            new InvalidOperationException("To use the converter as a MultiValueConverter the MultiValueConverter property needs to be set.");

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (MultiValueConverter == null) throw _multiValueConverterUnsetException;
            var firstConvertedValue = MultiValueConverter.Convert(values, targetType, parameter, culture);
            return GroupConvert(firstConvertedValue, Converters);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (MultiValueConverter == null) throw _multiValueConverterUnsetException;
            var tailConverted = GroupConvertBack(value, Converters.ToArray().Reverse());
            return MultiValueConverter.ConvertBack(tailConverted, targetTypes, parameter, culture);
        }

        #endregion
    }
}