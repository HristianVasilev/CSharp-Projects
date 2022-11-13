namespace QA_Probation.Steps
{
    using Common.Utils;
    using Common.WebDriver;
    using NUnit.Framework.Internal;
    using System.Xml;
    using Common.PageObjects;
    using NUnit.Framework;

    public abstract class BaseSteps
    {
        protected string baseUrl;
        protected Browser Browser => Utils.Browser;
        protected Logger Logger => Utils.Logger;

        public BaseSteps(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        /// <summary>
        /// Opens the browser.
        /// </summary>
        public void Open()
        {
            Browser.Open(baseUrl);
            Browser.SetWindowSize();
        }

        /// <summary>
        /// Closes the browser.
        /// </summary>
        public void Close()
        {
            Browser.Close();
        }

        /// <summary>
        /// Quits this browser, closing every associated window.
        /// </summary>
        public void Quit()
        {
            Browser.Quit();
        }

        protected static string GetBaseUrl(string pageName)
        {
            string path = Path.Combine("..", "..", "..", "bin", "Debug", "net6.0", "Pages", "Pages.xml");
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList xmlNode = xml.GetElementsByTagName(pageName);
            string url = xmlNode.Item(0).InnerXml;
            return url;
        }

        /// <summary>
        /// Validates whether the element is displayed or not.
        /// </summary>
        /// <param name="expectedToBeDisplayed">Expected behaviour</param>
        /// <param name="webObjectName">Name of the web object</param>
        protected void ValidateElementIsDisplayed
            (WebObject webObject, bool expectedToBeDisplayed, string webObjectName = null)
        {
            if (expectedToBeDisplayed)
            {
                Logger.Info("Valiadate '{0}' is displayed.", webObjectName);
                Assert.True(webObject.WaitForDisplayed().Displayed);
            }
            else
            {
                Logger.Info("Valiadate '{0}' is not displayed.", webObjectName);
                Assert.True(webObject.WaitForElementToDisappear()); // if the element disappears, method returns true.
            }
        }
    }
}
