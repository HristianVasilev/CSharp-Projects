namespace Common.PageObjects
{
    using Common.WebDriver;
    using NUnit.Framework.Internal;
    using OpenQA.Selenium;
    using System;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Drawing;

    public class WebObject : IWebElement
    {
        private By by;
        private Browser Browser => Utils.Utils.Browser;
        private Logger Logger => Utils.Utils.Logger;
        private IWebElement webElement => Browser.FindElement(by);

        public WebObject(By by)
        {
            this.by = by;
        }

        /// <summary>
        /// Gets the tag name of this element.
        /// </summary>
        public string TagName => webElement.TagName;

        /// <summary>
        /// Gets the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed.
        /// </summary>
        public string Text => webElement.Text;

        /// <summary>
        /// Gets a value indicating whether or not this element is enabled.
        /// </summary>
        public bool Enabled => webElement.Enabled;

        /// <summary>
        /// Gets a value indicating whether or not this element is selected.
        /// </summary>
        public bool Selected => webElement.Selected;

        /// <summary>
        /// Gets a Point object containing the coordinates of the upper-left corner of this element relative to the upper-left corner of the page.
        /// </summary>
        public Point Location => webElement.Location;

        /// <summary>
        /// Gets a Size object containing the height and width of this element.
        /// </summary>
        public Size Size => webElement.Size;

        /// <summary>
        /// Gets a value indicating whether or not this element is displayed.
        /// </summary>
        public bool Displayed => IsDisplayed();

        #region Wait methods
        /// <summary>
        /// Wait untl the web element exists on the current page.
        /// </summary>
        /// <param name="timeout">Time to wait</param>
        /// <returns>The web element found</returns>
        public WebObject WaitForExistance(TimeSpan timeout = default)
        {
            if (timeout == default)
            {
                var waitForExistance = int.Parse(ConfigurationManager.AppSettings["WaitForExistance"]);
                timeout = TimeSpan.FromSeconds(waitForExistance);
            }
            var element = Browser.WaitForExistance(by, timeout);
            return this;
        }

        public WebObject WaitForDisplayed(TimeSpan timeout = default)
        {
            if (timeout == default)
            {
                var waitForExistance = int.Parse(ConfigurationManager.AppSettings["WaitForExistance"]);
                timeout = TimeSpan.FromSeconds(waitForExistance);
            }
            var element = Browser.WaitForDisplayed(by, timeout);
            return this;
        }

        /// <summary>
        /// Wait until the web element disappears on the current page.
        /// </summary>
        /// <param name="timeout">Time to wait</param>
        /// <returns>True if the element disappeared, otherwise false</returns>
        public bool WaitForElementToDisappear(TimeSpan timeout = default)
        {
            if (timeout == default)
            {
                var waitForExistance = int.Parse(ConfigurationManager.AppSettings["WaitForExistance"]);
                timeout = TimeSpan.FromSeconds(waitForExistance);
            }
            return Browser.WaitForElementToDisappear(by, timeout);
        }
        #endregion

        #region Action methods
        /// <summary>
        /// Clears the content of this element.
        /// </summary>
        public void Clear()
        {
            webElement.Clear();
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
        public void Click()
        {
            webElement.Click();
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="text">Text to type</param>
        public void SendKeys(string text)
        {
            webElement.SendKeys(text);
        }

        /// <summary>
        /// Submits this element to the web server.
        /// </summary>
        public void Submit()
        {
            webElement.Submit();
        }
        #endregion

        #region Find element/s methods
        /// <summary>
        /// Finds the first IWebElement using the given method.
        /// </summary>
        /// <param name="by">Method</param>
        /// <returns>The element found</returns>
        public IWebElement FindElement(By by)
        {
            return webElement.FindElement(by);
        }

        /// <summary>
        /// Finds all IWebElements within the current context using the given mechanism.
        /// </summary>
        /// <param name="by">Mechanism</param>
        /// <returns>The elements found</returns>
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return webElement.FindElements(by);
        }
        #endregion

        #region Get methods
        public string GetAttribute(string attributeName)
        {
            return webElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return webElement.GetCssValue(propertyName);
        }

        public string GetDomAttribute(string attributeName)
        {
            return webElement.GetDomAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName)
        {
            return webElement.GetDomProperty(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            return webElement.GetShadowRoot();
        }
        #endregion

        #region Help methods
        private bool IsDisplayed()
        {
            try
            {
                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion
    }
}
