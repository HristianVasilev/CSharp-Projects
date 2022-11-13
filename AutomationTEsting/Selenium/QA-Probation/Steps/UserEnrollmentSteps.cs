namespace QA_Probation.Steps
{
    using Common.Utils;
    using NUnit.Framework;
    using QA_Probation.Enums;
    using QA_Probation.Pages;

    public class UserEnrollmentSteps : BaseSteps
    {
        private static string baseUrl => GetBaseUrl("UserEnrollmentPage");

        private UserEnrollmentPage UserEnrollmentPage;

        public UserEnrollmentSteps() : this(baseUrl)
        {
        }

        public UserEnrollmentSteps(string baseUrl) : base(baseUrl)
        {
            UserEnrollmentPage = new UserEnrollmentPage();
        }

        /// <summary>
        /// Clicks on 'Continue' button.
        /// </summary>
        public void ClickContinueButton()
        {
            Logger.Info("Click on 'Continue' button.");
            UserEnrollmentPage.ContinueButton.Click();
        }

        /// <summary>
        /// Selects a particular option from 'Country of Residence' menu.
        /// </summary>
        public void SelectCountryOfResidence(CountryOfResidenceDropDown option)
        {
            string desc = option.GetDescription();
            Logger.Info("Select '{0}' option from 'Country of Residence' menu.", desc);
            UserEnrollmentPage.CountryOfResidenceDropDown.SelectByText(desc);
        }

        /// <summary>
        /// Enters a particular email address.
        /// </summary>
        /// <param name="emailAddress">The email address to enter</param>
        public void EnterEmailAddress(string emailAddress)
        {
            Logger.Info("Enter '{0}' email address.", emailAddress);
            UserEnrollmentPage.EmailInputField.SendKeys(emailAddress);
        }

        /// <summary>
        /// Enters a particular password.
        /// </summary>
        /// <param name="password">The password to enter</param>
        public void EnterPassword(string password)
        {
            Logger.Info("Enter '{0}' password.", password);
            UserEnrollmentPage.PasswordInputField.SendKeys(password);
        }

        /// <summary>
        /// Enters a particular password.
        /// </summary>
        /// <param name="password">The password to enter</param>
        public void EnterConfirmPassword(string password)
        {
            Logger.Info("Enter '{0}' password to confirm.", password);
            UserEnrollmentPage.ConfirmPasswordInputField.SendKeys(password);
        }

        /// <summary>
        /// Validates whether or not an error message is displayed below 'Email' input field and it's value.
        /// </summary>
        /// <param name="expectedErrorMessage">Expected error message. If no error is expected, leave the parameter null.</param>
        public void ValidateEmailErrorMessage(string expectedErrorMessage = null)
        {
            var errorMessage = UserEnrollmentPage.EmailErrorMessage;
            if (expectedErrorMessage == null)
            {
                Logger.Info("Validate no error message is displayed below 'Email' input field.");
                Assert.False(errorMessage.Displayed);
            }
            else
            {
                Logger.Info("Validate '{0}' message is displayed below 'Email' input field.", expectedErrorMessage);
                Assert.AreEqual(expectedErrorMessage, errorMessage.Text);
            }
        }

        /// <summary>
        /// Validates whether 'Continue' button is displayed or not.
        /// </summary>
        /// <param name="expectedResult">Expected behaviour</param>
        public void ValidateContinueButtonIsDisplayed(bool expectedResult = true)
        {
            ValidateElementIsDisplayed(UserEnrollmentPage.ContinueButton, expectedResult, "Continue button");
        }

        /// <summary>
        /// Validates whether 'Create Account' button is displayed or not.
        /// </summary>
        /// <param name="expectedResult">Expected behavior</param>
        public void ValidateCreateAccountButtonIsDisplayed(bool expectedResult = true)
        {
            ValidateElementIsDisplayed(UserEnrollmentPage.CreateAccountButton, expectedResult, "Create Account button");
        }
    }
}
