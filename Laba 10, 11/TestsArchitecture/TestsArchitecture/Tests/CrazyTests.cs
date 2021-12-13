using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace TestsArchitecture.Tests
{
    [TestFixture]
    public class CrazyTests
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Init()
        {
            webDriver = Driver.DriverInstance.GetInstance();
        }

        [TearDown]
        public void Cleanup()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        [Test]
        public void TestOfTest()
        {
            Thread.Sleep(5000);
            Assert.IsTrue(true);
        }
    }
}
