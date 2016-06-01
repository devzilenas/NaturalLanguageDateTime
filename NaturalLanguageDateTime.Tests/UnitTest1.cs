using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageDateTime.NLDT;

namespace NaturalLanguageDateTime.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPartsDayAfterTomorrow()
        {
            NLDateTime dt = NLDateTime.ParseString("1 day after tomorrow");
            CollectionAssert.AreEqual(new IPart[] { CardinalNumber.From("1"), Noun.From("day"), Preposition.From("after"), Pronoun.From("tomorrow") }, dt.Parts);
        }

        [TestMethod]
        public void TestToday() //=Tomorrow
        {
            String today = DateTime.Now.Date.ToString();
            DTime dt = NLDateTime.Evaluate("today").AsDTime();
            Assert.AreEqual(today, dt.DateTime.Date.ToString());
        }

        [TestMethod]
        public void TestTomorrow() //=Tomorrow
        {
            String tomorrow = DateTime.Now.AddDays(1).Date.ToString();
            DTime dt = NLDateTime.Evaluate("tomorrow").AsDTime();
            Assert.AreEqual(tomorrow, dt.DateTime.Date.ToString());
        }

        [TestMethod]
        public void Test1DayAfterToday() //=Tomorrow
        {
            String day1AfterToday = DateTime.Now.AddDays(1).Date.ToString();
            DTime dt = NLDateTime.Evaluate("1 day afted today").AsDTime();
            Assert.AreEqual(day1AfterToday, dt.DateTime.Date.ToString());
        }

        [TestMethod]
        public void Test1WeekAfterTomorrow()
        {
            String weekAfterTomorrow = DateTime.Now.AddDays(1).AddDays(7).Date.ToString();
            DTime dt = NLDateTime.Evaluate("1 week after tomorrow").AsDTime();
            Assert.AreEqual(weekAfterTomorrow, dt.DateTime.Date.ToString());
        }

        [TestMethod]
        public void Test1DayAfterTomorrow()
        {
            String day1AfterToday = DateTime.Now.AddDays(1).AddDays(1).Date.ToString();
            DTime dt = NLDateTime.Evaluate("1 day after tomorrow").AsDTime();
            Assert.AreEqual(day1AfterToday, dt.DateTime.Date.ToString());
        }

        [TestMethod]
        public void Test1DayBeforeToday()
        {
            String day1BeforeToday = DateTime.Now.AddDays(-1).Date.ToString();
            DTime dt = NLDateTime.Evaluate("1 day before today").AsDTime();
            Assert.AreEqual(day1BeforeToday, dt.DateTime.Date.ToString());
        }

        [TestMethod]
        public void TestYesterday()
        {
            String yesterday = DateTime.Now.AddDays(-1).Date.ToString();
            NLDateTime nldt = NLDateTime.ParseString("yesterday");
            Assert.AreEqual(yesterday, nldt.Date.ToString());
        }
    }
}
