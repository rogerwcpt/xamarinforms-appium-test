using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace SimpleApp.Appium.Core
{
    public class TestLoginPage<T, W>: AppiumTest<T, W>
        where T : AppiumDriver<W>
        where W : IWebElement
    {
        public TestLoginPage(string testName): base(testName)
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
            appiumDriver.CloseApp();
            appiumDriver.LaunchApp();
        }

        [Test()]
        public void TestLogin()
        {
            appiumDriver.FindElement(By.Id("LoginTabAID")).Click();
            appiumDriver.FindElement(By.Id("UserNameAID")).SendKeys("user@email.com");
            appiumDriver.FindElement(By.Id("PasswordAID")).SendKeys("password");

            appiumDriver.FindElement(By.Id("LoginButtonAID")).Click();
            var text = appiumDriver.FindElement(By.Id("StatusLabelAID")).GetAttribute("text"); // works for iOS (not for android)

            Assert.IsNotNull(text);
            Assert.IsTrue(text.StartsWith("Logging in", StringComparison.CurrentCulture));  
        }

        [Test()]
        public void TestAddItem()
        {
            appiumDriver.FindElement(By.Id("BrowseTabAID")).Click(); // works for iOS (not for android)
            appiumDriver.FindElement(By.Id("AddToolbarButtonAID")).Click();
            var itemNameField = appiumDriver.FindElement(By.Id("ItemNameAID"));
            itemNameField.Clear();
            itemNameField.SendKeys("todo ");

            var itemDesriptionField = appiumDriver.FindElement(By.Id("ItemDescriptionAID"));
            itemDesriptionField.Clear();
            itemDesriptionField.SendKeys("todo description");

            appiumDriver.FindElement(By.Id("SaveToolbarButtonAID")).Click();
        }

        [Test()]
        public void TestAbout()
        {
            appiumDriver.FindElement(By.XPath("//*[@text='ABOUT']")).Click(); // works for Android
            appiumDriver.FindElement(By.Id("AboutTabAID")).Click(); // works for iOS
        }
    }
}
