using OpenQA.Selenium;

namespace SeleniumCsharpSpecflow.Driver
{
    public interface IDriverWait
    {
        IWebElement FindElement(By elementLocator);

        IEnumerable<IWebElement> FindElements(By elementLocator);
        string GetCurrentUrl();
        bool IsElementVisible(IWebElement elementLocator);

        void MoveToElement(IWebElement element);
    }
}