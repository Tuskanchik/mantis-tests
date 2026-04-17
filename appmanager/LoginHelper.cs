using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            OpenMainPage();
            FillUserName(account);
            SubmitLogin();
            FillUserPassword(account);
            SubmitLogin();
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.28.1/login_page.php";
        }
        private void FillUserName(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
        }

        private void FillUserPassword(AccountData account)
        {
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
        }

        private void SubmitLogin()
        {
            driver.FindElement(By.ClassName("btn-success")).Click();
        }
    }
}
