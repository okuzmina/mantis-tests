using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateNewProject(ProjectData project)
        {
            driver.FindElement(By.XPath("//button[contains(text(),'Create New Project')]")).Click();
            Type(By.Name("name"), project.Name);
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
        }

        public void OpenProject(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/a[" + index +"]")).Click();
        }

        public void OpenProjectByName(ProjectData project)
        {
            driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/a[contains(text()," + project.Name +")]")).Click();
        }

        public void DeleteProject(ProjectData project)
        {
            OpenProjectByName(project);
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            SubmitDeletion();
        }

        public void SubmitDeletion()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public int GetProjectCount()
        {
            return driver.FindElements(By.CssSelector("//div[@class='table - responsive']//tbody//tr//a")).Count;
        }

        private List<ProjectData> projectCache = null;
        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("//div[@class='table - responsive']//tbody//tr//a"));
                foreach (IWebElement element in elements)
                {
                    projectCache.Add(new ProjectData(element.Text)
                    {
                        Name = element.FindElement(By.TagName("a")).Text
                    }) ;
                }
            }

            return new List<ProjectData>(projectCache);
        }

        public ProjectManagementHelper CheckExistngCreateIfNot()
        {
            if (!IsProjectExist())
            {
                ProjectData projectNew = new ProjectData("pre-created");
                CreateNewProject(projectNew);
            }
            return this;
        }

        public bool IsProjectExist()
        {
            return IsElementPresent(By.PartialLinkText("manage_proj_edit_page.php"));
        }

        public ProjectManagementHelper Remove(ProjectData project)
        {
            manager.menuHelper.OpenProjectMenu();
            DeleteProject(project);
            manager.menuHelper.OpenProjectMenu();
            return this;
        }
    }
}
