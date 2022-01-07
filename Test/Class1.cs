using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    public class Class1
    {
        //4 yra lyginis skaičius
        //Dabar 18 val.

        //testas "zalias" jei 995 dalijasi is 3 (be liekanos)
        //testas "zalias" jei siandien pirmadienis (DayOfWeek.Monday)
        //testas "zalias" po to kai "palaukia" 5 sekundes

        [Test]
        public static void TestIf4IsEven()
        {
            int leftOver =  4 % 2;
            Assert.AreEqual(0, leftOver, "4 is not even");
        }

        [Test]
        public static void TestNowIs17()
        {
            DateTime currentTime = DateTime.Now; //Paspaudus 2 kart ant obj - galima paziureti
                                                 //sisteminio obj aprasyma
                                                 //DateTime - tipas
                                                 //.Now - current date and time on this computer
            Assert.AreEqual(18, currentTime.Hour, "Dabar ne 18 valanda"); //Norint patikrinti ar testas veikia - Pakeiciam valanda - pirmas skaicius skliausteliu viduje

        }
        //testas "zalias" jei 995 dalijasi is 3 (be liekanos)
        //testas "zalias" jei siandien pirmadienis (DayOfWeek.Monday)
        //testas "zalias" po to kai "palaukia" 5 sekundes

        [Test]
        public static void Test995DevidesBy3()
        {
            int leftOver = 993 % 3;
            Assert.AreEqual(0, leftOver, "993 does not devide by 3 without leftover");
        }

        [Test]
        public static void TestTodayIsMonday()
        {
            DateTime currentDayOfWeek = DateTime.Now;
            Assert.AreEqual(DayOfWeek.Monday, currentDayOfWeek.DayOfWeek, "Today is not Monday");
        }

        [Test]
        public static void Wait5Seconds()
        {
            Thread.Sleep(2000); // nelabai tinkamas testams, bet da=nai naudojama. 
        }
    }
}
