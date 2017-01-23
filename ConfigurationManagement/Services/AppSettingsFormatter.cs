using ConfigurationManagement.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConfigurationManagement.Services
{
    public class AppSettingsFormatter : IAppSettingsFormatter
    {
        private readonly IConfiguration _configuration;
        private readonly Measurements _measurements;
        private readonly IOptions<Favourites> _favourites;

        public AppSettingsFormatter(IConfiguration configuration, Measurements measurements, IOptions<Favourites> favourites)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            if (measurements == null) throw new ArgumentNullException("measurements");
            if (favourites == null) throw new ArgumentNullException("favourites");

            _configuration = configuration;
            _measurements = measurements;
            _favourites = favourites;
        }

        public string Format(object input)
        {
            return JsonConvert.SerializeObject(
                new
                {
                    Content = input,
                    Mood = _configuration["Mood"],
                    Languages = GetLanguages(),
                    FirstJVMEntry = GetFirstJVMEntry(),
                    Measurements = _measurements,
                    Favourites = _favourites.Value
                }
            );
        }

        /// <summary>
        /// We're simply demonstrating how to read an array from appsettings.json using an injected 'IConfiguration' object
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, List<string>> GetLanguages()
        {
            IConfigurationSection languageSection = _configuration.GetSection("Languages");
            IEnumerable<IConfigurationSection> languageSectionMembers = languageSection.GetChildren();
            Dictionary<string, List<string>> platforms = new Dictionary<string, List<string>>();
            foreach (var platform in languageSectionMembers)
            {
                List<string> langs = (from p in platform.GetChildren() select p.Value).ToList();
                platforms.Add(platform.Key, langs);
            }
            return platforms;
        }

        /// <summary>
        /// Grab the first value from Languages -> JVM section in appsettings.json
        /// </summary>
        /// <returns></returns>
        private string GetFirstJVMEntry()
        {
            return _configuration["Languages:JVM:0"];
        }
    }
}

