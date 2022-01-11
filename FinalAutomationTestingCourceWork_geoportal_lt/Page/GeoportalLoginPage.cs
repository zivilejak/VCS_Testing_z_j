using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomationTestingCourceWork_geoportal_lt.Page
{
    internal class GeoportalLoginPage : BasePage
    {
        //puslapio adresas
        private const string PageAddress = "https://www.geoportal.lt/geoportal/";

        //elementai
        private IWebElement _loginButton => Driver.FindElement(By.Id("login_link"));
        private IWebElement _loginNameInputField => Driver.FindElement(By.Name("j_username"));
        private IWebElement _passwordInputField => Driver.FindElement(By.Name("j_password"));
        private IWebElement _loginVerifyButton => Driver.FindElement(By.CssSelector("#login > section:nth-child(4) > button"));
        private IWebElement _logoutButton => Driver.FindElement(By.Id("logout_link"));
        private IWebElement _loginErrorMessage => Driver.FindElement(By.CssSelector("#login > section:nth-child(1) > p"));

        //konstruktorius su paveldėjimu
        public GeoportalLoginPage(IWebDriver webdriver) : base(webdriver) {}

        //metodai:
        //nunaviguoja į testui skirtą default page
        public GeoportalLoginPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }

        public GeoportalLoginPage CheckIfUserIsLoggedIn()
        {
            var element = Driver.FindElements(By.Id("logout_link"));
            
            if (element.Count > 0)
            {
                _logoutButton.Click();
            }
            
            return this;
        }

        public GeoportalLoginPage CLickLoginButton()
        {
            _loginButton.Click();
            
            return this;
        }

        public GeoportalLoginPage EnterLoginName(string loginName)
        {
            _loginNameInputField.Clear();
            _loginNameInputField.SendKeys(loginName);

            return this;
        }

        public GeoportalLoginPage EnterPassword(string password)
        {
            _passwordInputField.Clear();
            _passwordInputField.SendKeys(password);

            return this;
        }

        public GeoportalLoginPage ClickLoginVerifyButton()
        {
            _loginVerifyButton.Click();

            return this;
        }

        public GeoportalLoginPage VerifyUserLogin(string expectedValue)
        {
            Assert.AreEqual($"atsijungti ({expectedValue})", _logoutButton.Text, "User name does not match the login name");

            return this;
        }

        public GeoportalLoginPage VerifyIncorrectCredentialsLoginErrorMessage(string expectedValue)
        {
            Assert.AreEqual(expectedValue, _loginErrorMessage.Text, "Login error message did not appear");

            return this;
        }
    }
}
