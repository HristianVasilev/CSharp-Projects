namespace AutomationTests.Steps.Sample
{
    using AutomationTests.Utils;
    using OpenQA.Selenium;
    using System.Collections.ObjectModel;

    public static class BaseSteps
    {
        public static WebDriver Driver => WebBrowser.Driver;

        public static void Clear(this By locator)
        {
            locator.GetElement().Clear();
        }

        public static void Click(this By locator)
        {
            locator.GetElement().Click();
        }

        public static string GetAttribute(this By locator, string attributeName)
        {
            return locator.GetElement().GetAttribute(attributeName);
        }

        public static string GetCssValue(this By locator, string propertyName)
        {
            return locator.GetElement().GetCssValue(propertyName);
        }

        public static string GetDomAttribute(this By locator, string attributeName)
        {
            return locator.GetElement().GetDomAttribute(attributeName);
        }

        public static string GetDomProperty(this By locator, string propertyName)
        {
            return locator.GetElement().GetDomProperty(propertyName);
        }

        public static ISearchContext GetShadowRoot(this By locator)
        {
            return locator.GetElement().GetShadowRoot();
        }

        public static void SendKeys(this By locator, string text)
        {
            locator.GetElement().SendKeys(text);
        }

        public static void Submit(this By locator)
        {
            locator.GetElement().Submit();
        }

        public static IWebElement GetElement(this By locator)
        {
            return Driver.FindElement(locator);
        }

        public static ReadOnlyCollection<IWebElement> GetElements(this By locator)
        {
            return Driver.FindElements(locator);
        }

        public static ReadOnlyCollection<IWebElement> GetElements(this Tuple<By, By> locators)
        {
            var parentLocator = locators.Item1;
            var childsLocator = locators.Item2;

            var parentElement = parentLocator.GetElement();

            return parentElement.FindElements(childsLocator);
        }
    }
}
