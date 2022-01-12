using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Drivers;
using Test.Page;
using Test.Tools;

namespace Test.Tests
{
    class TestBase
    {
        protected static IWebDriver Driver;

        public static DemoqaPageTextBox demoqaPageTextBox;
        public static BasicCalculatorPage basicCalculatorPage;
        public static SebCalculatorPage sebCalculatorPage;

        [OneTimeSetUp]
        public static void Setup()
        {
            Driver = CustomDriver.GetChromeDriver();

            demoqaPageTextBox = new DemoqaPageTextBox(Driver);
            basicCalculatorPage = new BasicCalculatorPage(Driver);
            sebCalculatorPage = new SebCalculatorPage(Driver);
        }


        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            Driver.Quit();
        }

        [TearDown]
        public static void TearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                //metodo kur padaro screenshota
                MyScreenshot.TakeScreenshot(Driver);
            }
        }
    }
}
