using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace SimpleApp.Appium.Core
{
    [TestFixture]
    public class TestMainPage_iOS: TestMainPage<IOSDriver<IOSElement>, IOSElement>
    {
        public TestMainPage_iOS(): base("MainPageTests")
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
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "DD98F854-8AEF-489A-9A4A-9BCD0DA078ED");
            appiumOptions.AddAdditionalCapability(IOSMobileCapabilityType.BundleId, "com.companyname.SimpleApp");
        }
    }
}
