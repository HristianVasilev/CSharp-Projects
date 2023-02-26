namespace AutomationTests.TestCases
{
    using AutomationTests.Models;
    using AutomationTests.Utils;
    using AutomationTests.Utils.BaseComponents;
    using EM = Constants.ExceptionMessages;

    public abstract class BaseTest : BaseComponent
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var browserType = GetBrowserType();

            WebBrowser.CreateDriver(browserType);

            MaximizeWindow();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }

        private static Browser GetBrowserType()
        {
            string? browserType = Config.GetSection("browserType").Value;

            return browserType switch
            {
                "Chrome" => Browser.Chrome,
                "Edge" => Browser.Edge,
                "Firefox" => Browser.Firefox,
                "Opera" => Browser.Opera,
                "Safari" => Browser.Safari,
                _ => throw new NotImplementedException(
                    string.Format(EM.BrowserTypeIsNotImplemented, browserType?.ToString())),
            };
        }

        private static void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }
    }
}