using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void GoToManageOverviewPage()
        {
            driver.FindElement(By.CssSelector("a[href*='manage_overview_page.php']")).Click();
        }
        public void GoToProjectsPage()
        {
            driver.FindElement(By.CssSelector("ul.nav-tabs li:nth-child(3)")).Click();
        }

        public void InitiateProjectCreating()
        {
            driver.FindElement(By.CssSelector(".widget-box .widget-toolbox button.btn-primary")).Click();
        }
    }
}
