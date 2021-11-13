using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class QuotexTests
    {
        [TestMethod]
        public void LogInTest()
        {
            WebDriver webDriver = new ChromeDriver(@"C:\Users\krayn\Documents\¡√“”\5_semestr\EPAM\Laba 8\Laba 8\Laba 8\Web Driver\");
            Laba_8.QuotexTestOne testOne = new Laba_8.QuotexTestOne(webDriver);
            Assert.IsTrue(testOne.LogIn());
            webDriver.Close();
            webDriver.Quit();
        }

        [TestMethod]
        public void ChangeValueForStockTest()
        {
            WebDriver webDriver = new ChromeDriver(@"C:\Users\krayn\Documents\¡√“”\5_semestr\EPAM\Laba 8\Laba 8\Laba 8\Web Driver\");
            Laba_8.QuotexTestOne testOne = new Laba_8.QuotexTestOne(webDriver);
            testOne.LogIn();
            Assert.AreEqual<string>(testOne.ChangeValueForStock(), "00:02:00");
            webDriver.Close();
            webDriver.Quit();
        }

        [TestMethod]
        public void GetStockTest()
        {
            WebDriver webDriver = new ChromeDriver(@"C:\Users\krayn\Documents\¡√“”\5_semestr\EPAM\Laba 8\Laba 8\Laba 8\Web Driver\");
            Laba_8.QuotexTestOne testOne = new Laba_8.QuotexTestOne(webDriver);
            testOne.LogIn();
            testOne.ChangeValueForStock();
            Assert.IsTrue(testOne.GetStock());
            webDriver.Close();
            webDriver.Quit();
        }
    }
}
