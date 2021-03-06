﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XValuePair.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   XValuePair.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Models {
    public class XValuePair {
        public string Key { get; set; }

        public string Value { get; set; }

        public object[] Values { get; set; }
    }
}