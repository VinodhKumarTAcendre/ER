using eRecruit.Library.Extent_Reports;
using eRecruit.Library.Log4Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Library
{
    public class BaseMethods
    {
        /// <summary>
        /// Navigate Back Page Method(Clicks on Browser Back Button)
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public static void Navigate_Back(IWebDriver _driver)
        {
            _driver.Navigate().Back();
        }

        /// <summary>
        /// Navigate Forward Page Method(Clicks on Browser Forward Button)
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public static void Navigate_Forward(IWebDriver _driver)
        {
            _driver.Navigate().Forward();
        }

        /// <summary>
        /// Refresh the Page
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public static void Page_Refresh(IWebDriver _driver)
        {
            _driver.Navigate().Refresh();
        }

        /// <summary>
        /// This function can used to make the Thread Sleep for specified time. The value passed will be used as Mili Seconds
        /// </summary>
        /// <param name="Value">Number of Mili Seconds</param>
        public static void SleepTimeOut(int Value)
        {
            System.Threading.Thread.Sleep(Value);
        }

        /// <summary>
        /// This function will check whether the Alert is present or not. 
        /// If the Alert is present, pass the value to perform action on Alert. Ex: Accept, Dismiss..
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="Value">Alert Action (Accept or Dismiss)</param>
        /// <returns></returns>
        public static void IsAlertPresent(IWebDriver _driver, string Value)
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                if (Value == "Accept")
                {
                    alert.Accept();
                    Console.WriteLine("Alert is Accepted");
                }
                else if (Value == "Dismiss")
                {
                    alert.Dismiss();
                    Console.WriteLine("Alert is Dismissed");
                }
                else
                {
                    Console.WriteLine("Alert Action is Indefined");
                }
            }
            catch (NoAlertPresentException NoAlert)
            {
                Console.WriteLine("No Alert is Present");
                Console.WriteLine(NoAlert.StackTrace);
            }
        }

        /// <summary>
        /// Check whether the Alert is present, returns the alert text
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <returns></returns>
        public static string GetAlertText(IWebDriver _driver)
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                string _text = alert.Text;
                alert.Accept();
                return _text;
            }
            catch (NoAlertPresentException NoAlert)
            {
                Console.WriteLine("No Alert is Present");
                Console.WriteLine(NoAlert.StackTrace);
            }
            return "No Alert is Present";
        }

        /// <summary>
        /// Selects the element in Drop Down List based on Text
        /// </summary>
        /// <param name="Ddl">Drop Down List WebElemnt</param>
        /// <param name="SelectText">Text to Select in Drop Down List</param>
        public static void DdlSelectByText(IWebElement Ddl, string SelectText)
        {
            if (SelectText != "Null")
            {
                SelectElement select = new SelectElement(Ddl);
                select.SelectByText(SelectText);
                InfoLogger(SelectText + " - Option Selected from Drop Down");
            }
        }

        /// <summary>
        /// Selects the element in Drop Down List based on Value
        /// </summary>
        /// <param name="Ddl">Drop Down List WebElemnt</param>
        /// <param name="SelectValue">Value to Select in Drop Down List</param>
        public static void DdlSelectByValue(IWebElement Ddl, string SelectValue)
        {
            SelectElement select = new SelectElement(Ddl);
            select.SelectByValue(SelectValue);
        }

        /// <summary>
        /// Selects the element in Drop Down List based on Index
        /// </summary>
        /// <param name="Ddl">Drop Down List WebElemnt</param>
        /// <param name="SelectIndex">Index to Select in Drop Down List</param>
        public static void DdlSelectByIndex(IWebElement Ddl, int SelectIndex)
        {
            SelectElement select = new SelectElement(Ddl);
            select.SelectByIndex(SelectIndex);
        }

        /// <summary>
        /// Method to press the Control Button
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public static void CtrlKeyDown(IWebDriver _driver)
        {
            Actions action = new Actions(_driver);
            action.SendKeys(Keys.Control + "]").Build().Perform();
        }

        /// <summary>
        /// Method to Release the Control Button
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public static void CtrlKeyUp(IWebDriver _driver)
        {
            Actions action = new Actions(_driver);
            action.KeyUp(Keys.Control);
        }

        /// <summary>
        /// Tiny MCE Editor
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="element">Frame WebElement</param>
        /// <param name="Value">Value to be entered</param>
        public static void TinyMCEEditor(IWebDriver _driver, IWebElement element, string Value)
        {
            string _BrowserName = _driver.GetType().FullName;
            string[] _name = _BrowserName.Split('.');
            if (_name[2] == "IE" || _name[2] == "Edge")
            {
                _driver.FindElement(By.XPath("(//button[@role='presentation'])[14]")).Click();
            }
            _driver.SwitchTo().Frame(element);
            InfoLogger("Switched to Editor");
            IWebElement body = _driver.FindElement(By.CssSelector("body"));
            body.Clear();
            body.SendKeys(Value);
            InfoLogger("Entered Text '" + Value + "' in Editor");
            _driver.SwitchTo().ParentFrame();
            InfoLogger("Switching to Parent Frame");
        }

        /// <summary>
        /// Compare Two String Soft Assert
        /// </summary>
        /// <param name="ExpectedMsg">Expected Message</param>
        /// <param name="ActualMsg">Actual Message</param>
        public static void SoftAssertEqual(string ExpectedMsg, string ActualMsg)
        {
            try
            {
                string _BrowserType = ConfigurationManager.AppSettings["Browser"];
                if (_BrowserType == "IE")
                {
                    ExpectedMsg = ExpectedMsg.Replace("\r\n", " ");
                }
                Assert.AreEqual(ExpectedMsg, ActualMsg, "Assert Pass");
                InfoLogger("Soft Assert Passed");
            }
            catch (AssertionException ex)
            {
                Logger.log.Fatal("Assert Failed: Expected Message: " + ExpectedMsg + "but Message was: " + ActualMsg);
                ExtentReport.test.Log(LogStatus.Fatal, "Assert Failed: Expected Message: " + ExpectedMsg + "but Message was: " + ActualMsg);
                Logger.log.Fatal("Exception Message: " + ex.Message);
                ExtentReport.test.Log(LogStatus.Fatal, "Exception Message: " + ex.Message);
            }
        }

        /// <summary>
        /// Select Radio Button among Group of Radio Buttons
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="element">IWebElement</param>
        /// <param name="Index">Index value</param>
        public static void RadioButtonSelectByIndex(IWebDriver _driver, IWebElement element, int Index)
        {
            string _Name = element.GetAttribute("name");
            IList<IWebElement> rdBtn_ele = _driver.FindElements(By.Name(_Name));
            rdBtn_ele.ElementAt(Index).Click();
        }

        /// <summary>
        /// Page Scroll Down
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public static void PageScrollDown(IWebDriver _driver)
        {
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.PageDown);
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.PageDown);
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.PageDown);
        }

        /// <summary>
        /// Partial Page Scroll Down
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public static void PartialPageScrollDown(IWebDriver _driver)
        {
            //_driver.FindElement(By.TagName("body")).SendKeys(Keys.PageDown);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        /// <summary>
        /// Page Scroll Up
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public static void PageScrollUp(IWebDriver _driver)
        {
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.PageUp);
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.PageUp);
            _driver.FindElement(By.TagName("body")).SendKeys(Keys.PageUp);
        }

        /// <summary>
        /// Select No/Yes Radio Button 
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="element">Radio Button Group IWebElement</param>
        /// <param name="Value">Yes/No</param>
        public static void NoYesRadioButtons(IWebDriver _driver, IWebElement element, string Value)
        {
            if (Value != "Null")
            {
                string _Name = element.GetAttribute("Name");
                IList<IWebElement> GrpRadioButton = _driver.FindElements(By.Name(_Name));
                if (GrpRadioButton != null)
                {
                    if (Value == "No")
                    {
                        GrpRadioButton[0].Click();
                    }
                    else if (Value == "Yes")
                    {
                        GrpRadioButton[1].Click();
                    }
                    else
                    {
                        InfoLogger("Invalid Radio Button Operation");
                    }
                }
            }
        }

        /// <summary>
        /// Select Yes/No Radio Button 
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="element">Radio Button Group IWebElement</param>
        /// <param name="Value">Yes/No</param>
        public static void YesNoRadioButtons(IWebDriver _driver, IWebElement element, string Value)
        {
            if (Value != "Null")
            {
                string _Name = element.GetAttribute("Name");
                IList<IWebElement> GrpRadioButton = _driver.FindElements(By.Name(_Name));
                if (GrpRadioButton != null)
                {
                    if (Value == "Yes")
                    {
                        GrpRadioButton[0].Click();
                    }
                    else if (Value == "No")
                    {
                        GrpRadioButton[1].Click();
                    }
                    else
                    {
                        InfoLogger("Invalid Radio Button Operation");
                    }
                }
            }
        }

        /// <summary>
        /// Selects Radio Button option with the value provided 
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="element">IWebElement</param>
        /// <param name="Value">Value</param>
        public static void SelectRadioButtonWithValue(IWebDriver _driver, IWebElement element, string Value)
        {
            if (Value != "Null")
            {
                string _Name = element.GetAttribute("Name");
                IList<IWebElement> GrpRadioButton = _driver.FindElements(By.Name(_Name));
                try
                {
                    for (int i = 0; i < GrpRadioButton.Count; i++)
                    {
                        if (GrpRadioButton[i].GetAttribute("Value") == Value)
                        {
                            GrpRadioButton[i].Click();
                            break;
                        }
                    }
                }
                catch (NoSuchElementException)
                {
                    InfoLogger("No Radio Button Elements Found. Exception in Method: SelectRadioButtonWithValue");
                }
            }
        }

        /// <summary>
        /// Select the Date in the Calender
        /// Pre Requisite: This works only after the Date WebElement is clicked and Date popup is displayed
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="Value">Date</param>
        public static void SelectDateinCalender(IWebDriver _driver, string Value)
        {
            string[] _temp = Value.Split('-');
            string Day = _temp[0];
            string Month = _temp[1];
            string Year = _temp[2];
            IWebElement ele = _driver.FindElement(By.XPath("//div[@class='datepicker-days']/table/thead/tr[1]/th[2]"));
            ele.Click();
            IWebElement ele01 = _driver.FindElement(By.XPath("//div[@class='datepicker-months']/table/thead/tr/th[2]"));
            ele01.Click();
            IList<IWebElement> elelistYear = _driver.FindElements(By.XPath("//div[@class='datepicker-years']/table/tbody/tr/td/span"));
            for (int i = 0; i < elelistYear.Count; i++)
            {
                string _text = elelistYear[i].Text;
                if (_text == Year)
                {
                    elelistYear[i].Click();
                    break;
                }
            }

            IList<IWebElement> elelistMonth = _driver.FindElements(By.XPath("//div[@class='datepicker-months']/table/tbody/tr/td/span"));
            for (int i = 0; i < elelistMonth.Count; i++)
            {
                string _text = elelistMonth[i].Text;
                if (_text == Month)
                {
                    elelistMonth[i].Click();
                    break;
                }
            }

            IList<IWebElement> elelistDay = _driver.FindElements(By.XPath("//div[@class='datepicker-days']/table/tbody/tr/td[@class='day']"));
            for (int i = 0; i < elelistDay.Count; i++)
            {
                string _text = elelistDay[i].Text;
                if (_text == Day)
                {
                    elelistDay[i].Click();
                    break;
                }
            }
        }

        /// <summary>
        /// Logs the Information in Log4Net and Extent Report
        /// </summary>
        /// <param name="Value">Information Value</param>
        public static void InfoLogger(string Value)
        {
            Logger.log.Info(Value);
            ExtentReport.test.Log(LogStatus.Info, Value);
            Console.WriteLine(Value);
        }

        /// <summary>
        /// Check Box Check or Uncheck
        /// </summary>
        /// <param name="ele">IWebElement</param>
        /// <param name="Value">Yes or No</param>
        /// <param name="CheckBoxName">Name of the Check Box - for reports use</param>
        public static void SelectCheckBox(IWebElement ele, string Value, string CheckBoxName)
        {
            if (Value == "Yes")
            {
                if (!ele.Selected)
                {
                    ele.Click();
                    InfoLogger(CheckBoxName + " : is Checked");
                }
            }
            else
            {
                if (ele.Selected)
                {
                    ele.Click();
                }
                InfoLogger(CheckBoxName + " : is UnChecked");
            }
        }

        /// <summary>
        /// Scroll to IWebElement
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="xPosition">X Position</param>
        /// <param name="yPosition">Y Position</param>
        public static void ScrollTo(IWebDriver _driver, int xPosition = 0, int yPosition = 0)
        {
            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            ((IJavaScriptExecutor)_driver).ExecuteScript(js);
        }

        /// <summary>
        /// Scroll To View IWebElement
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="element">IWebElement</param>
        public static void ScrollToView(IWebDriver _driver, IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(_driver, 0, element.Location.Y - 100); // Make sure element is in the view but below the top navigation pane
            }
        }

        /// <summary>
        /// Explicit Wait
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="_xpath">Xpath of the IWebElement</param>
        public static void ExplicitWait(IWebDriver _driver, string _xpath)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Web.FindElement(By.XPath(_xpath));
                return true;
            });
            wait.Until(waitForElement);
        }

        /// <summary>
        /// AutoIt File Upload
        /// </summary>
        /// <param name="FileName">File Name</param>
        /// <Pre Requisire>AutoIt must be installed in the current system </Pre>
        public static void AutoItUpload(IWebDriver driver, string FileName)
        {
            string _path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string _actualPath = _path.Substring(0, _path.LastIndexOf("bin"));
            string _projectPath = new Uri(_actualPath).LocalPath;
            string _UploadFolderPath = _projectPath + "Library\\UploadFiles\\";
            string fName = _UploadFolderPath + FileName;

            string _BrowserName = driver.GetType().FullName;
            string[] _name = _BrowserName.Split('.');
            string _FileUploadHeader = string.Empty;
            if (_name[2] == "IE")
            {
                _FileUploadHeader = "Choose File to Upload";
            }
            else if (_name[2] == "Firefox")
            {
                _FileUploadHeader = "File Upload";
            }
            else if (_name[2] == "Chrome")
            {
                _FileUploadHeader = "Open";
            }
            else if (_name[2] == "Edge")
            {
                _FileUploadHeader = "Open";
            }
            else
            {
                BaseMethods.InfoLogger("Invlaid Data Provided. Swithing to Default Data");
                _FileUploadHeader = "File Upload";
            }
            AutoIt.AutoItX.ControlFocus(_FileUploadHeader, "", "Edit1");
            AutoIt.AutoItX.ControlSetText(_FileUploadHeader, "", "Edit1", fName);
            AutoIt.AutoItX.ControlClick(_FileUploadHeader, "", "Button1");
        }
    }
}
