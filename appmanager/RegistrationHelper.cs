using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl(account);
            ConfirmAccountCreation(url);
            FillPaswordForm(account);
            SubmitPasswordForm();
        }



        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.28.1/login_page.php";
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.ClassName("back-to-login-link")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.ClassName("btn-success")).Click();
        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match =  Regex.Match(message, @"https?://\S+");
            return match.Value;
        }

        private void ConfirmAccountCreation(string url)
        {
            driver.Url = url;
        }
        private void FillPaswordForm(AccountData account)
        {
            
            driver.FindElement(By.Name("realname")).SendKeys(account.Name);
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.ClassName("btn-success")).Click();
        }
    }
}
