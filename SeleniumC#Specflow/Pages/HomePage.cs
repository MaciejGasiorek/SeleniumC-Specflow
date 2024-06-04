using OpenQA.Selenium;
using SeleniumCsharpSpecflow.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharpSpecflow.Pages
{
    public interface IHomePage
    {
        void ClickModal();
        string RerurnUrl();
        void ClickLoginButton();

    }

    internal class HomePage : IHomePage
    {
        private readonly IDriverWait _driver;
        public HomePage(IDriverWait driver)
        {
            _driver = driver;
        }

        private IWebElement Modal => _driver.FindElement(By.XPath("//*[@class='fc-button-label'][text()='Consent']"));
        private IWebElement btnLogin => _driver.FindElement(By.XPath("//*[normalize-space(text())='Signup / Login']"));

        public void ClickModal()
        {
            Modal.Click();
        }

        public void ClickLoginButton()
        {
            btnLogin.Click();
        }

        public string RerurnUrl()
        {
            return _driver.GetCurrentUrl();
        }

    }


}
