using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            /*YandexLogIn yandexLogIn = new YandexLogIn(new ChromeDriver(
                    @"C:\Users\krayn\Documents\БГТУ\5_semestr\EPAM\Laba 8\Selenium\Selenium\Web Driver\"), 
                    "testaccountselenium.test@yandex.ru", 
                    "secret2002.31*"
                );
            yandexLogIn.LogIn();

            YandexSender yandexSender = new YandexSender(
                    yandexLogIn._webDriver, 
                    "selenium.ndx@gmail.com",
                    "Test message 2",
                    "test message. TID: 2345631343241212412532"
                );
            yandexSender.SendMessage();*/

            GoogleLogIn googleLogIn = new GoogleLogIn(new ChromeDriver(
                        @"C:\Users\krayn\Documents\БГТУ\5_semestr\EPAM\Laba 8\Selenium\Selenium\Web Driver\"),
                        "selenium.ndx@gmail.com",
                        "secret2002.31*"
                    );
            googleLogIn.LogIn();

            GoogleSender googleSender = new GoogleSender(googleLogIn._webDriver, "selenium.ndx@gmail.com",
                    "Test message 2",
                    "test message. TID: 2345631343241212412532");
            googleSender.SendMessage();
            
            googleLogIn._webDriver.Close();
            googleLogIn._webDriver.Quit();

            /*yandexSender._webDriver.Close();
            yandexSender._webDriver.Quit();*/
        }
    }
}
