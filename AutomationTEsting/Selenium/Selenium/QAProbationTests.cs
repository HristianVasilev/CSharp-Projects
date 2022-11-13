namespace Selenium
{
    using NUnit.Framework.Internal;
    using QA_Probation.Steps;
    using Tests;
    using Tests.Resources.ResourceKeys;
    using CR = QA_Probation.Enums.CountryOfResidenceDropDown;

    [TestFixture]
    public class QAProbationTests : BaseTest
    {
        private const string EMAIL_255CHAR_LONG = "randomString1randomString2randomString3randomString4randomString5randomString6randomString7randomString8randomString9randomString10randomString11randomString12randomString13randomString14randomString15randomString16randomString17randomStrin@test-email.com";
        private const string ENTER_VALID_EMAIL = "EnterValidEmail";
        private const string MAX_EMAIL_LENGTH = "MaxEmailLength";

        private const string VALID_PASSWORD = "P@ssword1";

        #region Steps
        private ApplicationSteps ApplicationSteps;
        private LoginSteps LoginSteps;
        private UserEnrollmentSteps UserEnrollmentSteps;
        #endregion

        public QAProbationTests() : base()
        {
            ApplicationSteps = new ApplicationSteps();
            LoginSteps = new LoginSteps();
            UserEnrollmentSteps = new UserEnrollmentSteps();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ApplicationSteps.Open();
            LoginSteps.EnterEmailAddress("hristian.vasilev@kontocloud.info");
            LoginSteps.EnterPasswod("C$53GHHS$OcfavDY");
            LoginSteps.ClickLoginButton();
        }

        [SetUp]
        public void Setup()
        {
            UserEnrollmentSteps.Open();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ApplicationSteps.Quit();
        }

        [TestCase("random@email.com", TestName = "TC-1000")]
        [TestCase("random_rnd33-rn.h5h63h@test-email.com", TestName = "TC-1001")]
        [TestCase(EMAIL_255CHAR_LONG, TestName = "TC-1002")]
        [Test(Description = "Input field 'Email' accepts valid email address.")]
        public void ValidEmailFormat_Accepted(string emailAddress)
        {
            UserEnrollmentSteps.EnterEmailAddress(emailAddress);
            UserEnrollmentSteps.ClickContinueButton();

            UserEnrollmentSteps.ValidateEmailErrorMessage();
        }

        [TestCase("random33-@email.com", ENTER_VALID_EMAIL, TestName = "TC-2001", Description = "The prefix contans dash.")]
        [TestCase(".random33@email.com", ENTER_VALID_EMAIL, TestName = "TC-2002", Description = "The prefix starts with period.")]
        [TestCase("random@33@email.com", ENTER_VALID_EMAIL, TestName = "TC-2003", Description = "The prefix contains '@'.")]
        [TestCase("random@email", ENTER_VALID_EMAIL, TestName = "TC-2004", Description = "Incomplete domain.")]
        [TestCase("random@test#email.com", ENTER_VALID_EMAIL, TestName = "TC-2005", Description = "The domain contains special character.")]
        [TestCase("random@email..com", ENTER_VALID_EMAIL, TestName = "TC-2006", Description = "The domain contains a sequence of periods.")]
        [TestCase("random@email-com", ENTER_VALID_EMAIL, TestName = "TC-2007", Description = "The top level part of the domain is missing.")]
        [TestCase("randomemail.com", ENTER_VALID_EMAIL, TestName = "TC-2008", Description = "'@' is missing.")]
        [TestCase($"E{EMAIL_255CHAR_LONG}", MAX_EMAIL_LENGTH, TestName = "TC-2009", Description = "256 characters-long email address.")]
        [Test(Description = "Input field 'Email' does not accept invalid email address.")]
        public void InvalidEmailFormat_NotAccepted(string emailAddress, string expectedErrorMessage_ResourceName)
        {
            UserEnrollmentSteps.EnterEmailAddress(emailAddress);
            UserEnrollmentSteps.ClickContinueButton();

            var expectedErrorMessage = ErrorMessages.GetString(expectedErrorMessage_ResourceName);
            UserEnrollmentSteps.ValidateEmailErrorMessage(expectedErrorMessage);
        }

        [TestCase(CR.Germany, "random_rnd33-rn.h5h63h@test-email.com", VALID_PASSWORD, TestName = "TC-3001")]
        [Test(Description = "'Continue' button works when all mandatory fields ('Country of Residence', 'Email', 'Password' and 'Confirmed Password') are filled with valid data.")]
        public void MantadoryInputFieldsDataIsValid_ContinueButtonWorks
            (CR countryOfResidence, string emailAddress, string password)
        {
            UserEnrollmentSteps.SelectCountryOfResidence(countryOfResidence);
            UserEnrollmentSteps.EnterEmailAddress(emailAddress);
            UserEnrollmentSteps.EnterPassword(password);
            UserEnrollmentSteps.EnterConfirmPassword(password);
            UserEnrollmentSteps.ClickContinueButton();

            UserEnrollmentSteps.ValidateContinueButtonIsDisplayed(false);
            UserEnrollmentSteps.ValidateCreateAccountButtonIsDisplayed();
        }

        [TestCase(CR.USA, "random@ttr@email.com", VALID_PASSWORD, TestName = "TC-4001")]
        [Test(Description = "'Continue' button does not work when all mandatory fields, except 'Email' are filled with valid data")]
        public void InvalidEmailFormat_ContinueButtonDoesNotWork
            (CR countryOfResidence, string emailAddress, string password)
        {
            UserEnrollmentSteps.SelectCountryOfResidence(countryOfResidence);
            UserEnrollmentSteps.EnterEmailAddress(emailAddress);
            UserEnrollmentSteps.EnterPassword(password);
            UserEnrollmentSteps.EnterConfirmPassword(password);
            UserEnrollmentSteps.ClickContinueButton();

            UserEnrollmentSteps.ValidateContinueButtonIsDisplayed();
        }
    }
}