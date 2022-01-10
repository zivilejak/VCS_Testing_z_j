using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomationTestingCourceWork_geoportal_lt.Page
{
    internal class GeoportalLoginPage : BasePage
    {
        //puslapio adresas
        private const string PageAddress = "https://www.geoportal.lt/idp/Authn/UserPassword";

        //elementai

        //konstruktorius su paveldėjimu
        public GeoportalLoginPage(IWebDriver webdriver) : base(webdriver) {}

        //metodai:
        //nunaviguoja į testui skirtą default page
        public GeoportalLoginPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }
    }
}
