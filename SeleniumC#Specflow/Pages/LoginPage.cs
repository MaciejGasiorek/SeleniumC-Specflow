using OpenQA.Selenium;
using SeleniumCsharpSpecflow.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace SeleniumCsharpSpecflow.Pages
{
    public interface ILoginPage
    {
        public bool  VerifyIfTextIsVisible(string text);
        public void EnterUserNameAndEmail(string Name, string Email);
    }
    internal class LoginPage:ILoginPage
    {
        private readonly IDriverWait _driver;
        public LoginPage(IDriverWait driver)
        {
            _driver = driver;
        }

        //private IWebElement VerifyText(string text) => _driver.FindElement(By.XPath($"//*[normalize-space(text())='{text}']"));
        private IWebElement VerifyText(string text) => _driver.FindElement(By.XPath($"//*[contains(normalize-space(.), '{text}')]"));
        private IWebElement UserName => _driver.FindElement(By.XPath("//*[@class='signup-form']//*[@placeholder='Name']"));
        private IWebElement UserEmail => _driver.FindElement(By.XPath("//*[@class='signup-form']//*[@placeholder='Email Address']"));

        public bool VerifyIfTextIsVisible(string text) 
        {
           return  _driver.IsElementVisible(VerifyText(text));
        }

        public void EnterUserNameAndEmail(string Name, string Email) 
        {
            UserName.SendKeys(Name);
            UserEmail.SendKeys(Email);
        }

      


    }
}
