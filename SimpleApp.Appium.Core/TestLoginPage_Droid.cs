//package <set your test package>;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;


namespace Experitest
{
    [TestFixture]
    public class TestLoginPage_Droid
    {
        private string reportDirectory = "reports";
        private string reportFormat = "xml";
        private string testName = "Untitled";
        protected AndroidDriver<AndroidElement> _driver;
        private AppiumOptions _appiumOptions;

        [SetUp()]
        public void SetupTest()
        {
            _appiumOptions = new AppiumOptions();

            _appiumOptions.AddAdditionalCapability("reportDirectory", reportDirectory);
            _appiumOptions.AddAdditionalCapability("reportFormat", reportFormat);
            _appiumOptions.AddAdditionalCapability("testName", testName);
            _appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel_2_API_24");
            _appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.companyname.simpleapp");
            _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "md57f24161a4fad3f027b401a142d1bd9c4.MainActivity");
            _appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, "false");

            _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), _appiumOptions);
            _driver.CloseApp();
        }

        [Test()]
        public void TestLogin()
        {
            _driver.LaunchApp();
            _driver.FindElement(By.Id("UserNameAID")).SendKeys("user@email.com");
            _driver.FindElement(By.Id("PasswordAID")).SendKeys("password");

            _driver.FindElement(By.Id("LoginButtonAID")).Click();
            var text = _driver.FindElement(By.Id("StatusLabelAID")).GetAttribute("text"); // GetProperty Not Implemented yet

            Assert.IsNotNull(text);
            Assert.IsTrue(text.StartsWith("Logging in"));
        }

        [Test()]
        public void TestAddItem()
        {
            _driver.LaunchApp();
            _driver.FindElement(By.XPath("//*[@text='BROWSE']")).Click();
            _driver.FindElement(By.XPath("//*[@text='ADD']")).Click();
            var itemNameField = _driver.FindElement(By.Id("ItemNameAID"));
            itemNameField.Clear();
            itemNameField.SendKeys("todo ");

            var itemDesriptionField = _driver.FindElement(By.Id("ItemDescriptionAID"));
            itemDesriptionField.Clear();
            itemDesriptionField.SendKeys("todo description");

            _driver.FindElement(By.XPath("//*[@text='SAVE']")).Click();
        }

        [Test()]
        public void TestAbout()
        {
            _driver.LaunchApp();
            //_driver.FindElement(By.XPath("xpath=//*[@contentDescription='LoginButtonAID']")).Click();
             //element = driver.find_element_by_xpath("//*[@class='android.support.v7.app.ActionBar$Tab'][@index='{tab_ind}']".format(tab_ind = tab_index))
            _driver.FindElement(By.XPath("//*[@text='ABOUT']")).Click();
        }

        [TearDown()]
        public void TearDown()
        {
            //_driver.Quit();
        }
    }
}