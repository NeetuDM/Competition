using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars_CompetitionTask.GlobalDefinitions;
using ProjectMars_CompetitionTask.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_CompetitionTask.Pages
{
    public class Login : CommonDriver

    {

        public Login(IWebDriver driver)
        {
            driver = driver;

        }


        //Identify the Elements 
        private IWebElement SignInButton => driver.FindElement(By.XPath("//*[@id=\'home\']/div/div/div[1]/div/a"));
        private IWebElement emailaddressTextbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private IWebElement passwordTextbox => driver.FindElement(By.XPath("//div/div/div[1]/div/div[2]/input"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//div/div/div[1]/div/div[4]/button"));


        public void LoginSteps()
        {
            driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl("http://localhost:5000");
            GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "SignIn");
            Thread.Sleep(5000);
            driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            Thread.Sleep(2000);

            try
            {

                SignInButton.Click();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Mars Sign in Page did not launch", ex.Message);

            }

            emailaddressTextbox.SendKeys(ExcelLib.ReadData(2, "Username"));
            Thread.Sleep(1000);

            passwordTextbox.SendKeys(ExcelLib.ReadData(2, "Password"));
            Thread.Sleep(1000);

            loginButton.Click();
            Thread.Sleep(3000);
        }

    }
}
