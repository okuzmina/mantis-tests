using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    public class AddingProjectTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "new_project"
            };

            List<ProjectData> oldProjects = applicationManager.projectHelper.GetProjectList();

            applicationManager.projectHelper.CreateNewProject(project);

            Assert.AreEqual(oldProjects.Count + 1, applicationManager.projectHelper.GetProjectCount());

            List<ProjectData> newProjects = applicationManager.projectHelper.GetProjectList();

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
