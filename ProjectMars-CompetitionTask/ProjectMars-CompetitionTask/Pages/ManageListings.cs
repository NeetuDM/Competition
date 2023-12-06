using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars_CompetitionTask.GlobalDefinitions;
using ProjectMars_CompetitionTask.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_CompetitionTask.Pages
{
    public class ManageListings : CommonDriver
    {
        public ManageListings(IWebDriver driver)
        {
            driver = driver;

        }
        private IWebElement ManageListingButton => driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]"));
        //private IWebElement ManageListingButton=> driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/section[1]/div[1]/a[3]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
        private IWebElement editedTitleTextBox => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));

        private IWebElement EditedTitleTextBox1 => driver.FindElement(By.XPath("//*/div[2]/div[1]/div[1]/table/tbody/tr/td[3]"));

        private IWebElement editedDescriptionTextBox => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));

        private IWebElement TagsTextBox => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
       

        private IWebElement SkillExchangeTagTextBox => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[8]/div[4]/div/div/div/div/span"));
        private IWebElement ActiveRadioButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/label"));
        private IWebElement EditSaveButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[11]/div/input[1]"));
        private IWebElement DeleteButton => driver.FindElement(By.XPath("//*[@id=\'listing-management-section\']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]"));


        public void GoToManageListingPage()
        {
            
            ManageListingButton.Click();
            Thread.Sleep(3000);

        }
        public void EditShareSkill()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "Edited");
            

            editButton.Click();
            Thread.Sleep(3000);

            editedTitleTextBox.Click();
            editedTitleTextBox.Clear();
            editedTitleTextBox.SendKeys(ExcelLib.ReadData(2, "Title"));
            Thread.Sleep(3000);

            editedDescriptionTextBox.Click();
            editedDescriptionTextBox.Clear();
            editedDescriptionTextBox.SendKeys(ExcelLib.ReadData(2, "Description"));
            Thread.Sleep(3000);

            TagsTextBox.Clear();
            TagsTextBox.SendKeys(ExcelLib.ReadData(2, "Tags"));
            TagsTextBox.SendKeys(Keys.Return);
            Thread.Sleep(2000);

            EditSaveButton.Click();
            Thread.Sleep(3000);

           

            //Assert that Share skill record has been edited.
            //IWebElement editedTitleTextBox1 = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            //IWebElement editedDescriptionTextBox1 = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
            

           // Assert.That(editedTitleTextBox1.Text == "Automation Testing", "Actual code and expected code do not match");
           //Assert.That(editedDescriptionTextBox1.Text == "5 years of Automation Testing experience", "Actual code and expected code do not match");

        }
           //Assertion

        public string EditedTitle()
        {

            IWebElement EditedTitleTextBox = driver.FindElement(By.XPath("//*[@id=\'listing-management-section\']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            string newEditedTitleCheck = EditedTitleTextBox.Text;
            return newEditedTitleCheck;
        }

        public string excelEditedTitle()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "Edited");
            string ExcelEditedTitle = ExcelLib.ReadData(2, "Title");
            return ExcelEditedTitle;

        }



        public void DeleteShareSkill()


        {
            Thread.Sleep(3000);
            IWebElement goToManageListingButton1 = driver.FindElement(By.XPath("//div/section[1]/div/a[3]"));
            goToManageListingButton1.Click();
            Thread.Sleep(5000);



            if (EditedTitleTextBox1.Text == "Automation Testing")
            {

               DeleteButton.Click();
               Thread.Sleep(5000);


                //driver.SwitchTo().Alert().Accept();
                IWebElement YesDeleteButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
                YesDeleteButton.Click();
                Thread.Sleep(1000);

            }

            else
            {
                Assert.Fail("Record to be deleted hasn't been found. Record not deleted.");

            }


            //Assert that Share skill record has been deleted.

            IWebElement goToManageListingButton = driver.FindElement(By.XPath("//*[@id='listing-management-section']/section[1]/div/a[3]"));
            goToManageListingButton.Click();
            Thread.Sleep(5000);

            IWebElement editedTitleTextBox1 = driver.FindElement(By.XPath("//*[@id=\'listing-management-section\']/div[2]/div[1]/div[1]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedDescriptionTextBox1 = driver.FindElement(By.XPath("//*[@id=\'listing-management-section\']/div[2]/div[1]/div[1]/table/tbody/tr[last()]/td[4]"));

           
            Assert.That(editedTitleTextBox1.Text != "Automation Testing", "Code record hasn't been deleted.");
            Assert.That(editedDescriptionTextBox1.Text != "5 years of Automation Testing Experience", "Code record hasn't been deleted.");

        }
    }

}






