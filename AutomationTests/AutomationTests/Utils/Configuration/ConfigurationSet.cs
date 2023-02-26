namespace AutomationTests.Utils.Configuration
{
    using Microsoft.Extensions.Configuration;
    using System;

    public static class ConfigurationSet
    {
        public static IConfigurationRoot Config
        {
            get
            {
                return new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
            }
        }
    }
}
