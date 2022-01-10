using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomationTestingCourceWork_geoportal_lt.Page
{
    internal class GeoportalSearchPage : BasePage
    {
        //puslapio adresas
        private const string PageAddress = "https://www.geoportal.lt/geoportal/paieska";

        //elementai

        //konstruktorius su paveldėjimu
        public GeoportalSearchPage(IWebDriver webdriver) : base(webdriver) { }

        //metodai:
        //nunaviguoja į testui skirtą default page
        public GeoportalSearchPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }
    }
}
