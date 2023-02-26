namespace AutomationTests.Utils
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System.Collections.ObjectModel;
    using static SeleniumExtras.WaitHelpers.ExpectedConditions;

    public static class WebElementWaiters
    {
        private static WebDriverWait Wait => WebBrowser.Wait;

        public static IWebElement WaitToBeVisible(this By elementLocator)
        {
            return Wait.Until(ElementIsVisible(elementLocator));
        }

        public static IWebElement WaitToBeClickable(this By elementLocator)
        {
            return Wait.Until(ElementToBeClickable(elementLocator));
        }

        public static ReadOnlyCollection<IWebElement> WaitAllToBeVisible(this By elementLocator)
        {
            return Wait.Until(VisibilityOfAllElementsLocatedBy(elementLocator));
        }

        public static ReadOnlyCollection<IWebElement> WaitAllToBeVisible(this Tuple<By, By> locators)
        {
            var parentElementLocator = locators.Item1;
            var elementLocator = locators.Item2;

            var parentElement = parentElementLocator.WaitToBeVisible();

            var readOnlyCollection = parentElement.FindElements(elementLocator);

            return Wait.Until(VisibilityOfAllElementsLocatedBy(readOnlyCollection));
        }
    }
}
