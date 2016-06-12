using System;

namespace JsonConfigurationManager
{
    public static class ConfigurationManagerAuto
    {
        public static string filePrefix = "auto_configuration_";

        public static T GetConfiguration<T>() where T : class, new()
        {
            var IsDefaultConfiguration = false;
            return GetConfiguration<T>("", out IsDefaultConfiguration);
        }

        public static T GetConfiguration<T>(string typeGrup) where T : class, new()
        {
            var IsDefaultConfiguration = false;
            return GetConfiguration<T>(typeGrup, out IsDefaultConfiguration);
        }

        public static T GetConfiguration<T>(string typeGrup, out bool IsDefaultConfiguration) where T : class, new()
        {
            var fileName = filePrefix + typeof(T).Name + (!string.IsNullOrEmpty(typeGrup) ? "_" + typeGrup.ToLower() : "") + ".json";
            return ConfigurationManager.GetConfiguration<T>(fileName, DefaultConfigurationCtor<T>, out IsDefaultConfiguration);
        }

        static private T DefaultConfigurationCtor<T>() where T : class, new()
        {
            var newObj = new T();
            newObj.GetType().GetMethod("ConfigurationInit", Type.EmptyTypes)?.Invoke(newObj, null);
            return newObj;
        }

    }
}
