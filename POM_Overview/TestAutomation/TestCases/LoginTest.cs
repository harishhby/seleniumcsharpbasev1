using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using POM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelReader;
using POM.Util;

namespace TestAutomation.TestCases
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class LoginTest : BaseTest
    {
        [Test, TestCaseSource("getData")]
        public void loginTest(string runmode, string username, string password, string expected_Result, string browser)
        {
            openBrowser(browser);

            if (!DataUtil.isTestRunnable(xls, "LoginTest") || runmode.Equals("N"))
                Assert.Ignore("Runmode is No");
            LaunchPage lPage = new LaunchPage(driver);
            PageFactory.InitElements(driver, lPage);
            LoginPage loginPage = lPage.goToLoginPage();
            object resultPage = loginPage.doLogin(username, password);
            if (resultPage is LoginPage)
                Console.WriteLine("Not logged in");
            else if (resultPage is MyPortFolioPage)
                Console.WriteLine("Logged in");
        }

        //Data Source

        public static object[] getData()
        {
            return DataUtil.getData(xls, "LoginTest");
        }

        [TearDown]
        public void quit()
        {
            if (driver != null)
                driver.Quit();
        }

    }
}
