using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Test_Analyst_Project.Pages;
using Test_Analyst_Project.Utilities;

namespace TestAnalystProject.Tests
{
    [TestFixture]
    public class Customers_Test : CommonDriver
    {


        [SetUp]
        public void SetUpSteps()
        {
            // Open chrome browser
            driver = new ChromeDriver();

            // Login page object initiliazation and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Home page object initiliazation and definition
            new HomePage().NavigateToCustomersPage(driver);
        }

        [Test]
        public void CreateCustomer_Test()
        {
            // Customers page object initiliazation and definition
            CustomersPage CustomersPage = new CustomersPage();
            CustomersPage.CustomersRecord(driver);
        }

        [Test]
        public void EditCustomersRecord_Test()
        {
            // Edit Customers record
            CustomersPage customersPageObj = new CustomersPage();
            customersPageObj.EditCustomersRecord(driver);

        }

        [Test]
        public void DeleteCustomersRecord_Tests()
        {
            //Delete Customers record
            CustomersPage customersPageObj = new CustomersPage();
            customersPageObj.DeleteCustomerRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}

