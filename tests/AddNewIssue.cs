using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTest : TestBase
    {
        [Test]

        public void AddNewIssue()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "secret"
            };

            ProjectData project = new ProjectData()
            {
                Id = "26",
            };

            IssueData issue = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "testCategory"
            };

            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
