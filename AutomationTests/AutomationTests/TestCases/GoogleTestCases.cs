namespace AutomationTests.TestCases
{
    using AutomationTests.Steps;

    public class GoogleTestCases : BaseTest
    {
        private readonly GoogleSteps googleSteps = new();

        [Test]
        public void OpenGoogleAndVerifySearchInput()
        {
            googleSteps.OpenPage();
            googleSteps.AcceptCookies();
            googleSteps.Search("Selenium Web driver");

            var seleniumDevLink = googleSteps
                .GetSeleniumDevAnchor()
                .GetAttribute("href");

            var expectedLink = "https://www.selenium.dev/documentation/webdriver/";

            Assert.That(seleniumDevLink, Is.EqualTo(expectedLink));
        }
    }
}
