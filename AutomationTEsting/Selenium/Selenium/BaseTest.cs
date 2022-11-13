namespace Tests
{
    using NUnit.Framework.Internal;

    public abstract class BaseTest
    {
        protected Logger Logger;

        public BaseTest()
        {
            Logger = Common.Utils.Utils.Logger;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var className = TestContext.CurrentContext.Test.ClassName;
            Logger.Info("--- Start tests from class name: '{0}'", className);
        }

        [SetUp]
        public void SetUp()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            Logger.Info("-- Start test: '{0}'", testName);
        }

        [TearDown]
        public void TearDown()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            Logger.Info("-- End test: '{0}'", testName);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var className = TestContext.CurrentContext.Test.ClassName;
            Logger.Info("--- End tests from class name: '{0}'", className);
        }
    }
}
