namespace AutomationTests.PageObjects
{
    using AutomationTests.PageObjects.Sample;
    using static AutomationTests.Constants.PageUrls;
    using OpenQA.Selenium;

    public class GooglePO : BasePageObjects
    {
        public override string Url => GetPageUrl(GoogleUrls, BaseGoogleUrl);

        public By AcceptAllButton => By.Id("L2AGLb");

        public By SearchInputField => By.XPath("//input[@name='q']");

        public By SearchButton => By.XPath("//div[@class='lJ9FBc']//input[@name='btnK']");

        public By SeleniumDevAnchor => By.XPath("//a[@href='https://www.selenium.dev/documentation/webdriver/']");
    }
}
