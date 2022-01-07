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
    class TestWebDriver
    {
        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://login.yahoo.com/";
            driver.Close();
        }

        [Test]
        public static void TestYahooPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://login.yahoo.com/";

            IWebElement emailInputField = driver.FindElement(By.Id("login-username"));
            emailInputField.SendKeys("Labas@Labas.lt");

            IWebElement submitButton = driver.FindElement(By.Id("login-signin"));
            submitButton.Click();

            driver.Close();
        }

        
        [Test]
        public static void TestInputPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/text-box";

            IWebElement InputField = driver.FindElement(By.Id("userName"));
            InputField.SendKeys("Živilė Jakubkaitė");

            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();

            IWebElement fullNameResult = driver.FindElement(By.Id("name"));
            //patikriname rezultatą:
            Assert.AreEqual("Name:Živilė Jakubkaitė", fullNameResult.Text, "Name is wrong");

            driver.Close();
        }


        //Homework "1 Namų Darbai"
        //Puslapyje https://testpages.herokuapp.com/styled/calculator "Skaičiuotuvo" formai.
        //Patikrinti, ar teisingai suskaičiuotos sumos, jei įvesti tokie duomenys:
        //2+2
        //-5+3
        //a + b

        [Test]
        public static void TestSum1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://testpages.herokuapp.com/styled/calculator";

            IWebElement inputNumber1 = driver.FindElement(By.Id("number1"));
            inputNumber1.SendKeys("2");

            IWebElement inputNumber2 = driver.FindElement(By.Id("number2"));
            inputNumber2.SendKeys("2");

            IWebElement calculateButton = driver.FindElement(By.Id("calculate"));
            calculateButton.Click();

            IWebElement sumAnswer = driver.FindElement(By.Id("answer"));
            Assert.AreEqual("4", sumAnswer.Text, "Somethinng went wrong");

            driver.Close();
        }

        [Test]
        public static void TestSum2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://testpages.herokuapp.com/styled/calculator";

            IWebElement inputNumber1 = driver.FindElement(By.Id("number1"));
            inputNumber1.SendKeys("-5");

            IWebElement inputNumber2 = driver.FindElement(By.Id("number2"));
            inputNumber2.SendKeys("3");

            IWebElement calculateButton = driver.FindElement(By.Id("calculate"));
            calculateButton.Click();

            IWebElement sumAnswer = driver.FindElement(By.Id("answer"));
            Assert.AreEqual("-2", sumAnswer.Text, "Somethinng went wrong");

            driver.Close();
        }

        [Test]
        public static void TestSum3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://testpages.herokuapp.com/styled/calculator";

            IWebElement inputNumber1 = driver.FindElement(By.Id("number1"));
            inputNumber1.Clear(); //isvalo lauka
            inputNumber1.SendKeys("a");

            IWebElement inputNumber2 = driver.FindElement(By.Id("number2"));
            inputNumber2.Clear(); //isvalo lauka
            inputNumber2.SendKeys("b");

            IWebElement calculateButton = driver.FindElement(By.Id("calculate"));
            calculateButton.Click();

            IWebElement sumAnswer = driver.FindElement(By.Id("answer"));
            Assert.AreEqual("ERR", sumAnswer.Text, "Somethinng went wrong");

            driver.Close();
        }


        ////lektoriaus 2  paskaita (2021-01-03):
        //[Test]
        //public static void TestSumBlock1()
        //{
        //    IWebDriver driver = new ChromeDriver();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    driver.Manage().Window.Maximize();
        //    driver.Url = "https://testpages.herokuapp.com/styled/calculator";

        //    IWebElement firstInput = driver.FindElement(By.Id("number1"));
        //    IWebElement secondInput = driver.FindElement(By.Id("number2"));

        //    firstInput.Clear();
        //    firstInput.SendKeys("2");
        //    secondInput.Clear();
        //    secondInput.SendKeys("2");

        //    IWebElement calculateButton = driver.FindElement(By.Id("calculate"));
        //    calculateButton.Click();

        //    IWebElement actualResult = driver.FindElement(By.Id("answer"));
        //    Assert.AreEqual("4", actualResult.Text, "Sum is Incorrect");

        //    driver.Close();
        //}

        ////lektroiaus: public kintamieji, skirti pakelti browserį ir kitas - jį uždaryti
        //// _driver apsirašyti pagal paskaitą 2021-01-03
        //[OneTimeSetUp]
        //public void SetUp()
        //{
        //    _driver = new ChromeDriver();
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    _driver.Manage().Window.Maximize();
        //    _driver.Url = "https://testpages.herokuapp.com/styled/calculator";
        //}

        //[OneTimeTearDown]
        //public void TearDown()
        //{
        //    _driver.Close();
        //}

        ////vienas testas
        //[TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        //public static void TestSumBlock(string firstInputvalue, string secondInputValue, string expectedResult)
        //{
        //    IWebElement firstInput = _driver.FindElement(By.Id("number1"));
        //    IWebElement secondInput = _driver.FindElement(By.Id("number2"));

        //    firstInput.Clear();
        //    firstInput.SendKeys(firstInputvalue);
        //    secondInput.Clear();
        //    secondInput.SendKeys(secondInputValue);

        //    IWebElement calculateButton = _driver.FindElement(By.Id("calculate"));
        //    calculateButton.Click();

        //    IWebElement actualResult = _driver.FindElement(By.Id("answer"));
        //    Assert.AreEqual(expectedResult, actualResult.Text, "Sum is Incorrect");
        //}

        //25 + 25.5 = 50.5
        //5 +  Integers only =  30
        //1.99 + 0.959 = 2.959
        //-1 + -9.99 + Integers only = -10

        //Baigiamojo darbo reikalavimai:

        //Minimum 5 prasmingi testai(kiekvienas testas minimum 3 žingsniai)
        //Minimum 3 skirtingi puslapiai(tas pats website)
        //Page Object Pattern
        //Screenshot on test failure
        //Paveldėjimas
        //SetUp / TearDown panaudojimas
        //Darbas įkeltas į GIT
        //Explicit Wait panaudojimas


    }
}
