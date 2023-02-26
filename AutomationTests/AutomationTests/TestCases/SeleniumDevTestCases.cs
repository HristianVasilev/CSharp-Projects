namespace AutomationTests.TestCases
{
    using AutomationTests.Steps;
    using OpenQA.Selenium;

    public class SeleniumDevTestCases : BaseTest
    {
        private readonly SeleniumDevSteps seleniumDevSteps = new();

        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            seleniumDevSteps.OpenPage();
            seleniumDevSteps.ClickOnWebDriverReadMoreButton();
        }

        [Test]
        public void VerifyWebDriverItems_NotAllDisplayed()
        {
            Assert.Throws<WebDriverTimeoutException>(
                () => seleniumDevSteps.GetAllDisplayedWebDriverListItems());
        }

        [Test]
        public void VerifyWebDriverItems_CountOfDisplayed()
        {
            var items = seleniumDevSteps.GetAllWebDriverListItems();

            var displayed = items.Count(i => i.Displayed);
            var notDisplayed = items.Count(i => !i.Displayed);

            Assert.Multiple(() =>
            {
                Assert.That(displayed, Is.EqualTo(9));
                Assert.That(notDisplayed, Is.EqualTo(1));
            });
        }
    }
}
