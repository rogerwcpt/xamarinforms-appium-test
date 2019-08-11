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
    public class TestLoginPage
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
            _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.companyname.simpleapp");
            _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "md57f24161a4fad3f027b401a142d1bd9c4.MainActivity");


            _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), _appiumOptions);
        }

        [Test()]
        public void TestUntitled()
        {
            _driver.FindElement(By.XPath("xpath=//*[@contentDescription='LoginButtonAID']")).Click();
        }

        [TearDown()]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}