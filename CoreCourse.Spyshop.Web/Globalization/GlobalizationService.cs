using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CoreCourse.Spyshop.Web.Globalization
{
    public class GlobalizationService
    {
        IHostingEnvironment _env;
        string defaultCulture = "en"; //set fallback culture here

        public GlobalizationService(IHostingEnvironment hostingEnvironment)
        {
            _env = hostingEnvironment;
        }

        /// <summary>
        /// Gets the CLDR name for the currently detected Culture
        /// </summary>
        public string GetCurrentCldrLocale()
        {
            const string localePattern = "lib\\cldr-data\\main\\{0}";
            var currentCult = CultureInfo.CurrentCulture;
            var cultureToUse = defaultCulture; //Default culture to use

            if (Directory.Exists(Path.Combine(_env.WebRootPath,
                     string.Format(localePattern, currentCult.Name))))
                cultureToUse = currentCult.Name; //use specific culture e.g. nl-BE
            else if (Directory.Exists(Path.Combine(_env.WebRootPath,
                     string.Format(localePattern, currentCult.TwoLetterISOLanguageName))))
                cultureToUse = currentCult.TwoLetterISOLanguageName; //use general culture e.g. nl
            return cultureToUse;
        }

        /// <summary>
        /// Lists all supported CLDR locales by scanning the cldr-data/main folder
        /// </summary>
        public IList<CultureInfo> GetSupportedCldrLocales()
        {
            var di = new DirectoryInfo(Path.Combine(_env.WebRootPath, @"lib\cldr-data\main"));
            return di.GetDirectories().Where(dir => dir.Name != "root")
                .Select(dir => new CultureInfo(dir.Name)).ToList();
        }

        /// <summary>
        /// List the fallback culture in case we don't support the user's culture
        /// </summary>
        public CultureInfo GetFallbackCulture()
        {
            return new CultureInfo(defaultCulture);
        }
    }

}
