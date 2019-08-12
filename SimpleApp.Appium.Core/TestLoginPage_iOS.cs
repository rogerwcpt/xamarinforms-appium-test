using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace SimpleApp.Appium.Core
{
    [TestFixture]
    public class TestLoginPage_iOS: TestLoginPage<IOSDriver<IOSElement>, IOSElement>
    {
        public TestLoginPage_iOS(): base("LoginPageTest")
        {
        }

        protected override IOSDriver<IOSElement> GetDriver()
        {
            return new IOSDriver<IOSElement>(driverUri, appiumOptions);
        }

        protected override void InitAppiumOptions(AppiumOptions appiumOptions)
        {
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "iPhone 8 Plus");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12.2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "EAD887F5-E4B5-462C-9A4C-C32F5D31E58F");
            appiumOptions.AddAdditionalCapability(IOSMobileCapabilityType.BundleId, "com.companyname.SimpleApp");
        }
    }
}
