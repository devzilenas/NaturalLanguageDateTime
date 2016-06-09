using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageDateTime.NLDT;
using System.Diagnostics;

namespace NaturalLanguageDateTime.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPast()
        {
            DateTime dt = NLDateTime.Evaluate("past").DateTime; 
            Trace.Write(String.Format("Past is {0} {n}".Replace("{n}", Environment.NewLine), dt));
            Assert.IsTrue(dt.Date < DateTime.Now);
        }

        [TestMethod]
        public void TestFuture()
        {
            DateTime dt = NLDateTime.Evaluate("future").DateTime; 
            Trace.Write(String.Format("Future is {0} {n}".Replace("{n}", Environment.NewLine), dt));
            Assert.IsTrue(dt.Date > DateTime.Now);
        }

        [TestMethod]
        public void TestSomeDayAfterTomorrow()
        {
            DateTime dt = NLDateTime.Evaluate("some day after tomorrow").DateTime;
            Trace.Write(String.Format("Some day after tomorrow is {0} {n}".Replace("{n}", Environment.NewLine), dt));
            Assert.IsTrue(dt.Date > DateTime.Now.Date.AddDays(1).AddDays(1).Date);
        }

        [TestMethod]
        public void TestSomedayAfterTomorrow()
        {
            DateTime dt = NLDateTime.Evaluate("some day after tomorrow").DateTime;
            Trace.Write(String.Format("Some day after tomorrow is {0} {n}".Replace("{n}", Environment.NewLine), dt));
            Assert.IsTrue(dt.Date > DateTime.Now.Date.AddDays(1).AddDays(1).Date);
        }

        [TestMethod]
        public void TestTheDayAfterTomorrow()
        {
            DateTime dt = NLDateTime.Evaluate("the day after tomorrow").DateTime;
            Trace.Write(String.Format("Answer: The day after tomorrow is {0} {n}".Replace("{n}", Environment.NewLine),dt.Date));
            Assert.AreEqual(DateTime.Now.Date.AddDays(1).AddDays(1).ToString(), dt.Date.ToString());
        }

        [TestMethod]
        public void TestPartsDayAfterTomorrow()
        {
            NLDateTime dt = NLDateTime.ParseString("1 day after tomorrow");
            CollectionAssert.AreEqual( new IPart[] { CardinalNumber.From("1"), Noun.From("day"), Preposition.From("after"), Pronoun.From("tomorrow") }, dt.Parts);
        }

        [TestMethod]
        public void TestYesterday() //=Yesterday
        {
            String yesterday = DateTime.Now.Date.AddDays(-1).ToString();
            DateTime dt = NLDateTime.Evaluate("yesterday").DateTime;
            Assert.AreEqual(yesterday, dt.Date.ToString());
        }

        [TestMethod]
        public void TestToday() //=Today
        {
            String today = DateTime.Now.Date.ToString();
            DateTime dt = NLDateTime.Evaluate("today").DateTime;
            Assert.AreEqual(today, dt.Date.ToString());
        }

        [TestMethod]
        public void TestTomorrow() //=Tomorrow
        {
            String tomorrow = DateTime.Now.AddDays(1).Date.ToString();
            DateTime dt = NLDateTime.Evaluate("tomorrow").DateTime;
            Assert.AreEqual(tomorrow, dt.Date.ToString());
        }

        [TestMethod]
        public void Test1DayAfterToday() //=Tomorrow
        {
            String day1AfterToday = DateTime.Now.AddDays(1).Date.ToString();
            DateTime dt = NLDateTime.Evaluate("1 day after today").DateTime;
            Assert.AreEqual(day1AfterToday, dt.Date.ToString());
        }

        [TestMethod]
        public void Test1WeekAfterTomorrow()
        {
            String weekAfterTomorrow = DateTime.Now.AddDays(1).AddDays(7).Date.ToString();
            DateTime dt = NLDateTime.Evaluate("1 week after tomorrow").DateTime;
            Assert.AreEqual(weekAfterTomorrow, dt.Date.ToString());
        }

        [TestMethod]
        public void Test1DayAfterTomorrow()
        {
            String day1AfterToday = DateTime.Now.AddDays(1).AddDays(1).Date.ToString();
            DateTime dt = NLDateTime.Evaluate("1 day after tomorrow").DateTime;
            Assert.AreEqual(day1AfterToday, dt.Date.ToString());
        }

        [TestMethod]
        public void Test1DayBeforeToday()
        {
            String day1BeforeToday = DateTime.Now.AddDays(-1).Date.ToString();
            DateTime dt = NLDateTime.Evaluate("1 day before today").DateTime;
            Assert.AreEqual(day1BeforeToday, dt.Date.ToString());
        }

    }
}
