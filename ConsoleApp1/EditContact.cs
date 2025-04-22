using OpenQA.Selenium;

internal class EditContact
{
    internal void CustomersRecord(IWebDriver driver)
    {

        IWebElement newName = driver.FindElement(By.XPath("//*[@id=\"clientsGrid\"]/div[2]/table/tbody/tr[2]/td[2]"));

        if (newName.Text == "NewRecord")
        {
            Console.WriteLine("Customers record created successfully!");
        }
        else
        {
            Console.WriteLine("Customers record has not been created!");
        
    }
    }
}
