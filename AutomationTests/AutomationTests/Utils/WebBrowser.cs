namespace AutomationTests.Utils
{
    using AutomationTests.Models;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using EM = Constants.ExceptionMessages;
    using static AutomationTests.Utils.Configuration.ConfigurationSet;
    using OpenQA.Selenium.Support.UI;

    public static class WebBrowser
    {
        private const string headless = "headless";

        private static WebDriver? driver;

        private static bool Headless => IsHeadlessStateSet();

        public static WebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    throw new NullReferenceException(
                        string.Format(EM.NotInstantiated, nameof(Driver)));
                }

                return driver;
            }
        }

        public static WebDriverWait Wait
        {
            get
            {
                return new(Driver, TimeSpan.FromSeconds(5));
            }
        }

        public static WebDriver CreateDriver(Browser browserType)
        {
            driver = browserType switch
            {
                Browser.Chrome => CreateChromeDriver(),
                Browser.Edge => CreateEdgeDriver(),
                Browser.Firefox => CreateFirefoxDriver(),
                Browser.Safari => CreateSafariDriver(),
                _ => throw new NotImplementedException(
                    string.Format(EM.BrowserTypeIsNotImplemented, browserType.ToString())),
            };

            return driver;
        }

        private static WebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();

            if (Headless)
            {
                // Set 'headless' mode.
                options.AddArgument("--headless");

                // Disable images in order to make test execution faster.
                options.AddArgument("blink-settings=imagesEnabled=false");
            }

            return new ChromeDriver(options);
        }

        private static WebDriver CreateEdgeDriver()
        {
            throw new NotImplementedException();
        }

        private static WebDriver CreateFirefoxDriver()
        {
            throw new NotImplementedException();
        }

        private static WebDriver CreateSafariDriver()
        {
            throw new NotImplementedException();
        }

        private static bool IsHeadlessStateSet()
        {
            var sectionValue = Config.GetSection(headless)?.Value;

            if (sectionValue == null)
            {
                throw new ArgumentNullException(
                    string.Format(EM.SectionValueIsNull, headless));
            }

            var headlessValue = bool.Parse(sectionValue);

            return headlessValue;
        }
    }
}
