// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SoundPlayerHelper.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   SoundPlayerHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Helpers {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using FFXIVAPP.Common.Audio;
    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.RegularExpressions;
    using FFXIVAPP.Common.Utilities;

    using NLog;

    public static class SoundPlayerHelper {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        // TODO: Implement this
        //private static readonly Dictionary<string, CachedSound> SoundFiles = new Dictionary<string, CachedSound>();

        /// <summary>
        /// </summary>
        public static void CacheSoundFiles() {
            try {
                if (!Directory.Exists(Constants.SoundsPath)) {
                    Directory.CreateDirectory(Constants.SoundsPath);
                }

                List<FileInfo> soundFiles = new List<FileInfo>();
                List<string> filters = new List<string> {
                    "*.wav",
                    "*.mp3"
                };
                foreach (var filter in filters) {
                    IEnumerable<FileInfo> files = Directory.GetFiles(Constants.SoundsPath, filter, SearchOption.AllDirectories).Select(file => new FileInfo(file));
                    soundFiles.AddRange(files);
                }

                Task.Run(delegate {
                    foreach (FileInfo soundFile in soundFiles) {
                        if (soundFile.DirectoryName == null) {
                            continue;
                        }

                        var baseKey = soundFile.DirectoryName.Replace(Constants.SoundsPath, string.Empty);
                        var key = string.IsNullOrWhiteSpace(baseKey)
                                      ? soundFile.Name
                                      : $"{baseKey.Substring(1)}\\{soundFile.Name}";
                        if (SoundFileKeys(false).Contains(key)) {
                            continue;
                        }

                        TryGetSetSoundFile(key);
                    }

                    return true;
                });
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }
        }

        public static bool PlayCached(string soundFile, int volume = 100) {
            /* TODO: Implement this
            var success = true;
            var fileName = Regex.Replace(soundFile, @"[\\/]+", "\\", SharedRegEx.DefaultOptions);
            try {
                CachedSound value;
                if (!SoundFiles.TryGetValue(fileName, out value)) {
                    value = TryGetSetSoundFile(fileName, volume);
                }

                AudioPlaybackEngine.Instance.PlaySound(value, volume);
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
                success = false;
            }

            return success;
            */
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="refreshCache"></param>
        /// <returns></returns>
        public static List<string> SoundFileKeys(bool refreshCache = true) {
            if (refreshCache) {
                CacheSoundFiles();
            }

            /* TODO: Implement this
            lock (SoundFiles) {
                if (SoundFiles.Any()) {
                    return SoundFiles.Select(soundFile => soundFile.Key).OrderBy(key => key).ToList();
                }

                return new List<string>();
            }
            */
            return new List<string>();
        }

       public static object TryGetSetSoundFile(string soundFile, int volume = 100) {
           return null;
       }
        /* TODO: Implement this
       public static CachedSound TryGetSetSoundFile(string soundFile, int volume = 100) {
            var fileName = Regex.Replace(soundFile, @"[\\/]+", "\\", SharedRegEx.DefaultOptions);
            lock (SoundFiles) {
                try {
                    CachedSound value;
                    if (SoundFiles.TryGetValue(fileName, out value)) {
                        return value;
                    }

                    value = new CachedSound(Path.Combine(Constants.SoundsPath, fileName));
                    SoundFiles.Add(fileName, value);
                    return value;
                }
                catch (Exception) {
                    return null;
                }
            }
        }
        */
    }
}