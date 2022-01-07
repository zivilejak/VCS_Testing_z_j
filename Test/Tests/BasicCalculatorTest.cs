using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Page;

namespace Test.Tests
{
    class BasicCalculatorTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp] //visus testus pakels ant vieno browserio - ivykdys visus testus
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://testsheepnz.github.io/BasicCalculator.html#main-body";
        }

        [OneTimeTearDown] //kas uzcloseintu browseri po visu testu
        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase("25", "25.5", false, "50.5", TestName = "25 + 25,5 = 50,5")] // TestName pavadinime negali buti tasko
        [TestCase("5", "25.5", true, "30", TestName = "5 + 25,5 + Integers only = 30")]
        [TestCase("1.99", "0.959", false, "2.949", TestName = "1,99 + 0,959 = 2,949")]
        [TestCase("-1", "-9.99", true, "-10", TestName = "-1 + -9,99 + Integers only = -10")]
        public static void TestCase1(string firstNumber, string secondNumber, bool shouldBeCheked, string expectedResult)
        {
            BasicCalculatorPage basicCalculatorPage = new BasicCalculatorPage(_driver);

            basicCalculatorPage.EnterFirstInputField(firstNumber);
            basicCalculatorPage.EnterSecondInputField(secondNumber);
            basicCalculatorPage.CheckIfIntegersOnly(shouldBeCheked);
            basicCalculatorPage.ClickCalculateButton();
            basicCalculatorPage.VerifyResults(expectedResult);
        }
    }
}
