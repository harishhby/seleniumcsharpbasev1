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
    public class MyPortFolioPage : BasePage
    {

        public MyPortFolioPage(IWebDriver dr)
            : base(dr)
        {

        }

        [FindsBy(How = How.XPath, Using = "//*[@id='addStock']")]
        public IWebElement addStockButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='addstockname']")]
        public IWebElement stockName;

        [FindsBy(How = How.XPath, Using = "//*[@id='stockPurchaseDate']")]
        public IWebElement calender;

        [FindsBy(How = How.XPath, Using = "//*[@id='addstockqty']")]
        public IWebElement quantity;

        [FindsBy(How = How.XPath, Using = "//*[@id='addstockprice']")]
        public IWebElement price;

        [FindsBy(How = How.XPath, Using = "//*[@id='addStockButton']")]
        public IWebElement addStockBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='datepicker']/table/tbody/tr[1]/td[2]/button")]
        public IWebElement backButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='datepicker']/table/tbody/tr[1]/td[3]/div")]
        public IWebElement monthYearDisplayed;

        [FindsBy(How = How.XPath, Using = "//*[@id='createPortfolio']")]
        public IWebElement createLink;

        [FindsBy(How = How.XPath, Using = "//*[@id='create']")]
        public IWebElement create;

        [FindsBy(How = How.XPath, Using = " //*[@id='createPortfolioButton']")]
        public IWebElement createButton;


        public InvestmentPage goToInvestmentPage()
        {
            return new InvestmentPage();
        }

        public void selectPortFolio(string name)
        {
            IWebElement portFolio = driver.FindElement(By.XPath("//*[@id='portfolioid']"));
            portFolio.SendKeys(name);
            portFolio.SendKeys(Keys.Enter);
        }

        public bool verifyPortFolio(string expName)
        {
            IList<IWebElement> port = driver.FindElements(By.XPath("//*[@id='portfolioid']/option"));
            for (int i = 0; i < port.Count; i++)
            {
                if (port.ElementAt(i).Text.Equals(expName))
                {
                    return true;
                }
            }
            return false;
        }

        public void addStock(string name, string date, string stockQuantity, string purchasePrice)
        {
            addStockButton.Click();
            stockName.SendKeys(name);
            driver.FindElement(By.XPath("//div[@id='ajax_listOfOptions']/div[1]")).Click();
            calender.Click();

            DateTime currentDate = DateTime.Now;
            Console.WriteLine(currentDate);

            DateTime dateToBeSelected = Convert.ToDateTime(date);
            Console.WriteLine(currentDate.CompareTo(dateToBeSelected));

            string month = dateToBeSelected.ToString("MMMM");
            Console.WriteLine(month);

            string day = dateToBeSelected.ToString("dd");
            Console.WriteLine(day);

            string year = dateToBeSelected.ToString("yyyy");
            Console.WriteLine(year);

            string monthYearToBeSelected = month + " " + year;
            Console.WriteLine(monthYearToBeSelected);

            while (!monthYearDisplayed.Text.Equals(monthYearToBeSelected))
            {
                if (currentDate.CompareTo(dateToBeSelected) == 1)
                {
                    backButton.Click();
                }
                else if (currentDate.CompareTo(dateToBeSelected) == -1)
                {
                    //frwd button
                }
                monthYearDisplayed = driver.FindElement(By.XPath("//*[@id='datepicker']/table/tbody/tr[1]/td[3]/div"));
            }

            driver.FindElement(By.XPath("//td[text()=" + day + "]")).Click();
            quantity.SendKeys(stockQuantity);
            price.SendKeys(purchasePrice);
            addStockBtn.Click();
        }

        public bool verifyStock(string name)
        {
            IList<IWebElement> names = driver.FindElements(By.XPath("//table[@id='stock']/tbody/tr/td[2]"));
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names.ElementAt(i).Text);
            }
            return true;
        }

        public void createNewPortFolio(string portFolioName)
        {
            createLink.Click();
            create.Clear();
            create.SendKeys(portFolioName);
            create.SendKeys(Keys.Enter);
            createButton.Click();

        }

        public bool verifyNewPortFolio(string portFolioName)
        {
            int maxTime = 10;
            int time = 1;
            while (time <= maxTime)
            {
                IWebElement port = driver.FindElement(By.XPath(".//*[@id='portfolioid']/option[@selected='selected']"));
                Console.WriteLine(port.Text);

                if (port.Text.Equals(portFolioName))
                {
                    return true;
                }
                else
                {
                    Thread.Sleep(1000);
                    time++;
                }
            }
            return false;

        }

    }
}
