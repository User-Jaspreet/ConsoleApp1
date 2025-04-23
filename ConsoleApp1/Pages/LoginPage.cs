﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Test_Analyst_Project.Pages
{
    public class LoginPage
    {
        // Functions that allow users to login to TurnUp portal
        public void LoginActions(IWebDriver driver)
        {
            // Launch Turnup portal 
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            try
            {
                // Identify username textbox and enter valid UserName
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");
            }
            catch (Exception)
            {
                Assert.Fail("Username textbox not located.");
            }



            // Identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // Identify loginButton and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(5000);
        }

        
    }

}
