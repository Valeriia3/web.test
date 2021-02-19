using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Web.Test.Tests
{
    public class LoginPageTests
    {
        IWebDriver webDriver;
        [SetUp]
        public void beforeeachtest() {
             webDriver = new ChromeDriver();

            webDriver.Url = "http://localhost:64177/Login";
        }
        [TearDown]
        public void AfterEachTest()
        {
            webDriver.Quit();
        }
        [Test]
        public void Positive()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("test");
            webDriver.FindElement(By.Id("password")).SendKeys("newyork1");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string url = webDriver.Url;
            Assert.AreEqual("http://localhost:64177/Deposit", url);
        }

        [Test]
        public void Empty_login_and_password()
        {
            webDriver.FindElement(By.Id("login")).Clear();
            webDriver.FindElement(By.Id("password")).Clear();
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("User name and password cannot be empty!", actualError);
        }

        [Test]
        public void Empty_login()
        {
            webDriver.FindElement(By.Id("login")).Clear();
            webDriver.FindElement(By.Id("password")).SendKeys("1234");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("User name and password cannot be empty!", actualError);
        }

        [Test]
        public void Login_with_spaces()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("        ");
            webDriver.FindElement(By.Id("password")).SendKeys("newyork1");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("User name and password cannot be empty!", actualError);
        }
        

            [Test]
        public void Password_different_font()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("test");
            webDriver.FindElement(By.Id("password")).SendKeys("nEWyork1");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("User name and password cannot be empty!", actualError);
        }
        [Test]
        public void Empty_password_with_existed_login()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("test");
            webDriver.FindElement(By.Id("password")).Clear();
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("User name and password cannot be empty!", actualError);
        }

        [Test]
        public void Wrong_login_and_password()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("123");
            webDriver.FindElement(By.Id("password")).SendKeys("123");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("'123' user doesn't exist!", actualError);
        }


        [Test]
        public void Login_as_password()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("newyork1");
            webDriver.FindElement(By.Id("password")).SendKeys("test");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("'newyork1' user doesn't exist!", actualError);
        }

        [Test]
        public void Wrong_login_special_symbols()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("5098290859-2$#@##$@$#@$%^&^*");
            webDriver.FindElement(By.Id("password")).SendKeys("newyork1");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("'5098290859-2$#@##$@$#@$%^&^*' user doesn't exist!", actualError);
        }

        [Test]
        public void Correct_login_and_incorrect_password()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("test");
            webDriver.FindElement(By.Id("password")).SendKeys("123");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("Incorrect password!", actualError);
        }

        [Test]
        public void Incorrect_login_and_correct_password()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("Test");
            webDriver.FindElement(By.Id("password")).SendKeys("newyork1");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("Incorrect user name!", actualError);
        }

        [Test]
        public void Login_spaces_and_correct_password()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("     test");
            webDriver.FindElement(By.Id("password")).SendKeys("newyork1");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("Incorrect user name!", actualError);
        }


        [Test]
        public void Negative_Big_letters()
        {
            webDriver.FindElement(By.Id("login")).SendKeys("TEST");
            webDriver.FindElement(By.Id("password")).SendKeys("NEWYORK1");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("'TEST' user doesn't exist!", actualError);
        }

       



        //[Test]
        //public void Positive_Deposit()
        //{
        //    IWebDriver webDriver = new ChromeDriver();

        //    webDriver.Url = "http://localhost:64177/Deposit";

        //    webDriver.FindElement(By.Id("amount")).SendKeys("10");
        //    webDriver.FindElement(By.Id("percent")).SendKeys("5");
        //    webDriver.FindElement(By.Id("term")).SendKeys("200");
        //    webDriver.FindElement(By.XPath("//div[@role='combox']")).SendKeys("10");
        //    webDriver.FindElement(By.Id("date")).SendKeys("25");
        //    webDriver.FindElement(By.Id("date")).SendKeys("10");
        //    webDriver.FindElement(By.Id("month")).SendKeys("October");
        //    webDriver.FindElement(By.Id("year")).SendKeys("2021");
        //    webDriver.FindElements(By.Id("365d"))[1].Click();

        //    string url = webDriver.Url;
        //    Assert.AreEqual("http://localhost:64177/Deposit", url);

        //    string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
        //    Assert.AreEqual("'123' user doesn't exist!", actualError);

        //    webDriver.Quit();
        //}
    }
}