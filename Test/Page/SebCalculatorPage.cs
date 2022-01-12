using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Page
{
    class SebCalculatorPage : BasePage
    {
        private const string PageAdress = "https://www.seb.lt/privatiems/kreditai/busto-kreditas#1";

        //elementai
        private IWebElement _incomeInput => Driver.FindElement(By.Id("income"));
        private SelectElement _cityDropdown => new SelectElement(Driver.FindElement(By.Id("city")));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("calculate"));
        private IWebElement _resultTextElement => Driver.FindElement(By.CssSelector("#mortgageCalculatorStep2 > div.row > div > div:nth-child(5) > div > span > strong"));


        //konstruktorius
        public SebCalculatorPage(IWebDriver webdriver) : base(webdriver) { }

        public SebCalculatorPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAdress)
            {
                Driver.Url = PageAdress;
            }

            return this;
        }

        public SebCalculatorPage SwitchToFrame()
        {
            Driver.SwitchTo().Frame(0);

            return this;
        }

        public SebCalculatorPage InsertIncome(string income)
        {
            _incomeInput.Clear();
            _incomeInput.SendKeys(income);


            return this;
        }

        public SebCalculatorPage SelectFromCityDropdownByValue(string value)
        {
            _cityDropdown.SelectByValue(value);

            return this;
        }

        public SebCalculatorPage ClickCalculateButton()
        {
            _calculateButton.Click();

            return this;
        }

        public SebCalculatorPage CheckIfICanGetLoan(int wantedLoan)
        {
            string posibleLoanValue = _resultTextElement.Text.Trim().Replace(" ", "");
            Assert.IsTrue(wantedLoan < Int32.Parse(posibleLoanValue), "No, no loan for me :("); //galima ir su Convert.ToInt32

            return this;
        }
    }
}
