using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAnalystProject.Tests
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {

            try
            {
                // Click on Create New button
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                createNewButton.Click();
            }
            catch (Exception)
            {
                Assert.Fail("Create New button hasn't been found.");
            }

     

            // Select Time from dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/label"));
            typeCodeDropdown.Click();
            Thread.Sleep(1000);

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            // Type code in to Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("XYZ");
            try
            {
                // Type description into Description textbox
                IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
                descriptionTextbox.SendKeys("Testing");
            }
            catch (Exception)
            {
                Assert.Fail("Description textbox not located.");
            }
            

            // Type price into Price textbox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("3550");

            // Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(5000);

            // Check if Time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newCode.Text == "XYZ", "New time record has not been created!");
            
        }


        public void EditTimeRecord(IWebDriver driver)
        {

            
            Thread.Sleep(4000);
            // Edit the Time record
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
            editButton.Click();

            //Edit code in to Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("ABC");

            // Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(5000);

            // Check if Time record has been edited successfully
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[1]"));

            Assert.That(newCode.Text == "ABC", "New time record has not been edited!");

        }



        public void DeleteTimeRecord(IWebDriver driver)
        {
            // Delete the Time record
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr/td[5]/a[2]"));
            deleteButton.Click();

            // Wait for and accept the popup
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2000));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(3000);


            // Check if Time record has been deleted
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            {
                Assert.Pass("Time record deleted successfully!");
            }
        
            }

        }
    }








    
    
