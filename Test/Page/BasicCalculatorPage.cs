using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Page
{
    class BasicCalculatorPage
    {
        private static IWebDriver _driver;

        private IWebElement _firstInput => _driver.FindElement(By.Id("number1Field"));
        private IWebElement _secondInput => _driver.FindElement(By.Id("number2Field"));
        private IWebElement _integersOnly => _driver.FindElement(By.Id("integerSelect"));
        private IWebElement _calculateButton => _driver.FindElement(By.Id("calculateButton"));
        private IWebElement _actualResult => _driver.FindElement(By.Id("numberAnswerField"));

        //konstruktorius
        public BasicCalculatorPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

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
