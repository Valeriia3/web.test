using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Web.Test.Tests
{
    public class LoginPageTests
    {
        [Test]
        public void Positive()
        {
            IWebDriver webDriver = new ChromeDriver();

            webDriver.Url = "http://localhost:64177/Login";

            webDriver.FindElement(By.Id("login")).SendKeys("test");
            webDriver.FindElement(By.Id("password")).SendKeys("newyork1");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string url = webDriver.Url;
            Assert.AreEqual("http://localhost:64177/Deposit", url);

            webDriver.Quit();
        }

        [Test]
        public void Empty_login_and_password()
        {
            IWebDriver webDriver = new ChromeDriver();

            webDriver.Url = "http://localhost:64177/Login";

            webDriver.FindElement(By.Id("login")).Clear();
            webDriver.FindElement(By.Id("password")).Clear();
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("User name and password cannot be empty!", actualError);

            webDriver.Quit();
        }

        [Test]
        public void Empty_login()
        {
            IWebDriver webDriver = new ChromeDriver();

            webDriver.Url = "http://localhost:64177/Login";

            webDriver.FindElement(By.Id("login")).Clear();
            webDriver.FindElement(By.Id("password")).SendKeys("1234");
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("User name and password cannot be empty!", actualError);

            webDriver.Quit();
        }

        [Test]
        public void Empty_password_with_existed_login()
        {
            IWebDriver webDriver = new ChromeDriver();

            webDriver.Url = "http://localhost:64177/Login";

            webDriver.FindElement(By.Id("login")).SendKeys("test");
            webDriver.FindElement(By.Id("password")).Clear();
            webDriver.FindElements(By.Id("login"))[1].Click();

            string actualError = webDriver.FindElement(By.Id("errorMessage")).Text;
            Assert.AreEqual("User name and password cannot be empty!", actualError);

            webDriver.Quit();
        }
    }
}