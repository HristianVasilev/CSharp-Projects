namespace QA_Probation.Pages
{
    using Common.PageObjects;
    using OpenQA.Selenium;

    /// <summary>
    /// Page url: 'https://app-qa-probation.azurewebsites.net/Authentication/Login'
    /// </summary>
    public class LoginPage
    {
        public WebObject EmailInputField => new WebObject(By.Id("Email"));
        public WebObject PasswordInputField => new WebObject(By.Id("Password"));
        public WebObject LoginButton => new WebObject(By.CssSelector("input[value='Log in']"));
    }
}
