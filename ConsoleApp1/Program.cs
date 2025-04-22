using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using ConsoleApp1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V133.Network;
using OpenQA.Selenium.DevTools.V133.PWA;
using OpenQA.Selenium.Support.UI;

public class Program
{
    public static void Main(string[] args)

    {
        // Open chrome browser
        IWebDriver driver = new ChromeDriver();

        // Implicit Wait
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Login page object initiliazation and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        //Home page object initiliazation and definition
        new HomePage().NavigateToTMPage(driver);

        // TM page object initiliazation and definition
        TMPage tMPageObj = new TMPage();
        tMPageObj.CreateTimeRecord(driver);

        // Edit time record
        tMPageObj.EditTimeRecord(driver);

        //Delete time record
        tMPageObj.DeleteTimeRecord(driver);

        //Navigate to Administration Tab

        //Home page object initiliazation and definition
        new HomePage().NavigateToCustomersPage(driver);

        // Customers page object initiliazation and definition
        CustomersPage customersPageObj = new CustomersPage();
        customersPageObj.CustomersRecord(driver);

        //Edit customers records
        customersPageObj.EditCustomersRecord(driver);

        //Delete the customers records
        customersPageObj.DeleteCustomerRecord(driver);










    }
}





