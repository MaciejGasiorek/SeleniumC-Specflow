using AutoFixture;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SeleniumCsharpSpecflow.Models;
using SeleniumCsharpSpecflow.Pages;
using SeleniumCsharpSpecflow.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace SeleniumCsharpSpecflow.StepDefinitions
{
    [Binding]
    public class RegisterUserStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IHomePage _homePage;
        private readonly ILoginPage _loginPage;
        private readonly ISignUpPage _signUpPage;
        private readonly IGeneralPage _generalPage;
        private readonly IJsonHelper _JsonHelper;


        public RegisterUserStepDefinitions(ScenarioContext scenarioContext, IHomePage homepage, IGeneralPage generalpage, ILoginPage loginpage, ISignUpPage signUpPage, IJsonHelper jsonHelper)
        {
            _scenarioContext = scenarioContext;
            _homePage = homepage;
            _loginPage = loginpage;
            _signUpPage = signUpPage;
            _generalPage = generalpage;
            _JsonHelper = jsonHelper;
        }



        [Given(@"I m on the home Page, Verify that home page is visible successfully with link '([^']*)'")]
        public void GivenIMOnTheHomePageVerifyThatHomePageIsVisibleSuccessfullyWithLink(string link)
        {
            //_homePage.ClickModal();

            Assert.AreEqual(_homePage.RerurnUrl(), link);
            Console.WriteLine("test");
        }

        [When(@"Click on '([^']*)' button")]
        public void WhenClickOnButton(string text)
        {
            _generalPage.ClickButtonByText(text);
        }

        [Then(@"Verify '([^']*)' is visible")]
        public void ThenVerifyIsVisible(string text)
        {
            Assert.IsTrue(_loginPage.VerifyIfTextIsVisible(text));
        }

        [When(@"Enter name and email  address")]
        public void WhenEnterNameAndEmailAddress(Table table)
        {
            dynamic UserSignUpData = table.CreateDynamicInstance();
            _loginPage.EnterUserNameAndEmail(UserSignUpData.name, UserSignUpData.email);
        }

        [When(@"Click '([^']*)' button")]
        public void WhenClickButton(string signup)
        {
            _generalPage.ClickButtonByText(signup);
        }

        [Then(@"Fill details: Title, Name, Email, Password, Date of birth")]
        public void ThenFillDetailsTitleNameEmailPasswordDateOfBirth(Table table)
        {
            dynamic UserData = table.CreateDynamicInstance();

            _signUpPage.FillSignUpdetails(UserData.title,UserData.name,UserData.email,UserData.password,UserData.dateOfBirth);
        }

        [Then(@"Select checkbox '([^']*)'")]
        public void ThenSelectCheckbox(string checkbox)
        {
            _signUpPage.ClickCheckBox(checkbox);
        }

        [Then(@"Fill details: First name, Last name, Company, Address, Address(.*), Country, State, City, Zipcode, Mobile Number")]
        public void ThenFillDetailsFirstNameLastNameCompanyAddressAddressCountryStateCityZipcodeMobileNumber(int p0)
        {
            var user = new Fixture().Build<User>().With(x=> x.Country, "United States").Create();

            _signUpPage.FillDetails(user.FirstName, user.LastName, user.Company, user.Address, user.Address2, user.Country, user.State, user.City, user.Zipcode, user.MobileNumber);
        }

        [Then(@"Fill details")]
        public void ThenFillDetails()
        {

            User user = _JsonHelper.GetUser("user");
            
             _signUpPage.FillDetails(user.FirstName, user.LastName, user.Company, user.Address, user.Address2, user.Country, user.State, user.City, user.Zipcode, user.MobileNumber);


        }














    }
}
