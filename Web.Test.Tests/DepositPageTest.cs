using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Web.Test.Tests
{
    class DepositPageTest
    {
        IWebDriver webDriver;
        [SetUp]
        public void beforeeachtest()
        {
            webDriver = new ChromeDriver();
            webDriver.Url = "http://localhost:64177/Login";
            webDriver.FindElement(By.Id("login")).SendKeys("test");
            webDriver.FindElement(By.Id("password")).SendKeys("newyork1");
            webDriver.FindElements(By.Id("login"))[1].Click();
        }
        [TearDown]
        public void AfterEachTest()
        {
            webDriver.Quit();
        }

        //[Test]
        //public void Settings()
        //{
        //    webDriver.FindElement(By.XPath("/html/body/div/div/div")).Click();

        //    string url = webDriver.Url;
        //    Assert.AreEqual("http://localhost:64177/Settings", url);

        // }

        [Test]
        public void Positive_Deposit_360()
        {
            webDriver.FindElement(By.Id("amount")).SendKeys("10");
            webDriver.FindElement(By.Id("percent")).SendKeys("5");
            webDriver.FindElement(By.Id("term")).SendKeys("200");
            webDriver.FindElement(By.Id("d360")).Click();


            string Income = webDriver.FindElement(By.Id("income")).GetAttribute("value");
            Assert.AreEqual("10.28", Income);

            string Interest = webDriver.FindElement(By.Id("interest")).GetAttribute("value");
            Assert.AreEqual("0.28", Interest);
        }

        [Test]
        public void Positive_Deposit_365()
        {
            webDriver.FindElement(By.Id("amount")).SendKeys("10");
            webDriver.FindElement(By.Id("percent")).SendKeys("5");
            webDriver.FindElement(By.Id("term")).SendKeys("200");
            webDriver.FindElement(By.Id("d365")).Click();


            string Income = webDriver.FindElement(By.Id("income")).GetAttribute("value");
            Assert.AreEqual("10.27", Income);

            string Interest = webDriver.FindElement(By.Id("interest")).GetAttribute("value");
            Assert.AreEqual("0.27", Interest);
        }

        [Test]
        public void percent_check_101()
        {
            webDriver.FindElement(By.Id("percent")).SendKeys("101");


            string Percent = webDriver.FindElement(By.Id("percent")).GetAttribute("value");
            Assert.AreEqual("0", Percent);
        }
        [Test]
        public void percent_check_0()
        {
            webDriver.FindElement(By.Id("percent")).SendKeys("0");


            string Percent = webDriver.FindElement(By.Id("percent")).GetAttribute("value");
            Assert.AreEqual("0", Percent);
        }
        [Test]
        public void Russian_letters()
        {
            webDriver.FindElement(By.Id("amount")).SendKeys("лоравлыаловрла");
            webDriver.FindElement(By.Id("percent")).SendKeys("лорол");
            webDriver.FindElement(By.Id("term")).SendKeys("лорлрл");


            string Amount = webDriver.FindElement(By.Id("amount")).GetAttribute("value");
            Assert.AreEqual("0", Amount);

            string Percent = webDriver.FindElement(By.Id("percent")).GetAttribute("value");
            Assert.AreEqual("0", Percent);

            string Term = webDriver.FindElement(By.Id("term")).GetAttribute("value");
            Assert.AreEqual("0", Term);

            // 
        }

        [Test]
        public void Day()
        {
            using (IWebDriver chrome = new ChromeDriver())
            {
                webDriver.FindElement(By.Id("amount")).SendKeys("10");
                webDriver.FindElement(By.Id("percent")).SendKeys("5");
                webDriver.FindElement(By.Id("term")).SendKeys("200");
                webDriver.FindElement(By.Id("d365")).Click();


                string Income = webDriver.FindElement(By.Id("income")).GetAttribute("value");
                Assert.AreEqual("10.27", Income);

                string Interest = webDriver.FindElement(By.Id("interest")).GetAttribute("value");
                Assert.AreEqual("0.27", Interest);


                var day = chrome.FindElement(By.Id("day"));
                SelectElement select_day = new SelectElement(day);
                select_day.SelectByValue("21");

                string Term = webDriver.FindElement(By.Id("day")).GetAttribute("value");
                Assert.AreEqual("2", day);
            }
        }
    }
}

