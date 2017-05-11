using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class TopMenu
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='signin_info']/a")]
        public IWebElement signOut;

        public void logout()
        {
            signOut.Click();
        }

        public void goToWatchList()
        {

        }
    }
}
