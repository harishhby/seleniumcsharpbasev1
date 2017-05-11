using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public TopMenu menu;

        public BasePage(IWebDriver dr)
        {
            driver = dr;
            menu = new TopMenu();
            PageFactory.InitElements(driver, menu);
        }

        public bool verifyTitle(string expTitle)
        {
            return false;
        }

        public TopMenu getMenu()
        {

            return menu;
        }

        public bool isElementPresent(string xpathExpr)
        {
            int c = driver.FindElements(By.XPath(xpathExpr)).Count;
            if (c > 0)
                return true;
            else
                return false;
        }

        public void waitForElementToPresent()
        {
            DateTime dt = DateTime.Now;
            DateTime d = dt.AddSeconds(10);
            while (d > DateTime.Now)
            {

            }
        }

    }
}
