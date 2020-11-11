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
            ProjectData specificProject = new ProjectData()
            {
                Name = "project to delete",
            };

            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            applicationManager.projectHelper.CheckSpecificProjectCreateIfNot(specificProject, account);

            Mantis.ProjectData[] oldProjects = applicationManager.API.GetAllProjects(account);
            int index = applicationManager.projectHelper.GetIndexOfProject(oldProjects, specificProject);
            Mantis.ProjectData forRemoving = oldProjects[index];

            applicationManager.projectHelper.Remove(forRemoving);

            Assert.AreEqual(oldProjects.Length - 1, applicationManager.API.GetAllProjects(account).Length);

            Mantis.ProjectData[] newProjects = applicationManager.API.GetAllProjects(account);

            var oldList = oldProjects.ToList();
            oldList.RemoveAt(index);

            var newList = newProjects.ToList();

            Assert.AreEqual(oldList, newList);

            foreach (Mantis.ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project, forRemoving);
            }
        }
    }
}
