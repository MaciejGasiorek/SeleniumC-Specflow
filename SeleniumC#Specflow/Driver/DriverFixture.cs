using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumCsharpSpecflow.Config;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using System.Reflection;

namespace SeleniumCsharpSpecflow.Driver
{
    public class DriverFixture : IDriverFixture, IDisposable
    {
        private readonly TestSettings _testSettings;
        public IWebDriver Driver { get; }
        public DriverFixture(TestSettings testSettings)
        {
            _testSettings = testSettings;
            Driver = _testSettings.TestRunType == TestRunType.Local ? GetWebDriver() : GetRemoteWebDriver();
            Driver.Navigate().GoToUrl(_testSettings.TestRunType == TestRunType.Local ? _testSettings.LocalApplicationUrl : _testSettings.ApplicationUrl);
            Driver.Manage().Window.Maximize();
        }
        private IWebDriver GetWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
            options.AddUserProfilePreference("profile.default_content_setting_values.popups", 2);
            options.AddUserProfilePreference("profile.default_content_setting_values.javascript", 2);
            return _testSettings.BrowserType switch
            {
                BrowserType.Chrome => new ChromeDriver(options),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Edge => new EdgeDriver(),
                _ => new ChromeDriver(options),
            };

        }

        private IWebDriver GetRemoteWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("se:recordVideo", "true");
            return _testSettings.BrowserType switch
            {
                
                BrowserType.Chrome => new RemoteWebDriver(_testSettings.GridUri,options),
                BrowserType.Firefox => new RemoteWebDriver(_testSettings.GridUri, new FirefoxOptions()),
                BrowserType.Edge => new RemoteWebDriver(_testSettings.GridUri, new EdgeOptions()),
                _ => new RemoteWebDriver(_testSettings.GridUri, new ChromeOptions())
            };

        }

        public enum BrowserType
        {
            Chrome,
            Firefox,
            Edge
        }

        public string TakeScreenshotAsPath(string fileName)
        {
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string screenshotsPath = Path.Combine(solutionDirectory, "ScreenShors");
            
            var screenshot = Driver.TakeScreenshot();
            var path = $"{screenshotsPath}//{fileName}.png";
            screenshot.SaveAsFile(path);
            return path;
        }

        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}
