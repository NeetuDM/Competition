using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars_CompetitionTask.Pages;
using ProjectMars_CompetitionTask.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(2)]

namespace ProjectMars_CompetitionTask.Tests
       
{
    [TestFixture]
    [Parallelizable]
    public class ShareSkill_Tests : CommonDriver
    {
       
        
    [Test, Order(1), Description("Check if user is able to create new record for Shareskill")]

    public void CreateShareSkill()
    {

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Thread.Sleep(3000);
            ShareSkillPage shareskillpageObj = new ShareSkillPage(driver);
            Thread.Sleep(1000);
            shareskillpageObj.GotoShareSkillPage();
            shareskillpageObj.newSkill();
            Thread.Sleep(3000);
            //shareskillpageObj.GoToManageListingButton();
            Thread.Sleep(3000);


            string newTitle = shareskillpageObj.newTitle().ToString();
            string xlTitle = shareskillpageObj.excelTitle().ToString();
            Thread.Sleep(3000);

           Assert.That(xlTitle == newTitle, "Actual Title and expected Title do not match");
           

            //string newdescription = shareskillpageObj.newDescription().ToString();
            //string xlDescription = shareskillpageObj.excelDescription().ToString();
            //Thread.Sleep(2000);

            //Assert.That(newdescription == xlDescription, "Actual Description and expected Description do not match");

        }

     

    [Test, Order(2), Description("Check if user is able to Edit new record for Shareskill")]

    public void EditShareSkill()
    {
          test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
          Thread.Sleep(2000);
          ManageListings managelistingsobj = new ManageListings(driver);
          managelistingsobj.GoToManageListingPage();
          managelistingsobj.EditShareSkill();

        string newEditedTitle = managelistingsobj.EditedTitle().ToString();
        string newexcelEditedTitle = managelistingsobj.excelEditedTitle().ToString();
        
        Assert.That(newEditedTitle == newexcelEditedTitle, "Actual Edited Title and expected Edited Title do not match");

        }



        [Test, Order(3), Description("Check if user is able to Delete new record for Shareskill")]
    public void DeleteShareSkill()
    {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Thread.Sleep(2000);
            ManageListings managelistingsobj = new ManageListings(driver);
            managelistingsobj.DeleteShareSkill();

    }


    }


}
