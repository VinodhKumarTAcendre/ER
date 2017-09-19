using eRecruit.Library;
using eRecruit.Library.Log4Net;
using eRecruit.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Tests
{
    public class _01_BrowserClass
    {       
        public static void LaunchBrowser(IWebDriver driver)
        {
            string _url = ConfigurationManager.AppSettings["URL"];
            int wait = Convert.ToInt32(ConfigurationManager.AppSettings["WaitTime"]);
            string _BrowserName = driver.GetType().FullName;
            string[] _name = _BrowserName.Split('.');
            if (_name[2] == "IE")
            {
                Logger.log.Info(" Launching Internet Explorer Browser");
                driver.Url = _url;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            }
            else if (_name[2] == "Firefox")
            {
                Logger.log.Info(" Launching Firefox Browser");
                driver.Navigate().GoToUrl(_url);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            }
            else if (_name[2] == "Chrome")
            {
                Logger.log.Info(" Launching Chrome Browser");
                driver.Navigate().GoToUrl(_url);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            }
            else if (_name[2] == "Edge")
            {
                Logger.log.Info(" Launching Microsoft Edge Browser");
                driver.Navigate().GoToUrl(_url);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
                driver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
            }
            else
            {
                Logger.log.Info("Specified Browser :" + _name[2] + " is not supported");
            }
            Logger.log.Info("Login Page Loaded");
            BaseMethods.SleepTimeOut(2000);
            _02_LoginPage _Login = new _02_LoginPage(driver);
            ArrayList list = _Login.GetLoginDetails("ER_TESTDATA", "Login", "KeyName", "Admin");
            string username = list[1].ToString();
            string password = list[2].ToString();
            _Login.eletxtUsername.SendKeys(username);
            Logger.log.Info(" Entered Username: " + username);
            _Login.eletxtPassword.SendKeys(password);
            Logger.log.Info(" Entered Password: " + password);
            _Login.elebtnLogin.Click();
            Logger.log.Info(" Clicked on Login Button");
        }
    }
}
