using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCsharpSpecflow.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharpSpecflow.Pages
{
    public interface ISignUpPage
    {
        public bool VerifyIfTextIsVisible(string text);
        public void FillSignUpdetails(string title, string name, string email, string password, DateTime dateOfBirth);
        public void ClickCheckBox(string checkboxLabel);
        public void FillDetails(string firstName, string lastName, string company, string address, string address2, string country, string state, string city, string zipcode, string mobileNumber);
    }
    internal class SignUpPage:ISignUpPage
    {
        

        private readonly IDriverWait _driver;

        private IWebElement Title(string title) => _driver.FindElement(By.XPath($"//*[@class = 'radio-inline' and contains(.,'{title}')]//input "));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement Days=> _driver.FindElement(By.Id("days"));
        private IWebElement Month => _driver.FindElement(By.Id("months"));
        private IWebElement Year => _driver.FindElement(By.Id("years"));
        private IWebElement CheckBox(string checkboxLabel) => _driver.FindElement(By.XPath($"//*[@class='checkbox' and contains(.,'{checkboxLabel}')]//input"));
        private IWebElement FirstName => _driver.FindElement(By.Id("first_name"));
        private IWebElement LastName => _driver.FindElement(By.Id("last_name"));
        private IWebElement Company => _driver.FindElement(By.Id("company"));
        private IWebElement Address => _driver.FindElement(By.Id("address1"));
        private IWebElement Address2 => _driver.FindElement(By.Id("address2"));
        private IWebElement Country => _driver.FindElement(By.Id("country"));
        private IWebElement State => _driver.FindElement(By.Id("state"));
        private IWebElement City => _driver.FindElement(By.Id("city"));
        private IWebElement Zipcode => _driver.FindElement(By.Id("zipcode"));
        private IWebElement MobileNumber => _driver.FindElement(By.Id("mobile_number"));

        public SignUpPage(IDriverWait driver)
        {
            _driver = driver;
        }

        public bool VerifyIfTextIsVisible(string text)
        {
            return true;
        }

        public void FillSignUpdetails(string title, string name, string email, string password, DateTime dateOfBirth)
        {
            Title(title).Click();
            Password.SendKeys(password);


            Days.SendKeys(Convert.ToString(dateOfBirth.Day));

            var selectElement = new SelectElement(Month);
            selectElement.SelectByValue(Convert.ToString(dateOfBirth.Month));

            Year.SendKeys(Convert.ToString(dateOfBirth.Year));

        }

        public void ClickCheckBox(string checkboxLabel)
        {
            _driver.MoveToElement(CheckBox(checkboxLabel));
            CheckBox(checkboxLabel).Click();
        }

        public void FillDetails(string firstName, string lastName, string company, string address, string address2, string country, string state, string city, string zipcode, string mobileNumber)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Company.SendKeys(company);
            Address.SendKeys(address);
            Address2.SendKeys(address2);

            var selectElement = new SelectElement(Country);
            selectElement.SelectByValue(country);

            State.SendKeys(state);
            City.SendKeys(city);
            Zipcode.SendKeys(zipcode);
            MobileNumber.SendKeys(mobileNumber);

        }
       
    }
}
