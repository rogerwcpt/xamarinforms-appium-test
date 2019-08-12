using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace SimpleApp.Appium.Core
{
    public class TestMainPage<T, W>: AppiumTest<T, W>
        where T : AppiumDriver<W>
        where W : IWebElement
    {
        public TestMainPage(string testName): base(testName)
        {
        }

        protected override T GetDriver()
        {
            // Implemented by platform specific class
            throw new NotImplementedException();
        }

        protected override void InitAppiumOptions(AppiumOptions appiumOptions)
        {
            // Implemented by platform specific class
            throw new NotImplementedException();
        }

        [SetUp()]
        public void SetupTest()
        {
            //appiumDriver.CloseApp();
            //appiumDriver.LaunchApp();
        }

        [Test()]
        public void TestLogin()
        {
            appiumDriver.FindElement(By.Id("Login")).Click();
            appiumDriver.FindElement(By.Id("UserName")).SendKeys("user@email.com");
            appiumDriver.FindElement(By.Id("Password")).SendKeys("password");

            appiumDriver.FindElement(By.Id("LoginButton")).Click();
            var text = GetElementText("StatusLabel"); // Android is "text"

            Assert.IsNotNull(text);
            Assert.IsTrue(text.StartsWith("Logging in", StringComparison.CurrentCulture));  
        }

        [Test()]
        public void TestAddItem()
        {
            appiumDriver.FindElement(By.Id("Browse")).Click();
            appiumDriver.FindElement(By.Id("AddToolbarItem")).Click();
            var itemNameField = appiumDriver.FindElement(By.Id("ItemNameEntry"));
            itemNameField.SendKeys("todo");

            var itemDesriptionField = appiumDriver.FindElement(By.Id("ItemDescriptionEntry"));
            itemDesriptionField.SendKeys("todo description");

            appiumDriver.FindElement(By.Id("SaveToolbarItem")).Click();
        }

        [Test()]
        public void TestAbout()
        {
            appiumDriver.FindElement(By.Id("About")).Click(); // works for iOS
        }
    }
}
