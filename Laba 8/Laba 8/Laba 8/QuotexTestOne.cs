using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Laba_8
{
    public class QuotexTestOne
    {
        WebDriver webDriver;
        string pageUrl;

        public QuotexTestOne(WebDriver webDriver)
        {
            if (webDriver == null)
                this.webDriver = new ChromeDriver(@"C:\Users\krayn\Documents\БГТУ\5_semestr\EPAM\Laba 8\Laba 8\Laba 8\Web Driver\");
            else
                this.webDriver = webDriver;
        }

        public bool LogIn()
        {
            try
            {
                webDriver.Navigate().GoToUrl("https://qxbroker.com/");

                new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(By.XPath("//a[@class='main__platform-container__footer-demo']"))).Click();

                new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(By.XPath("//a[@class='button button--light button--small modal-byte__demo-button']"))).Click();

                Thread.Sleep(1000);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public string ChangeValueForStock()
        {
            try
            {
                new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(By.XPath("//input[@class='input-control__input opacity']"))).Click();

                new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(By.XPath("//div[@class='input-control__dropdown']/div[2]"))).Click();

                IWebElement cost = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(By.XPath("//input[@class='input-control__input']")));
                Console.WriteLine(cost.GetAttribute("value"));
                cost.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace);
                cost.SendKeys("5");

                return new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(By.XPath("//input[@class='input-control__input opacity']"))).GetAttribute("value");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "None";
            }
        }

        public bool GetStock()
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(3))
                    .Until(webDriver => webDriver.FindElement(By.XPath("//button[@class='button button--success button--spaced call-btn section-deal__button']")))
                    .Click();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
