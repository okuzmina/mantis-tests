using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager): base(manager)
        {
        }

        public void OpenManagementMenu()
        {
            driver.FindElement(By.XPath("//span[contains(text(),'Manage')]")).Click();
        }

        public void OpenProjectMenu()
        {
            OpenManagementMenu();
            driver.FindElement(By.XPath("//span[contains(text(),'Manage Projects')]")).Click();
        }
    }
}
