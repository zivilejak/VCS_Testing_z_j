using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomationTestingCourceWork_geoportal_lt.Page
{
    internal class GeoportalMapPage : BasePage
    {
        //puslapio adresas
        private const string PageAddress = "https://www.geoportal.lt/map/";

        //elementai
        public IWebElement _publicServicesTab => Driver.FindElement(By.Id("ui-id-5"));

        //konstruktorius su paveldėjimu
        public GeoportalMapPage(IWebDriver webdriver) : base(webdriver) { }

        //metodai:
        //nunaviguoja į testui skirtą default page
        public GeoportalMapPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
            {
                Driver.Url = PageAddress;
            }

            return this;
        }
    }
}
