using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;


namespace SimpleApp.Appium.Core
{
    [TestFixture]
    public class TestLoginPage_Droid: TestLoginPage<AndroidDriver<AndroidElement>, AndroidElement>
    {
        public TestLoginPage_Droid() : base("LoginPageTest") {}

        protected override AndroidDriver<AndroidElement> GetDriver()
        {
           return new AndroidDriver<AndroidElement>(driverUri, appiumOptions);
        }

        protected override void InitAppiumOptions(AppiumOptions appiumOptions)
        {
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus_5_API_24");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.companyname.simpleapp");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "md57f24161a4fad3f027b401a142d1bd9c4.MainActivity");
        }
    }
}