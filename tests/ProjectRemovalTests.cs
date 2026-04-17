using System;
using System.Collections.Generic;
using System.Text;

namespace mantis_tests
{
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void RemovalProjectTest()
        {
            AccountData adminAccount = new AccountData()
            {

                Name = "sa",
                Password = "secret",
            };

            ProjectData project = new ProjectData()
            {
                Name = "testProject",
            };

            app.Auth.Login(adminAccount);
            app.Menu.GoToManageOverviewPage();
            app.Menu.GoToProjectsPage();
            app.Project.CreateProjectIfNotExists(project);

            Assert.AreEqual(app.Project.CheckProjectExistsInProjectsList(project), true);

            app.Project.RemoveProject(project);

            Assert.AreEqual(app.Project.CheckProjectExistsInProjectsList(project), false);
        }
    }
}
