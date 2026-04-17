using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void CreateProject(ProjectData project)
        {
            manager.Menu.InitiateProjectCreating();
            FillProjectForm(project);
            SubmitProjectCreation();
        }
        public void RemoveProject(ProjectData project)
        {
            driver.FindElement(By.XPath("//table[contains(@class,'table-striped')]//a[normalize-space()='" + project.Name + "']")).Click();
            driver.FindElements(By.CssSelector("#manage-proj-update-div .widget-toolbox button"))[1].Click();
            driver.FindElement(By.CssSelector("input.btn-primary")).Click();
        }
        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector(".widget-box .widget-toolbox input.btn-primary")).Click();
        }

        public void RemoveProjectIfExists(ProjectData project)
        {
            if (CheckProjectExistsInProjectsList(project))
            {
                RemoveProject(project);
            }

        }

        public bool CheckProjectExistsInProjectsList(ProjectData project)
        {
            var elements = driver.FindElements(By.XPath("//a[text()='" + project.Name + "']"));
            if (elements.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void CreateProjectIfNotExists(ProjectData project)
        {
            if (!CheckProjectExistsInProjectsList(project))
            {
                CreateProject(project);
            }
        }
    }
}
