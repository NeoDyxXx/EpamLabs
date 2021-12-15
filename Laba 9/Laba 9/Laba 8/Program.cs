using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Laba_8.Pages;
using Laba_8.Another_Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laba_8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ItemInHistoryList> testList = new List<ItemInHistoryList>()
            {
                new ItemInHistoryList() {NameOfStock = "AUD/CAD (OTC)", TimeOfTrade = "00:01:00"}
            };

            WebDriver webDriver = new ChromeDriver(@"C:\Users\krayn\Documents\БГТУ\5_semestr\EPAM\Laba 8\Laba 8\Laba 8\Web Driver\");
            LoginPage siteOfDemoAccount = new LoginPage(webDriver);

            MainPage mainPage = siteOfDemoAccount
                                    .TransitionToDemoAccount()
                                    .HidePopup()
                                    .ClickToChangeSet()
                                    .ClickToDemoFromChangeSet()
                                    .ClickToChooseStockButton()
                                    .ClickToButtonOfResetSearchToCripto()
                                    .ClickToChooseStockItem()
                                    .TypeCostFromTransaction(5)
                                    .TypeTimeFromTransaction(new DateTime(2021, 1, 1, 0, 1, 0))
                                    .ClickToPushTransaction();
            Thread.Sleep(70000);

            List<ItemInHistoryList> resultListFromTest = mainPage.GetItemInHistoryLists();
            Console.WriteLine(resultListFromTest.EqualListsOfItemInHistoryList(testList));

            webDriver.Close();
            webDriver.Quit();
        }
    }
}