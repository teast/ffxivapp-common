// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageUtilities.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ImageUtilities.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Utilities {
    using Avalonia.Media.Imaging;

    public static class ImageUtilities {
        public static Bitmap LoadImageFromStream(string location) {
            Bitmap result = null;
            if (location != null) {
                var bitmapImage = new Bitmap(location);
                result = bitmapImage;
            }

            return result;
        }
    }
}