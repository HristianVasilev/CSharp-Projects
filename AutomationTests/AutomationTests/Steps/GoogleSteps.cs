namespace AutomationTests.Steps
{
    using AutomationTests.PageObjects;
    using AutomationTests.Utils;
    using OpenQA.Selenium;
    using static AutomationTests.Steps.Sample.BaseSteps;

    public class GoogleSteps
    {
        private readonly GooglePO googlePO = new();

        public void OpenPage()
        {
            Driver.Navigate().GoToUrl(googlePO.Url);
        }

        public void AcceptCookies()
        {
            googlePO.AcceptAllButton.Click();
        }

        public void Search(string text)
        {
            googlePO.SearchInputField.WaitToBeVisible().SendKeys(text);

            googlePO.SearchInputField.Click();

            googlePO.SearchButton.WaitToBeClickable().Click();
        }

        public IWebElement GetSeleniumDevAnchor()
        {
            return googlePO.SeleniumDevAnchor.WaitToBeVisible();
        }
    }
}
