using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class LaunchPage : BasePage
    {
        public LaunchPage(IWebDriver dr)
            : base(dr)
        {

        }

        public LoginPage goToLoginPage()
        {
            // Webdriver
            // driver.url = "url";
            driver.Url = "https://portfolio.rediff.com/portfolio-login";
            LoginPage loginPage = new LoginPage(driver);
            PageFactory.InitElements(driver, loginPage);
            return loginPage;
        }
    }
}
