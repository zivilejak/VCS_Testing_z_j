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
    class DemoqaTexBoxTests
    {
        private static IWebDriver _driver;

        [OneTimeSetUp] //visus testus pakels ant vieno browserio - ivykdys visus testus
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://demoqa.com/text-box";
        }

        [OneTimeTearDown] //kas uzcloseintu browseri po visu testu
        public void TearDown()
        {
            _driver.Close();
        }

        [Test]
        public static void fullNameTextBoxTest()
        {
            DemoqaPageTextBox demoqaPageTextBox = new DemoqaPageTextBox(_driver);

            string text = "živilė";

            //iškviečiam metodus
            demoqaPageTextBox.InsertTextToFullNameField(text);
            demoqaPageTextBox.CLickSubmitButton();
            demoqaPageTextBox.VerifyFullNameResult(text);
        }
    }
}
