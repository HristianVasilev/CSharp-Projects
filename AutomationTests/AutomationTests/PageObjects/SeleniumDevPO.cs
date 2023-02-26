namespace AutomationTests.PageObjects
{
    using AutomationTests.PageObjects.Sample;
    using static AutomationTests.Constants.PageUrls;
    using OpenQA.Selenium;

    public class SeleniumDevPO : BasePageObjects
    {
        public override string Url => GetPageUrl(SeleniumDevUrls, BaseSeleniumDevUrl);

        public By WebDriverSection => By.Id("m-documentationwebdriver-li");

        public Tuple<By, By> WebDriverListItems
            => new(WebDriverSection,
                By.XPath(".//li[contains(@class,'td-sidebar-nav__section with-child')]"));

        public By WebDriverReadMoreButton
            => By.CssSelector(".selenium-button.selenium-webdriver.text-uppercase.font-weight-bold");
    }
}
