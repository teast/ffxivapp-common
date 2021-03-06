﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToWidthConverter.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   BooleanToWidthConverter.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Converters {
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /* TODO: Implement this
    public class BooleanToWidthConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                return (bool) value
                           ? double.NaN
                           : 0;
            }
            catch {
                return Regex.IsMatch(value.ToString(), "([Tt]rue|1)")
                           ? double.NaN
                           : 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
    */
}