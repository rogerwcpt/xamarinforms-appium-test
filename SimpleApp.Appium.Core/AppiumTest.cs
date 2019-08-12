//package <set your test package>;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace SimpleApp.Appium.Core
{
    [SetUpFixture]
    public abstract class AppiumTest<T, W>
        where T : AppiumDriver<W>
        where W : IWebElement
    {
        private readonly string reportDirectory = "reports";
        private readonly string reportFormat = "xml";

        protected AppiumTest(string testName)
        {
            driverUri = new Uri("http://localhost:4723/wd/hub");

            appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("reportDirectory", reportDirectory);
            appiumOptions.AddAdditionalCapability("reportFormat", reportFormat);
            appiumOptions.AddAdditionalCapability("testName", testName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, "false");
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            InitAppiumOptions(appiumOptions);
            appiumDriver = GetDriver();
        }

        [TearDown()]
        public void TearDown()
        {
            // Perform a driver quit so that the report is printed
            appiumDriver.Quit();
        }

        protected abstract T GetDriver();
        protected abstract void InitAppiumOptions(AppiumOptions appiumOptions);
        protected T appiumDriver;
        protected readonly AppiumOptions appiumOptions;
        protected readonly Uri driverUri;
    }


}