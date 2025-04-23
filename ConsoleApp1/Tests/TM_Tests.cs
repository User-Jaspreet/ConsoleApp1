using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Test_Analyst_Project.Utilities;
using Test_Analyst_Project.Pages;

namespace TestAnalystProject.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
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
            new HomePage().NavigateToTMPage(driver);
        }

        [Test]
        public void CreateTime_Test()
        {
            // TM page object initiliazation and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);
        }

        [Test]
        public void EditTime_Test()
        {
            // Edit time record
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRecord(driver);

        }

        [Test]
        public void DeleteTime_Tests()
        {
            //Delete time record
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}



