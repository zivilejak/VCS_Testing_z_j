using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tools
{
    class MyScreenshot
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = driver.TakeScreenshot();

            string screenshotDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //direktorija kur deti
            string screenshotFolder = Path.Combine(screenshotDirectory, "screenshot");
            Directory.CreateDirectory(screenshotFolder);

            //pavadinimo suformavimas
            string screenshotName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:HH_mm_ss}.png";
            string screenshotPath = Path.Combine(screenshotFolder, screenshotName);

            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        }

    }
}
