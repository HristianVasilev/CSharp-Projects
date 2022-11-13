namespace QA_Probation.Steps
{
    using QA_Probation.Pages;

    public class LoginSteps : BaseSteps
    {
        private static string baseUrl => GetBaseUrl("LoginPage");

        #region Pages
        private LoginPage loginPage;
        #endregion

        public LoginSteps() : this(baseUrl)
        {
        }

        public LoginSteps(string baseUrl) : base(baseUrl)
        {
            loginPage = new LoginPage();
        }

        /// <summary>
        /// Fills a particular email address to 'Email' input field.
        /// </summary>
        /// <param name="emailAddress">The email address to fill.</param>
        public void EnterEmailAddress(string emailAddress)
        {
            Logger.Info("Enter '{0}' into Email field.", emailAddress);
            loginPage.EmailInputField.SendKeys(emailAddress);
        }

        /// <summary>
        /// Fills a particular password to 'Password' input field.
        /// </summary>
        /// <param name="password">The password to fill.</param>
        public void EnterPasswod(string password)
        {
            Logger.Info("Enter '{0}' into Password field.", password);
            loginPage.PasswordInputField.SendKeys(password);
        }

        /// <summary>
        /// Clicks on 'Log in' button.
        /// </summary>
        public void ClickLoginButton()
        {
            Logger.Info("Click on 'Log in' button.");
            loginPage.LoginButton.Click();
        }
    }
}
