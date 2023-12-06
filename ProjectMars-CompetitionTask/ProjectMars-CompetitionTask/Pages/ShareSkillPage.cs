using Docker.DotNet.Models;
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
using AutoItX3Lib;


namespace ProjectMars_CompetitionTask.Pages
{
    public class ShareSkillPage : CommonDriver
    {

        public ShareSkillPage(IWebDriver driver)
        {
            driver = driver;

        }

        //Finding Elements by Xpath

        private IWebElement shareskillButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));
        private IWebElement titleTexBox => driver.FindElement(By.Name("title"));
        private IWebElement descriptionTextBox => driver.FindElement(By.Name("description"));
        private IWebElement categoryDropdownmenu => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[3]/div[2]/div/div/select"));
        private IWebElement categoryDropdownmenu1 => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]"));
        private IWebElement subcategoryDropdownmenu => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select"));
        private IWebElement subcategoryDropdownmenu1 => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]"));

        private IWebElement tagsTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add new tag']"));

        private IWebElement servicetypeRadiobutton => driver.FindElement(By.XPath("//div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));


        private IWebElement locationtypeRadioButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));

        private IWebElement CalenderStartButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input"));
        private IWebElement CalenderEndButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));

        private IWebElement SunSelectButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input"));
        private IList<IWebElement> StartButton => driver.FindElements(By.XPath("//input[@name='StartTime']"));
        private IList<IWebElement> EndButton => driver.FindElements(By.XPath("//input[@name='EndTime']"));

        private IWebElement SkillTradeButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
        private IWebElement SkillExchangeTag => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        private IWebElement ActiveRadioButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/label"));
        private IWebElement SaveButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[11]/div/input[1]"));
        private IWebElement WorkSampleButton => driver.FindElement(By.XPath("//*[@id=\'service-listing-section\']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        
        private IList<IWebElement> Days => driver.FindElements(By.XPath("//input[@name='Available']"));

        private IWebElement ManageListingButton => driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]"));
        public void GotoShareSkillPage()
        {
            //click on shareskillbutton
            Thread.Sleep(3000);
            shareskillButton.Click();
            Thread.Sleep(3000);

        }

        public void newSkill()
        {
            AddTitle();
            AddDescription();
            Addcategory();
            AddTag();
            Addservicetype();
            AddLocationtype();
            AddDateandTime();
            AddSkillTrade();
            AddSkillExchange();
            WorkSample();
            Active();
            Save();
            Thread.Sleep(3000);

        }

        public void GoToManageListingButton()
        {
            //click on ManageListingButton
            Thread.Sleep(3000);
            ManageListingButton.Click();
            Thread.Sleep(5000);

        }
        public void AddTitle()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "SignIn");

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input", 3);
            titleTexBox.Click();
            titleTexBox.SendKeys(ExcelLib.ReadData(2, "Title"));
            
        }


        public string newTitle()
        {
            Thread.Sleep(2000);
            IWebElement TitleTextBox = driver.FindElement(By.XPath("//*[@id=\'listing-management-section\']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            string newTitleCheck = TitleTextBox.Text;
            return newTitleCheck;
        }

        public string excelTitle()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "SignIn");
            string ExcelTitle = ExcelLib.ReadData(2, "Title");
            return ExcelTitle;

        }

        

        public void AddDescription()
        {
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea", 3);
            descriptionTextBox.SendKeys(ExcelLib.ReadData(2, "Description"));
            Thread.Sleep(2000);
                
            
        }

        //public string newDescription()
        //{
        //   IWebElement NewDescriptionTextBox = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
        //   string newDescriptionCheck = NewDescriptionTextBox.Text;
        //   return newDescriptionCheck;
        //}

        //public string excelDescription()
        //{
        //    GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "SignIn");
        //    string ExcelDescription = ExcelLib.ReadData(2, "Description");
        //    return ExcelDescription;

        // }


        public void Addcategory()

        {
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select", 3);
            categoryDropdownmenu.Click();

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]", 3);
            categoryDropdownmenu1.Click();

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select", 3);
            subcategoryDropdownmenu.Click();

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]", 3);
            subcategoryDropdownmenu1.Click();

            
        }

        public void AddTag()

        {
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//input[@placeholder='Add new tag']", 3);
            tagsTextBox.SendKeys(ExcelLib.ReadData(2, "Tags"));
            tagsTextBox.SendKeys(Keys.Return);


        }

        public void Addservicetype()
        {

            servicetypeRadiobutton.Click();
            Thread.Sleep(1000);
        }

        public void AddLocationtype()

        {
            locationtypeRadioButton.Click();
            Thread.Sleep(2000);
        }



        public void AddDateandTime()

        {

            CalenderStartButton.Click();
            CalenderStartButton.SendKeys(ExcelLib.ReadData(2, "Start Date").ToString());
            Thread.Sleep(2000);

            CalenderEndButton.Click();
            CalenderEndButton.SendKeys(ExcelLib.ReadData(2, "End Date").ToString());
            Thread.Sleep(1000);

            for (int j = 2; j <= 4; j++)
            {

                string expectedDays = ExcelLib.ReadData(j, "Days").ToString();


                string indexValue = "";


                switch (expectedDays)

                {
                    case "Sun":
                        indexValue = "0";
                        break;

                    case "Mon":
                        indexValue = "1";
                        break;

                    case "Tue":
                        indexValue = "2";
                        break;

                    case "Wed":
                        indexValue = "3";
                        break;

                    case "Thu":
                        indexValue = "4";
                        break;

                    case "Fri":
                        indexValue = "5";
                        break;

                    case "Sat":
                        indexValue = "6";
                        break;

                    case "default":
                        indexValue = "Invalid";
                        break;

                }


                for (int i = 0; i < Days.Count; i++)

                {
                    string availabledays = Days[i].GetAttribute("index").ToString();

                    if (indexValue == availabledays)

                    {
                        Days[i].Click();
                        StartButton[i].SendKeys(ExcelLib.ReadData(j, "Start Time"));
                        EndButton[i].SendKeys(ExcelLib.ReadData(j, "End Time"));
                        Thread.Sleep(3000);
                    }

                }

            }

        }

        public void AddSkillTrade()

        {
            SkillTradeButton.Click();
            Thread.Sleep(1000);
        }


        public void AddSkillExchange()
        {

            SkillExchangeTag.SendKeys("Skill Exchange");
            SkillExchangeTag.SendKeys(Keys.Return);
            Thread.Sleep(2000);
        }

       public void WorkSample()
       {
             WorkSampleButton.Click();
             Thread.Sleep(4000);
             AutoItX3 autoIt = new AutoItX3();
             autoIt.WinActivate("Open");
             Thread.Sleep(3000);
             autoIt.Send(@"C:\Industry Connect\Competition\Competition\ProjectMars-CompetitionTask\ProjectMars-CompetitionTask\FileUpload\Test file.docx");
             Thread.Sleep(3000);
             autoIt.Send("{ENTER}");
             Thread.Sleep(2000);
              

        }

        public void Active()
        {
            ActiveRadioButton.Click();
            Thread.Sleep(2000);

        }

        public void Save()
        { 
        SaveButton.Click();
            Thread.Sleep(6000);
        }





    } 

    }

