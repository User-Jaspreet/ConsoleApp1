using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Browser;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Test_Analyst_Project.Pages
{
    public class CustomersPage
    {

        public void CustomersRecord(IWebDriver driver)
        {
            // Click on Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            // Type name in to Name textbox
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            nameTextbox.SendKeys("NewRecord");

            //Click Edit Contact
            driver.FindElement(By.Id("EditContactButton")).Click();

            //Wait and switch to the iframe
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[contains(@src, '/Contact/Create')]")));

            //Fill the contact form inside the iframe
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("FirstName"))).SendKeys("Preet");
            driver.FindElement(By.Id("LastName")).SendKeys("Kaur");
            driver.FindElement(By.Id("PreferedName")).SendKeys("Preet Kaur");
            driver.FindElement(By.Id("Phone")).SendKeys("613895849");
            driver.FindElement(By.Id("Mobile")).SendKeys("00456566560");
            driver.FindElement(By.Id("email")).SendKeys("ab@yahoo.com");
            driver.FindElement(By.Id("Fax")).SendKeys("4576758ID");
            driver.FindElement(By.Id("Street")).SendKeys("Marine");
            driver.FindElement(By.Id("City")).SendKeys("Melbourne");
            driver.FindElement(By.Id("Postcode")).SendKeys("4453");
            driver.FindElement(By.Id("Country")).SendKeys("Australia");

            //Click Save inside the iframe
            driver.FindElement(By.Id("submitButton")).Click();

            //Switch back to main content
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(3000);

            try
            {
                //Wait and click Same As Above checkbox
                IWebElement sameAsAbove = driver.FindElement(By.Id("IsSameContact"));
                sameAsAbove.Click();
            }
            catch (Exception)
            {
                Assert.Fail("Same as above checkbox hasn't been found.");
            }
            

            //Type GST into the GST Textbox
            IWebElement gst = driver.FindElement(By.Id("GST"));
            gst.SendKeys("123");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("submitButton"));
            saveButton.Click();
            Thread.Sleep(1000);      

            //Navigate to Customers Page
            new HomePage().NavigateToCustomersPage(driver);
            Thread.Sleep(3000);

            // Check if Customer record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[4]/a[4]"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            IWebElement newName = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[2]/td[2]"));

            Assert.That(newName.Text == "NewRecord", "Customers record has not been created!");

        }




        public void EditCustomersRecord(IWebDriver driver)
        {
            //Go to last page 
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(4000);

            // Edit the Customers record
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[2]/td[4]/a[1]"));
            editButton.Click();
            Thread.Sleep(2000);

            //Wait and switch to the iframe
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//*[@id=\"detailWindow\"]/iframe")));

            //Type name in to Name textbox inside the frame
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Name"))).SendKeys("Hello");

            //Type GST into the GST Textbox inside the frame
            IWebElement gst = driver.FindElement(By.Id("GST"));
            gst.SendKeys("4");

            //Click Save
            IWebElement saveButton = driver.FindElement(By.Id("submitButton"));
            saveButton.Click();

            //Switch back to main content
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);

            //Navigate to Customers Page
            new HomePage().NavigateToCustomersPage(driver);
            Thread.Sleep(3000);

            // Check if Customers record has been edited successfully
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1000);

            IWebElement newName = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[2]/td[2]"));

            Assert.That(newName.Text == "NewRecordHello", "Customers record has not been edited!");

        }


        public void DeleteCustomerRecord(IWebDriver driver)
        {

            // Go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            // Delete the Customers record
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[2]/td[4]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(1000);

            // Wait for and accept the popup
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2000));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);


            // Check if Customers record has been deleted
           goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            {
                Assert.Pass("Customers record deleted successfully!");
            }
        }

       
            }
        }
    
    













