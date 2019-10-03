using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppOne.Infrastructure
{
    public static class UrlHelpers
    {
        /// <summary>
        /// New Extension Method klasy UrlHelper
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="genreIconFilename"></param>
        /// <returns></returns>
        public static string GenreIconPath(this UrlHelper helper, string genreIconFilename)
        {
            var genreIconFolder = AppConfig.GenreIconsFolderRelative;
            var path = Path.Combine(genreIconFolder, genreIconFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string AlbumCoverPath(this UrlHelper helper, string albumFileName)
        {
            var albumCoverFolder = AppConfig.PhotosFolderRelative;
            var path = Path.Combine(albumCoverFolder, albumFileName);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}