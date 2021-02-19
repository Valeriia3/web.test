using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        public void Positive_Deposit()
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
    }
}
