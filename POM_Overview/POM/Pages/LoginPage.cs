using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='useremail']")]
        public IWebElement usernameField;
        [FindsBy(How = How.XPath, Using = "//*[@id='userpass']")]
        public IWebElement passwordField;

        public LoginPage(IWebDriver dr)
            : base(dr)
        {

        }

        public object doLogin(string username, string password)
        {
            usernameField.SendKeys(username);
            usernameField.SendKeys(Keys.Enter);

            //LoginPage

            //RegisterPage
            waitForElementToPresent();
            string title = driver.Title;
            if (title.Equals("Rediff.com"))
            {
                RegisterPage registerPage = new RegisterPage(driver);
                PageFactory.InitElements(driver, registerPage);
                return registerPage;
            }


            passwordField.SendKeys(password);
            passwordField.SendKeys(Keys.Enter);

            //MyPortFolioPage

            //LoginPage

            bool result = isElementPresent("//*[@id='renamePortfolio']");
            Console.WriteLine(result);

            if (result)
            {
                MyPortFolioPage myPortFolioPage = new MyPortFolioPage(driver);
                PageFactory.InitElements(driver, myPortFolioPage);
                return myPortFolioPage;
            }
            else
            {
                LoginPage loginPage = new LoginPage(driver);
                PageFactory.InitElements(driver, loginPage);
                return loginPage;
            }
            //  return new LoginPage();

        }
    }
}
