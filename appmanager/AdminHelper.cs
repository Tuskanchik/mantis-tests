using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager) 
        {
            this.baseUrl = baseUrl;    
        }

        public List<AccountData> GetAllAccounts()
        {
            IWebDriver driver = OpenAppAndLogin();

            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/manage_user_page.php");

                IList<IWebElement> rows = driver.FindElements(By.CssSelector("table.table-bordered tbody tr"));

                List<AccountData> accounts = new List<AccountData>();

                foreach (IWebElement row in rows)
                {
                    IWebElement link = row.FindElement(By.TagName("a"));
                    string name = link.Text;
                    string href = link.GetAttribute("href");
                    if (href == null)
                    {
                        throw new Exception("Confirmation link not found in email");
                    }
                    Match m = Regex.Match(href, @"\d+$");

                    accounts.Add(new AccountData()
                    {
                        Id = m.Value,
                        Name = name
                    });
                }

                return accounts;
            }
            finally
            {
                driver.Quit();
            }
        }

        public void DeleteAccount (AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("button[formaction='manage_user_delete.php']")).Click();
            driver.FindElement(By.CssSelector("input.btn")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");

            IWebDriver driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl(baseUrl + "/login_page.php");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("password")).SendKeys("secret");
            driver.FindElement(By.CssSelector("input.btn-success")).Click();
            Thread.Sleep(1500);
            return driver;
        }
    }
}
