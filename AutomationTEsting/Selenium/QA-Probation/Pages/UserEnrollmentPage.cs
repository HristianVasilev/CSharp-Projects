namespace QA_Probation.Pages
{
    using Common.PageObjects;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using static Common.Utils.Utils;

    /// <summary>
    /// Page url: 'https://app-qa-probation.azurewebsites.net/UserEnrollment/InitialDetails'
    /// </summary>
    public class UserEnrollmentPage
    {
        public SelectElement CountryOfResidenceDropDown => new SelectElement(Browser.FindElement(By.Id("Country")));

        public WebObject EmailInputField => new WebObject(By.Id("Email"));

        public WebObject PasswordInputField => new WebObject(By.Id("Password"));

        public WebObject ConfirmPasswordInputField => new WebObject(By.Id("ConfirmPassword"));

        public WebObject ContinueButton => new WebObject(By.CssSelector("input[value='Continue'][type='submit']"));

        public WebObject EmailErrorMessage => new WebObject(By.XPath("//span[@class='text-danger field-validation-error' and  @data-valmsg-for='Email']"));

        public WebObject CreateAccountButton => new WebObject(By.XPath("//input[@name='nextBtn' and @value='Create Account']"));
    }
}
