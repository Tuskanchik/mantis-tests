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
            AccountData account = app.Auth.GetAdminAccount();

            ProjectData project = new ProjectData()
            {
                Name = "testProject4",
            };

            app.Project.CreateProjectIfNotExists(project);

            app.Auth.Login(account);
            app.Menu.GoToManageOverviewPage();
            app.Menu.GoToProjectsPage();

            Assert.AreEqual(app.Project.CheckProjectExistsInProjectsList(project), true);

            app.Project.RemoveProject(project);

            Assert.AreEqual(app.Project.CheckProjectExistsInProjectsList(project), false);
        }
    }
}
