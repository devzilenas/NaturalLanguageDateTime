using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageDateTime;

namespace NaturalLanguageDateTime.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestToday()
        {
            String today = DateTime.Now.Date.ToString();
            NLDateTime nldt = NLDateTime.ParseString("today");
            Assert.AreEqual(today, nldt.DateTime.Date.ToString());
        }
        [TestMethod]
        public void TestTomorrow()
        {
            String tomorrow = DateTime.Now.AddDays(+1).Date.ToString();
            NLDateTime nldt = NLDateTime.ParseString("tomorrow");
            Assert.AreEqual(tomorrow, nldt.Date.ToString());
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
