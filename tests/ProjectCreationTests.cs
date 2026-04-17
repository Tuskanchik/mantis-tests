using NUnit.Framework;

namespace mantis_tests

{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void CreateProjectTest()
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
            app.Project.RemoveProjectIfExists(project);

            Assert.AreEqual(app.Project.CheckProjectExistsInProjectsList(project), false);

            app.Project.CreateProject(project);
            
            Assert.AreEqual(app.Project.CheckProjectExistsInProjectsList(project), true);
        }
    }
}