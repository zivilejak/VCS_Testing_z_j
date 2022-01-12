using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Tests
{
    class SebCalculatorTest : TestBase
    {
        [Test]
        public static void CalculateLoan()
        {
            sebCalculatorPage.NavigateToDefaultPage()
                .SwitchToFrame()
                .InsertIncome("1000")
                .SelectFromCityDropdownByValue("Klaipeda")
                .ClickCalculateButton()
                .CheckIfICanGetLoan(75000);
        }
    }
}
