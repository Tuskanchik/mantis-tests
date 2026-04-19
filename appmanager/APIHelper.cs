using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            var binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.None;

            var endpoint = new EndpointAddress(
                "http://localhost/mantisbt-2.28.1/api/soap/mantisconnect.php"
            );

            var client = new Mantis.MantisConnectPortTypeClient(binding, endpoint);
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;

            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;

            client.mc_issue_add(account.Name, account.Password, issue);
        }
    }
}
