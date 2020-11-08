using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;


namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests: TestBase
    {
        [SetUp]
        public void setUpConfig()
        {
            applicationManager.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("/config_inc.php", FileMode.Open))
            {
                applicationManager.Ftp.Upload("/config_inc.php", localFile);
            };
        }

        [Test]
        public void AccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            applicationManager.Registration.Register(account);
        }

        [TearDown]
        public void restoreConfig()
        {
            applicationManager.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
