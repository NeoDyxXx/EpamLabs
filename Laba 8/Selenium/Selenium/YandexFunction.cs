using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Project
{
    class YandexLogIn
    {
        public WebDriver _webDriver { get; private set; }
        public string _email { get; private set; }
        public string _password { get; private set; }

        public YandexLogIn(WebDriver webDriver, string email, string password)
        {
            this._webDriver = webDriver;
            this._email = email;
            this._password = password;

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public bool LogIn()
        {
            try
            {
                _webDriver.Navigate().GoToUrl(@"https://mail.yandex.by");

                // Find link and click on
                _webDriver.FindElement(By.XPath("//div[@class='HeadBanner-ButtonsWrapper']/a[2]")).Click();

                // Find input_email and input data from
                IWebElement input_email = _webDriver.FindElement(By.XPath("//input[@class='Textinput-Control']"));
                input_email.Clear();
                input_email.SendKeys(this._email);

                // Click on button
                _webDriver.FindElement(By.XPath("//div[@class='passp-button passp-sign-in-button']/button[1]")).Click();

                // Find input_password and input data from
                IWebElement input_password = _webDriver.FindElement(By.XPath("//input[@data-t='field:input-passwd']"));
                input_password.Clear();
                input_password.SendKeys(this._password);

                // Click on button
                _webDriver.FindElement(By.XPath("//div[@class='passp-button passp-sign-in-button']/button[1]")).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {}", ex.Message);
                return false;
            }

            return true;
        }
    }

    class YandexSender
    {
        public WebDriver _webDriver { get; private set; }
        public string _emailToSend { get; private set; }
        public string _theme { get; private set; }
        public string _text { get; private set; }

        public YandexSender(WebDriver webDriver, string emailToSend, string theme, string text)
        {
            this._webDriver = webDriver;
            this._emailToSend = emailToSend;
            this._theme = theme;
            this._text = text;

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public bool SendMessage()
        {
            try
            {
                _webDriver.FindElement(By.XPath("//a[@class='mail-ComposeButton js-main-action-compose']")).Click();

                IWebElement input_address_email = _webDriver.FindElement(By.XPath("//div[@class='composeYabbles']"));
                input_address_email.Clear();
                input_address_email.SendKeys(_emailToSend + Keys.Enter);

                IWebElement input_threme = _webDriver.FindElement(By.XPath("//input[@class='composeTextField ComposeSubject-TextField']"));
                input_threme.Clear();
                input_threme.SendKeys(_theme);

                IWebElement input_text = _webDriver.FindElement(By.XPath("//div[@role='textbox']"));
                input_text.Clear();
                input_text.SendKeys(_text);

                _webDriver.FindElement(
                    By.XPath("//div[@class='new__root--3qgLa ComposeControlPanel-Button " +
                    "ComposeControlPanel-Button_new ComposeControlPanel-SendButton ComposeSendButton " +
                    "ComposeSendButton_desktop']/button[1]")).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }

    class GoogleLogIn
    {
        public WebDriver _webDriver { get; private set; }
        public string _email { get; private set; }
        public string _password { get; private set; }

        public GoogleLogIn(WebDriver webDriver, string email, string password)
        {
            this._webDriver = webDriver;
            this._email = email;
            this._password = password;

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public bool LogIn()
        {
            try
            {
                _webDriver.Navigate().GoToUrl(@"https://www.google.com/intl/ru/gmail/about/");

                _webDriver.FindElement(By.XPath("//a[@data-action='sign in']")).Click();

                IWebElement input_email = _webDriver.FindElement(By.XPath("//input[@type='email']"));
                input_email.Clear();
                input_email.SendKeys(this._email + Keys.Enter);

                // _webDriver.FindElement(By.XPath("//div[@class='VfPpkd-Jh9lGc']")).Click();

                Thread.Sleep(2000);

                IWebElement input_password = _webDriver.FindElement(By.XPath("//input[@type='password']"));
                input_password.Clear();
                input_password.SendKeys(this._password + Keys.Enter);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                return false;
            }

            try
            {
                if (_webDriver.FindElement(By.XPath("//div[@jsname='B34EJ']/span")).Text
                    == "Неверный пароль. Повторите попытку или нажмите на ссылку \"Забыли пароль?\", чтобы сбросить его.")
                    return false;
            }
            catch { }

            return true;
        }
    }

    class GoogleSender
    {
        public WebDriver _webDriver { get; private set; }
        public string _emailToSend { get; private set; }
        public string _theme { get; private set; }
        public string _text { get; private set; }

        public GoogleSender(WebDriver webDriver, string emailToSend, string theme, string text)
        {
            this._webDriver = webDriver;
            this._emailToSend = emailToSend;
            this._theme = theme;
            this._text = text;

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public bool SendMessage()
        {
            try
            {
                _webDriver.FindElement(By.XPath("//div[@jscontroller='eIu7Db']")).Click();

                IWebElement input_address_email = _webDriver.FindElement(By.XPath("//textarea[@class='vO']"));
                input_address_email.Clear();
                input_address_email.SendKeys(_emailToSend + Keys.Enter);

                IWebElement input_threme = _webDriver.FindElement(By.XPath("//input[@name='subjectbox']"));
                input_threme.Clear();
                input_threme.SendKeys(_theme);

                IWebElement input_text = _webDriver.FindElement(By.XPath("//div[@role='textbox']"));
                input_text.Clear();
                input_text.SendKeys(_text);

                _webDriver.FindElement(By.XPath("//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']")).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            Thread.Sleep(2000);

            try
            {
                if (_webDriver.FindElement(By.XPath("//span[@class='bAq']")).Text != "Письмо отправлено.")
                    return false;
            }
            catch { return false; }

            return true;
        }
    }
}
