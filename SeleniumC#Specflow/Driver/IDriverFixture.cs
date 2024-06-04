using OpenQA.Selenium;

namespace SeleniumCsharpSpecflow.Driver
{
    public interface IDriverFixture
    {
        IWebDriver Driver { get; }
        public string TakeScreenshotAsPath(string fileName);
    }
}