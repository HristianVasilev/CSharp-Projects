namespace AutomationTests.Utils.BaseComponents
{
    using AutomationTests.Utils.Configuration;
    using OpenQA.Selenium;
    using Microsoft.Extensions.Configuration;

    public abstract class BaseComponent
    {
        protected static IConfigurationRoot Config => ConfigurationSet.Config;

        protected static WebDriver Driver => WebBrowser.Driver;
    }
}
