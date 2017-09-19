using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using eRecruit.Library.Excel;
using NUnit.Framework;
using eRecruit.Library.Log4Net;
using eRecruit.Library.Extent_Reports;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using eRecruit.Library;

namespace eRecruit.Pages
{
    public class _06_UserDetailsFormPage
    {
        public static IWebDriver driver;
        public _06_UserDetailsFormPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        #region WebElements

        [FindsBy(How = How.Name, Using = "btn_Save")]
        private IWebElement eleBtnSave { get; set; }
        public void Save()
        {
            eleBtnSave.Click();
            BaseMethods.InfoLogger("Clicked on 'Save' button");
        }

        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement eleBtnCancel { get; set; }
        public void Cancel()
        {
            eleBtnCancel.Click();
            BaseMethods.InfoLogger("Clicked on 'Cancel' button");
        }

        [FindsBy(How = How.Name, Using = "btn_Delete")]
        private IWebElement eleBtnDelete { get; set; }
        public void Delete()
        {
            eleBtnDelete.Click();
            BaseMethods.InfoLogger("Clicked on 'Delete' button");
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleSuccessMsg { get; set; }
        public string GetAlertMessage()
        {
            string msg = eleSuccessMsg.Text;
            BaseMethods.InfoLogger("Div Alert Message is: " + msg);
            return msg;
        }

        [FindsBy(How = How.LinkText, Using = "Preview Form")]
        private IWebElement elePreviewForm { get; set; }

        [FindsBy(How = How.Id, Using = "Close")]
        private IWebElement eleClosePreviewForm { get; set; }

        [FindsBy(How = How.Id, Using = "QuestionLabel_ifr")]
        private IWebElement eleIfameQue { get; set; }        

        #endregion

        #region Methods
        public void AddLocalQuestion(string ConfigKey, string SheetName)
        {
            AddQuestiontoStepPage AQS = new AddQuestiontoStepPage(driver);
            AQS.AddQuestion(driver, 0, ConfigKey, SheetName, "1");
        }

        public void AddGlobalQuestion(string ConfigKey, string SheetName)
        {
            _04_SearchGlobalQuestionPage SGQ = new _04_SearchGlobalQuestionPage(driver);
            SGQ.AddGlobalQuestion(driver, 0, ConfigKey, SheetName, "1");
        }

        public void EditQuestion(string ConfigKey, string SheetName)
        {
            BaseMethods.InfoLogger("Editing added Questions from User Details Form");
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, "Execute", "Yes");
            int count = list.Count;
            count = count / 2;
            int j = 1;
            if (list[j].ToString() != "EnterQuestionName")
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        IWebElement ele = driver.FindElement(By.XPath("//strong[contains(text(),'" + list[j].ToString() + "')]/../../div[4]/span[1]/a"));
                        ele.Click();
                        BaseMethods.TinyMCEEditor(driver,eleIfameQue,"Editing Functionality Testing");
                        Save();
                        string EditExpectedSucessMsg = "×\r\n>   Question saved successfully.   ";
                        string EditActualSucessMsg = GetAlertMessage();
                        Assert.AreEqual(EditExpectedSucessMsg, EditActualSucessMsg);
                        ExcelData.UpdateData("UserDetailsFormData", "EditQuestions", "EditQuestionName", "EnterQuestionName", "EditQuestionName", list[j].ToString());
                    }
                    catch (NoSuchElementException)
                    {
                        ExtentReport.test.Log(LogStatus.Warning, list[j].ToString() + " : Question not found");
                    }
                    BaseMethods.Navigate_Back(driver);
                    BaseMethods.Navigate_Back(driver);
                }
            }
        }

        public void DeleteQuestion(string ConfigKey, string SheetName)
        {
            BaseMethods.InfoLogger("Deleting added Questions from User Details Form");
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, "Execute", "Yes");
            int count = list.Count;
            count = count / 2;
            int j = 1;
            if (list[j].ToString() != "EnterQuestionName")
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        string _QueText = driver.FindElement(By.XPath("//strong[contains(text(),'" + list[j].ToString() + "')]/../strong")).Text;
                        IWebElement ele = driver.FindElement(By.XPath("//strong[contains(text(),'" + list[j].ToString() + "')]/../../div[4]/span[2]/a"));
                        ele.Click();
                        Delete();
                        string DeleteExpectedSucessMsg = "×\r\n>   The form question '" + _QueText + "' was deleted successfully.   ";
                        string DeleteActualSucessMsg = GetAlertMessage();
                        Assert.AreEqual(DeleteExpectedSucessMsg, DeleteActualSucessMsg);
                        ExcelData.UpdateData("UserDetailsFormData", "DeleteQuestions", "SearchQuestion", "EnterQuestionName", "SearchQuestion", list[j].ToString());
                    }
                    catch (NoSuchElementException)
                    {
                        ExtentReport.test.Log(LogStatus.Warning, list[j].ToString() + " : Question not found");
                    }
                }
            }
        }

        public void PreviewUserDetailsForm()
        {
            elePreviewForm.Click();
            Logger.log.Info("Clicked on Preview Form Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Preview Form Button");
            string newTabHandle = driver.WindowHandles.Last();
            var newTab = driver.SwitchTo().Window(newTabHandle);
            Logger.log.Info("Switched to Preview Form Window");
            ExtentReport.test.Log(LogStatus.Info, "Switched to Preview Form Window");
            eleClosePreviewForm.Click();
            Logger.log.Info("Clicked on Close Button in Preview From");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Close Button in Preview From");
            driver.SwitchTo().Window(driver.WindowHandles.First());
            Logger.log.Info("Switched to Main Window");
            ExtentReport.test.Log(LogStatus.Info, "Switched to Main Window");
        }

        #endregion
    }
}


































/*   /// <summary>
   /// Add Local Question to Step
   /// </summary>
   /// <param name="_driver">IWebDriver</param> */
/*   public void AddQuestionToStep(IWebDriver _driver)
    {
        AddQuestiontoStepPage AQS = new AddQuestiontoStepPage(_driver);

        IList<IWebElement> eleList = QuestionEleList(_driver);
        for (int i = 0; i < eleList.Count; i++)
        {
            IWebElement ele = eleList[i];
            AQS.AddQuestion(_driver, i, "User Details Form Data", "AddQuestiontoStep", (i + 1).ToString());
        }
        BaseMethods.Page_Refresh(_driver);
    }

    /// <summary>
    ///  Add Global Question to Step Elements
    /// </summary>
    /// <param name="_driver">IWebDriver</param>
    /// <returns>List of IWebElements</returns>

    public IList<IWebElement> QuestionEleList(IWebDriver _driver)
    {
        IList<IWebElement> eleList = _driver.FindElements(By.XPath("//a[@class='addQuestion']"));
        return eleList;
    }

    public void AddGlobalQuestionToForm(IWebDriver _driver)
    {
        _04_SearchGlobalQuestionPage SGQ = new _04_SearchGlobalQuestionPage(_driver);

        IList<IWebElement> eleList = GlobalQuestionEleList(_driver);
        for (int i = 0; i < eleList.Count; i++)
        {
            IWebElement ele = eleList[i];
            SGQ.AddGlobalQuestion(_driver, i, "User Details Form Data", "AddGlobalQuestiontoStep", (i + 1).ToString());
        }
        BaseMethods.Page_Refresh(_driver);
    }

    public IList<IWebElement> GlobalQuestionEleList(IWebDriver _driver)
    {
        IList<IWebElement> eleList = _driver.FindElements(By.XPath("//a[@class='addGlobal']")); */
