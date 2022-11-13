namespace Common.WebDriver
{
    using NUnit.Framework.Internal;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class Browser : IWebDriver
    {
        private IWebDriver driver;
        private string url;
        private bool hasBeenClosed;

        protected Logger Logger => Utils.Utils.Logger;

        public Browser(IWebDriver driver)
        {
            this.driver = driver;
            this.hasBeenClosed = false;
        }

        public string Url
        {
            get
            {
                if (url != null) return url;
                return driver.Url;
            }
            set => url = value;
        }

        public string Title => driver.Title;

        public string PageSource => driver.PageSource;

        public string CurrentWindowHandle => driver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => driver.WindowHandles;

        public bool HasBeenClosed => hasBeenClosed;

        /// <summary>
        /// Finds the first IWebElement using the given method.
        /// </summary>
        /// <param name="by">Method</param>
        /// <returns>The element found</returns>
        public IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }

        /// <summary>
        /// Finds all IWebElements within the current context using the given mechanism.
        /// </summary>
        /// <param name="by">Mechanism</param>
        /// <returns>The elements found</returns>
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return driver.Manage();
        }

        public INavigation Navigate()
        {
            return driver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }

        /// <summary>
        /// Sets browser's window size.
        /// </summary>
        /// <param name="size">The size. (if not assigned, the window will be maximized)</param>
        public void SetWindowSize(Size size = default)
        {
            if (size != default)
            {
                Logger.Info("Set window size: '{0}x{1}'.", size.Width, size.Height);
                driver.Manage().Window.Size = size;
            }
            else
            {
                Logger.Info("Maximize window.");
                driver.Manage().Window.Maximize();
            }
        }

        /// <summary>
        /// Opens a new web page in the current browser window.
        /// </summary>
        /// <param name="url">The url to open.</param>
        public void Open(string url)
        {
            Logger.Info("Open '{0}' page in the current browser window.", url);
            Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Close the current window, quitting the browser if it is the last window currently open.
        /// </summary>
        public void Close()
        {
            Logger.Info("Current url: '{0}'.", Url);
            Logger.Info("Close browser.");
            hasBeenClosed = true;
            driver.Close();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Logger.Info("Dispose driver.");
            driver.Dispose();
        }

        /// <summary>
        /// Quits this browser, closing every associated window.
        /// </summary>
        public void Quit()
        {
            Logger.Info("Current url: '{0}'.", Url);
            Logger.Info("Quit browser. Dispose '{0}' driver.", driver.GetType().Name);
            hasBeenClosed = true;
            driver.Quit();
        }

        #region Wait methods
        private WebDriverWait wait;

        /// <summary>
        /// Wait untl the web element exists on the current page.
        /// </summary>
        /// <param name="by">Element locator</param>
        /// <param name="timeout">Time to wait</param>
        /// <returns>The web element found</returns>
        public IWebElement WaitForExistance(By by, TimeSpan timeout = default)
        {
            if (timeout == default)
            {
                var waitForExistance = int.Parse(ConfigurationManager.AppSettings["WaitForExistance"]);
                timeout = TimeSpan.FromSeconds(waitForExistance);
            }
            wait = new WebDriverWait(driver, timeout);
            return wait.Until(d => d.FindElement(by));
        }

        public IWebElement WaitForDisplayed(By by, TimeSpan timeout = default)
        {
            IWebElement webElement = WaitForExistance(by, timeout);
            wait.Until(d => d.FindElement(by).Displayed);
            return webElement;
        }

        /// <summary>
        /// Wait until the web element disappears on the current page.
        /// </summary>
        /// <param name="by">Element locator</param>
        /// <param name="timeout">Time to wait</param>
        /// <returns>True if the element disappeared, otherwise false</returns>
        public bool WaitForElementToDisappear(By by, TimeSpan timeout = default)
        {
            try
            {
                return WaitForExistance(by, timeout).Displayed;
            }
            catch (Exception)
            {
                return true;
            }
        }
        #endregion
    }
}
