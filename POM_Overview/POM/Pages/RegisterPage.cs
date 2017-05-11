using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver dr)
            : base(dr)
        {

        }

        public void goToRegisterPage()
        {
            driver.Url = "https://register.rediff.com/commonreg/index.php?redr=http://portfolio.rediff.com/portfolio";
        }
    }
}
