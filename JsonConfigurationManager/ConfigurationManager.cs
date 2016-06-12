using System;
using System.IO;
using Newtonsoft.Json;

namespace JsonConfigurationManager
{
    public static class ConfigurationManager
    {
        public static T GetConfiguration<T>(string fileName) where T : class, new()
        {
            bool IsDefaultConfiguration;
            return GetConfiguration<T>(fileName, null, out IsDefaultConfiguration);
        }

        public static T GetConfiguration<T>(string fileName, Func<T> defaultConfiguration = null) where T : class, new()
        {
            bool IsDefaultConfiguration;
            return GetConfiguration<T>(fileName, defaultConfiguration, out IsDefaultConfiguration);
        }

        public static T GetConfiguration<T>(string fileName, Func<T> defaultConfiguration, out bool IsDefaultConfiguration) where T : class, new()
        {
            IsDefaultConfiguration = !File.Exists(fileName);
            if (!IsDefaultConfiguration)
            {
                return DeserializeObject<T>(File.ReadAllText(fileName));
            }
            if (defaultConfiguration == null)
            {
                return null;
            }
            var back = defaultConfiguration();
            var path = Path.Combine(System.Environment.CurrentDirectory, fileName);
            File.WriteAllText(path, SerializeObject(back));
            return back;
        }

        static string SerializeObject(object value)
            => JsonConvert.SerializeObject(value, Formatting.Indented);

        static T DeserializeObject<T>(string value)
            => JsonConvert.DeserializeObject<T>(value);
    }
}
