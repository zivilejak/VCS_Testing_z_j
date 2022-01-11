using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Page
{
    class DemoqaPageTextBox : BasePage
    {

        private IWebElement _fullNameInputField => Driver.FindElement(By.Id("userName")); //po lygybes zenklo yra dedamas ">", kad elemento ieskotu tik tada, kada pareikalausim
        private IWebElement _submitButton => Driver.FindElement(By.Id("submit"));
        private IWebElement _fullNameActualResult => Driver.FindElement(By.Id("name"));

        //konstruktorius
        public DemoqaPageTextBox(IWebDriver webdriver) : base(webdriver){}

        //metodas lauko ivedimui
        public void InsertTextToFullNameField(string text)
        {
            _fullNameInputField.Clear();
            _fullNameInputField.SendKeys(text);
        }

        public void CLickSubmitButton()
        {
            _submitButton.Click();
        }

        public void VerifyFullNameResult(string expectedResult)
        {
            Assert.AreEqual($"Name:{expectedResult}", _fullNameActualResult.Text, "Name is wrong");
        }
    }
}
