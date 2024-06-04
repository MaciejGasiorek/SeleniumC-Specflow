using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumCsharpSpecflow.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharpSpecflow.Pages
{
    public interface IGeneralPage
    {
        void ClickButtonByText(string text);
    }
    internal class GeneralPage: IGeneralPage
    {
        private readonly IDriverWait _driver;
        public GeneralPage(IDriverWait driver)
        {
            _driver = driver;
        }

        private IWebElement button(string text) => _driver.FindElement(By.XPath($"//*[normalize-space(text())='{text}']"));

        public void ClickButtonByText(string text)
        {
            _driver.MoveToElement(button(text));
            button(text).Click();
        }
    }
}
