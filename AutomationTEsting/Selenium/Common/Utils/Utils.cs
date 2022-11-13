namespace Common.Utils
{
    using Common.WebDriver;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using NUnit.Framework.Internal;
    using System.Configuration;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Edge;

    public static class Utils
    {
        private static Browser browser;
        private static Logger logger;

        private static IWebDriver webDriver;
        public static Browser Browser => GetBrowser();
        public static Logger Logger => GetLogger();

        #region Help methods
        private static Browser CreateBrowser()
        {
            var browserType = ConfigurationManager.AppSettings["Browser"];

            switch (browserType)
            {
                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    webDriver = new ChromeDriver(chromeOptions);
                    break;
                case "FireFox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    webDriver = new FirefoxDriver(firefoxOptions);
                    break;
                case "Edge":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    webDriver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    throw new NotImplementedException
                        (String.Format("Driver: '{0}' is not implemented!", browserType));
            }

            Logger.Info("'{0}' driver is created.", webDriver.GetType().Name);
            Logger.Info("Clear all cookies.");
            webDriver.Manage().Cookies.DeleteAllCookies();
            return new Browser(webDriver);
        }

        private static Browser GetBrowser()
        {
            if (browser == null || browser.HasBeenClosed)
            {
                browser = CreateBrowser();
            }
            return browser;
        }

        private static Logger GetLogger()
        {
            if (logger == null)
            {
                logger = new Logger(String.Empty, InternalTraceLevel.Info, Console.Out);
            }
            return logger;
        }
        #endregion
    }
}
