using NUnit.Framework;
using EnrichKidAdminAutomation.Base;
using EnrichKidAdminAutomation.Pages;

namespace EnrichKidAdminAutomation.Tests
{
    public class LoginAndGoToUsersTest : BaseTest
    {
        [Test]
        public void LoginAndNavigateToUsers()
        {
            Thread.Sleep(2000); // Wait for 2 seconds before starting the test
            if (driver == null)
            {
                throw new InvalidOperationException("WebDriver instance 'driver' is not initialized.");
            }

            var loginPage = new LoginPage(driver);


            loginPage.Login("superadmin_enrichkids@yopmail.com", "password");

            // var manageUsersPage = new ManageUsersPage(driver);
            // manageUsersPage.ManageUsers();
            // manageUsersPage.AddnewUser();
            // var manageVendorsPage = new ManageVendorsPage(driver);
            // manageVendorsPage.AddNewVendor();
            // manageVendorsPage.FillNewVendorForm();
            // ManageParentsPage manageParentsPage = new ManageParentsPage(driver);
            // manageParentsPage.AddNewParent();
            // manageParentsPage.FillNewParentForm();
            var addNewProgramPage = new AddNewProgramPage(driver);
            addNewProgramPage.AddNewProgram();
            addNewProgramPage.FillNewProgramForm();

        }

    }
}
