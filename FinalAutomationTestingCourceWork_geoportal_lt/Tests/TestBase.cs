using FinalAutomationTestingCourceWork_geoportal_lt.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomationTestingCourceWork_geoportal_lt.Tests
{
    internal class TestBase
    {
        protected IWebDriver Driver;

        //public - kad testai galetu naudoti
        public static GeoportalLoginPage geoportalLoginPage;

        [OneTimeSetUp] //visus testus pakels ant vieno browserio - ivykdys visus testus
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();

            //inicializuoti objekta
            geoportalLoginPage = new GeoportalLoginPage(Driver);
        }

        [OneTimeTearDown] //kas uzcloseintu browseri po visu testu
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
