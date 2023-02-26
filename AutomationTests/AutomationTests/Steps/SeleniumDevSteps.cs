namespace AutomationTests.Steps
{
    using AutomationTests.PageObjects;
    using AutomationTests.Utils;
    using OpenQA.Selenium;
    using System.Collections.ObjectModel;
    using static AutomationTests.Steps.Sample.BaseSteps;

    public class SeleniumDevSteps
    {
        private readonly SeleniumDevPO seleniumDevPO = new();

        public void OpenPage()
        {
            Driver.Navigate().GoToUrl(seleniumDevPO.Url);
        }

        public void ClickOnWebDriverReadMoreButton()
        {
            seleniumDevPO.WebDriverReadMoreButton.Click();
        }

        public ReadOnlyCollection<IWebElement> GetAllDisplayedWebDriverListItems()
        {
            return seleniumDevPO.WebDriverListItems.WaitAllToBeVisible();
        }

        public ReadOnlyCollection<IWebElement> GetAllWebDriverListItems()
        {
            return seleniumDevPO.WebDriverListItems.GetElements();
        }
    }
}
