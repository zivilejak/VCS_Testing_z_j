using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Checkbox
    {
        private static IWebDriver _driver; //atskyrimui, kad tai global - dedamas "_"

        [OneTimeSetUp] //visus testus pakels ant vieno browserio - ivykdys visus testus
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://demoqa.com/checkbox";

            //uzdaro reklama
            IWebElement popup = _driver.FindElement(By.Id("close-fixedban"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(x => popup.Displayed);
            popup.Click();

            //Isskleidzia visa medi. Jei sito nepadarom - narsykleje matysis tik vienas elementas
            IWebElement expandAllButton = _driver.FindElement(By.CssSelector("#tree-node > div > button.rct-option.rct-option-expand-all"));
            expandAllButton.Click();
        }

        [OneTimeTearDown] //kas uzcloseintu browseri po visu testu
        public void TearDown()
        {
            _driver.Close();
        }

        [Test]
        public static void CheckAllBoxes()
        {
            IReadOnlyCollection<IWebElement> checkBoxes = _driver.FindElements(By.ClassName("rct-checkbox"));

            foreach (IWebElement checkBox in checkBoxes)
            {
                checkBox.Click();
            }
        }
    }
}
