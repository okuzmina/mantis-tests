using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class RemovingProjectTests : TestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            applicationManager.projectHelper.CheckExistngCreateIfNot();

            List<ProjectData> oldProjects = applicationManager.projectHelper.GetProjectList();
            ProjectData forRemoving = oldProjects[0];

            applicationManager.projectHelper.Remove(forRemoving);
            Assert.AreEqual(oldProjects.Count - 1, applicationManager.projectHelper.GetProjectCount());

            List<ProjectData> newProjects = applicationManager.projectHelper.GetProjectList();

            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData group in newProjects)
            {
                Assert.AreNotEqual(group, forRemoving);
            }
        }
    }
}
