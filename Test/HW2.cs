using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class HW2
    {
        private static IWebDriver _driver; //atskyrimui, kad tai global - dedamas "_"

        [TearDown] //OneTime netinka, nes cia reikia kelis kartus skirtingom narsyklem
        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase("Chrome", "Chrome", TestName = "Chrome browser")]
        [TestCase("Firefox", "Firefox", TestName = "Firefox browser")]
        public static void TestChromeDriver(string browserType, string expectedResult)
        {
            switch (browserType)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver();
                    break;
            }

            _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";

            IWebElement whatBrowser = _driver.FindElement(By.Id("primary-detection"));
            if (whatBrowser.Text.Contains(expectedResult)){}
        }

        [Test]
        public static void Optional()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.active.com/fitness/calculators/pace";

            IWebElement distance = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > label > input[type=number]"));
            IWebElement distanceType = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > ul > li.selectboxit-option.selectboxit-option-first > a"));
            IWebElement paceType = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > ul > li.selectboxit-option.selectboxit-option-first > a > span"));
            IWebElement paceMinutes = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > label:nth-child(2) > input[type=number]"));
            IWebElement timeHours = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(1) > input[type=number]"));
            IWebElement timeMinutes = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(2) > input[type=number]"));
            IWebElement calculateButton = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(6) > div > a"));
            IWebElement distanceSelector = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span > span.selectboxit-arrow-container"));
            IWebElement paceSelector = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span > span.selectboxit-arrow-container"));

            //cookies popup neimanoma uzdaryti, neranda elemento

            distance.SendKeys("13");
            timeHours.SendKeys("1");
            timeMinutes.SendKeys("5");
            distanceSelector.Click();
            distanceType.Click();
            paceSelector.Click();
            paceType.Click();
            calculateButton.Click();
            Assert.AreEqual("05", paceMinutes.GetAttribute("value"), "Something went wrong");
        }

    }
}
