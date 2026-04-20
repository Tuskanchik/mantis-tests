using Mantis;
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
            var client = GetMantisClient();

            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;

            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;

            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetAllProjects(AccountData account)
        {
            List<ProjectData> allProjects = new List<ProjectData>();

            var client = GetMantisClient();

            Mantis.ProjectData[] projectsFromAPI = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (Mantis.ProjectData project in projectsFromAPI)
            {
                allProjects.Add(new ProjectData()
                {
                    Id = project.id,
                    Name = project.name,
                    Desription = project.description,
                });
            }

            return allProjects;
        }

        public void CreateNewProject(ProjectData project)
        {
            AccountData account = manager.Auth.GetAdminAccount();

            var client = GetMantisClient();

            Mantis.ProjectData projectForAPI = new Mantis.ProjectData();
            projectForAPI.name = project.Name;

            client.mc_project_add(account.Name, account.Password, projectForAPI);
        }

        public void DeleteProject(ProjectData project)
        {
            AccountData account = manager.Auth.GetAdminAccount();

            var client = GetMantisClient();

            client.mc_project_delete(account.Name, account.Password, GetProjectId(project));
        }

        public string GetProjectId(ProjectData project)
        {
            string id = "";
            AccountData account = manager.Auth.GetAdminAccount();

            var client = GetMantisClient();

            List<ProjectData> projects = GetAllProjects(account);
            foreach (ProjectData proj in projects)
            {
                if (proj.Name == project.Name)
                {
                    id = proj.Id;
                    break;
                }
            }
            return id;
        }

        public MantisConnectPortTypeClient GetMantisClient()
        {
            var binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.None;

            var endpoint = new EndpointAddress(
                "http://localhost/mantisbt-2.28.1/api/soap/mantisconnect.php"
            );

            return (new MantisConnectPortTypeClient(binding, endpoint));
        }
    }
}
