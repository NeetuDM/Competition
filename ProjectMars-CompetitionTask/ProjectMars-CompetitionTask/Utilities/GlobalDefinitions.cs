using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_CompetitionTask.Utilities
{
    public class GlobalDefinitions
    {
        #region screenshots
        public class Screenshot
        {
            public static IWebDriver driver { get; set; }
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                if (!System.IO.Directory.Exists(CommonDriver.ScreenshotPath))
                {
                    System.IO.Directory.CreateDirectory(CommonDriver.ScreenshotPath);
                }
                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(CommonDriver.ScreenshotPath + ScreenShotFileName + DateTime.Now.ToString("_dd-MM-yyyy_HHmm") + ".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
            public static string GetScreenshot(IWebDriver driver)
            {
                return ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            }
        }
        #endregion
    }
}
