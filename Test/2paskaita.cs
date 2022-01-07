using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class _2paskaita
    {
        private static IWebDriver _driver; //atskyrimui, kad tai global - dedamas "_"

        [OneTimeSetUp] //visus testus pakels ant vieno browserio - ivykdys visus testus
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://testpages.herokuapp.com/styled/calculator";
        }

        [OneTimeTearDown] //kas uzcloseintu browseri po visu testu
        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("a", "b", "ERR", TestName = "a + b = ERR")]
        public static void TestSum1(string firstInputValue, string secondInputValue, string expectedResult)
        {
            IWebElement inputNumber1 = _driver.FindElement(By.Id("number1"));
            inputNumber1.Clear(); //isvalo lauka
            inputNumber1.SendKeys(firstInputValue);

            IWebElement inputNumber2 = _driver.FindElement(By.Id("number2"));
            inputNumber2.Clear(); //isvalo lauka
            inputNumber2.SendKeys(secondInputValue);

            IWebElement calculateButton = _driver.FindElement(By.Id("calculate"));
            calculateButton.Click();

            IWebElement sumAnswer = _driver.FindElement(By.Id("answer"));
            Assert.AreEqual(expectedResult, sumAnswer.Text, "Somethinng went wrong");
        }
    }
}
