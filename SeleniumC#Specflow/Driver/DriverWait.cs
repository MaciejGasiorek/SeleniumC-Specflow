using SeleniumCsharpSpecflow.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace SeleniumCsharpSpecflow.Driver
{
    public class DriverWait: IDriverWait
    {
        private readonly IDriverFixture _driverFixture;
        private readonly TestSettings _testSettings;
        private readonly Lazy<WebDriverWait> _webDriverWait;

        public DriverWait(IDriverFixture driverFixture,TestSettings testSettings)
        {
            _driverFixture = driverFixture;
            _testSettings = testSettings;
            _webDriverWait = new Lazy<WebDriverWait>(GetWaitDriver);
        }

        public IWebElement FindElement(By elementLocator)
        {
            return _webDriverWait.Value.Until(_ => _driverFixture.Driver.FindElement(elementLocator));
        }

        public IEnumerable<IWebElement> FindElements(By elementLocator)
        {
            return _webDriverWait.Value.Until(_ => _driverFixture.Driver.FindElements(elementLocator));
        }

        private WebDriverWait GetWaitDriver()
        {
            return new(_driverFixture.Driver, timeout: TimeSpan.FromSeconds(_testSettings.TimeoutInternal ?? 30))
            {
                PollingInterval = TimeSpan.FromSeconds(_testSettings.TimeoutInternal ?? 1)
            };
        }

        public string GetCurrentUrl()
        {
            // Implementacja metody GetCurrentUrl
            return _driverFixture.Driver.Url;
        }

        public void MoveToElement(IWebElement element)
        {
            Actions actions = new Actions(_driverFixture.Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public bool IsElementVisible(IWebElement elementLocator)
        {
            try
            {
                return _webDriverWait.Value.Until(_ =>
                {
                    return elementLocator.Displayed;
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
