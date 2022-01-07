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
    class _2paskaita_task
    {
        private static IWebDriver _driver; //atskyrimui, kad tai global - dedamas "_"

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

        //25 + 25.5 = 50.5
        //5 + 25,5 + Integers only = 30
        //1.99 + 0.959 = 2.949
        //-1 + -9.99 + Integers only = -10
        [TestCase("25", "25.5", false, "50.5", TestName = "25 + 25,5 = 50,5")] // TestName pavadinime negali buti tasko
        [TestCase("5", "25.5", true, "30", TestName = "5 + 25,5 + Integers only = 30")]
        [TestCase("1.99", "0.959", false, "2.949", TestName = "1,99 + 0,959 = 2,949")]
        [TestCase("-1", "-9.99", true, "-10", TestName = "-1 + -9,99 + Integers only = -10")]
        public static void TestCase1(string firstNumber, string secondNumber, bool shouldBeCheked, string expectedResult)
        {
            IWebElement firstInput = _driver.FindElement(By.Id("number1Field"));
            IWebElement secondInput = _driver.FindElement(By.Id("number2Field"));
            
            firstInput.Clear();
            firstInput.SendKeys(firstNumber);
            secondInput.Clear();
            secondInput.SendKeys(secondNumber);

            IWebElement integersOnly = _driver.FindElement(By.Id("integerSelect"));

            if (integersOnly.Selected != shouldBeCheked) // galima irašyti ir (shouldBeChecked = true). Taip pat pradzioje apsirasom, kad jei nera paselectintas, tik tada atlik IF
            {
                integersOnly.Click();
            }

            IWebElement calculateButton = _driver.FindElement(By.Id("calculateButton"));
            calculateButton.Click();

            IWebElement result = _driver.FindElement(By.Id("numberAnswerField"));
            Assert.AreEqual(expectedResult, result.GetAttribute("value"), "Error");
        }
    }
}
