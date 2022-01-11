using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Page
{
    class BasicCalculatorPage : BasePage
    {

        private IWebElement _firstInput => Driver.FindElement(By.Id("number1Field"));
        private IWebElement _secondInput => Driver.FindElement(By.Id("number2Field"));
        private IWebElement _integersOnly => Driver.FindElement(By.Id("integerSelect"));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("calculateButton"));
        private IWebElement _actualResult => Driver.FindElement(By.Id("numberAnswerField"));

        //konstruktorius
        public BasicCalculatorPage(IWebDriver webdriver) : base(webdriver){}

        //metodai
        public void EnterFirstInputField(string firstValue)
        {
            _firstInput.Clear();
            _firstInput.SendKeys(firstValue);
        }

        public void EnterSecondInputField(string secondValue)
        {
            _secondInput.Clear();
            _secondInput.SendKeys(secondValue);
        }

        public void EnterBothInputValues(string firstValue, string secondValue)
        {
            EnterFirstInputField(firstValue);
            EnterSecondInputField(secondValue);
        }

        public void CheckIfIntegersOnly(bool shouldBeChecked)
        {
            if (_integersOnly.Selected != shouldBeChecked) 
            {
                _integersOnly.Click();
            }
        }

        internal void EnterFirstInputField()
        {
            throw new NotImplementedException();
        }

        public void ClickCalculateButton()
        {
            _calculateButton.Click();
        }

        public void VerifyResults(string result)
        {
            Assert.AreEqual(result, _actualResult.GetAttribute("value"), "Calculation is incorrect");
        }
    }
}
