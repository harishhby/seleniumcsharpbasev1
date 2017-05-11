using ExcelReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.TestCases
{
    public class BaseTest
    {
        public IWebDriver driver;
        public static ExcelReaderFile xls = new ExcelReaderFile(@"E:\csharpabstarct\New folder (4)\New folder\New folder\Module_15\POM_Overview\TestAutomation\Data.xlsx");
        public bool gridRun = false;

        public void openBrowser(string bName)
        {
            if (!gridRun)
            {
                if (bName.Equals("Mozilla"))
                    driver = new FirefoxDriver();
                else if (bName.Equals("Chrome"))
                    driver = new ChromeDriver("E://");

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                driver.Manage().Window.Maximize();
            }
            else
            {

                DesiredCapabilities cap = null;
                if (bName.Equals("Mozilla"))
                {
                    cap = DesiredCapabilities.Firefox();
                    cap.SetCapability(CapabilityType.BrowserName, "firefox");
                    cap.SetCapability(CapabilityType.Platform, "WINDOWS");
                }
                else if (bName.Equals("Chrome"))
                {
                    cap = DesiredCapabilities.Chrome();
                    cap.SetCapability(CapabilityType.BrowserName, "chrome");
                    cap.SetCapability(CapabilityType.Platform, "WINDOWS");
                }

                try
                {
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), cap);
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    driver.Manage().Window.Maximize();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
