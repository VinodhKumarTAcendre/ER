using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using RelevantCodes.ExtentReports.Config;
using System;
using System.Collections;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Library.Extent_Reports
{
    public class ExtentReport
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static string ReportPath = null;
        public static Hashtable ht = new Hashtable();
        public static void CExtentReport(IWebDriver _driver)
        {
            string _BrowserName = _driver.GetType().FullName;
            string[] _name = _BrowserName.Split('.');
            if (!ht.ContainsKey(_name[2]))
            {
                string _path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                string _actualPath = _path.Substring(0, _path.LastIndexOf("bin"));
                string _projectPath = new Uri(_actualPath).LocalPath;
                string _reportPath = _projectPath + "Output\\ExtentReports\\";
                string _CurrentDate = Convert.ToString(DateTime.Now);
                string _FileName = _CurrentDate.Replace("/", "_").Replace(":", "_").Replace(" ", "_");
                _reportPath += _name[2] + "_ExtentReport_" + _FileName + ".html";
                ReportPath = _reportPath;
                try
                {
                    if (!File.Exists(ReportPath))
                    {
                        File.Create(ReportPath).Close();
                    }
                }
                catch (FileNotFoundException fnfe)
                {
                    Console.WriteLine(fnfe.Message);
                }
                catch (FileLoadException fle)
                {
                    Console.WriteLine(fle.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                ht.Add(_name[2], ReportPath);
            }
            if (ht.ContainsKey(_name[2]))
            {
                string value = (string)ht[_name[2]];
                ReportPath = value;
                extent = new ExtentReports(ReportPath, false);
                extent
                    .AddSystemInfo("Host Name", "Acendre")
                    .AddSystemInfo("Environment", "QA4")
                    .AddSystemInfo("Application", "eRecruit")
                    .AddSystemInfo("Owner", "Vinodh Kumar T");
            }
        }

        public static string Capture(IWebDriver driver)
        {
            string CurrentDate = Convert.ToString(DateTime.Now);
            string screenShotName = CurrentDate.Replace("/", "_").Replace(":", "_").Replace(" ", "_");
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Output\\ErrorScreenshots\\" + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Jpeg);
            return localpath;
        }

    }
}
