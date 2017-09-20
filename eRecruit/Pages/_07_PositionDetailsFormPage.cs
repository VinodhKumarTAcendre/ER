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
    public class _07_PositionDetailsFormPage
    {
        public static IWebDriver _driver;

        public _07_PositionDetailsFormPage(IWebDriver driver)
        {
            PageFactory.InitElements(_driver, this);
            _driver = driver;
        }

        [FindsBy(How = How.Name, Using = "btn_Delete")]
        private IWebElement eleBtnDelete { get; set; }
        public void Delete()
        {
            eleBtnDelete.Click();
            BaseMethods.InfoLogger("Clicked on 'Delete' Button");
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleSuccessMsg { get; set; }
        public string GetAlertMessage()
        {
            string msg = eleSuccessMsg.Text;
            BaseMethods.InfoLogger("Div Alert Message is: " + msg);
            return msg;
        }

        #region Methods
        public void Edit_PositionDetailsForm()
        {
            #region Edit the Step
            try
            {
                IWebElement eleStepEdit = _driver.FindElement(By.XPath("(//div[@class='formStepHeader'])[2]/span[2]/a"));
                eleStepEdit.Click();
                BaseMethods.InfoLogger("Clicked on Step Edit Link");
                _05_FormTemplateCreationPage Ftc = new _05_FormTemplateCreationPage(_driver);
                Ftc.StepTitle("Edit_Step_Title_Auto");
                BaseMethods.TinyMCEEditor(_driver, Ftc.StepDescription(), "Entered Step Description");
                BaseMethods.PageScrollDown(_driver);
                Ftc.QuestionLabelWidth(_driver, "System Default");
                Ftc.SaveStepDetails();
                BaseMethods.InfoLogger("Clicked on Save button - After Edit");
                string Edit_ExpectedSucessMsg = "×\r\n>   Form Section configuration updated.   ";
                string Edit_ActualSucessMsg = GetAlertMessage();
                Assert.AreEqual(Edit_ExpectedSucessMsg, Edit_ActualSucessMsg);
                BaseMethods.InfoLogger("Step has been Edited");
            }
            catch (NoSuchElementException ex)
            {
                ExtentReport.test.Log(LogStatus.Fatal, "Failed to Edit the Step.");
                Logger.log.Info(ex.Message);
            }
            #endregion

            #region Edit the Added Question
            try
            {
                IWebElement EditQueEle = _driver.FindElement(By.XPath("(//div[@class='formStepArea'])[2]/ul/li[1]/div[4]/span[1]"));
                EditQueEle.Click();
                BaseMethods.InfoLogger("Clicked on Question Step Edit Link");
                AddQuestiontoStepPage AQS = new AddQuestiontoStepPage(_driver);
                BaseMethods.TinyMCEEditor(_driver, AQS.eletxtQuestion, "Edit Functionality Testing");
                BaseMethods.PageScrollDown(_driver);
                AQS.Save();
                BaseMethods.InfoLogger("Clicked on Question Save button - After Edit");
                string ExpectedMsg = "×\r\n>   Question saved successfully.   ";
                string ActualMsg = GetAlertMessage();
                BaseMethods.SoftAssertEqual(ExpectedMsg, ActualMsg);
                BaseMethods.InfoLogger("Question has been Successfully Edited");
                BaseMethods.Navigate_Back(_driver);
                BaseMethods.Navigate_Back(_driver);
            }
            catch (NoSuchElementException ex)
            {
                ExtentReport.test.Log(LogStatus.Fatal, "Failed to Edit the Added Question.");
                Logger.log.Info(ex.Message);
            }
            #endregion

            #region Delete the Added Question
            try
            {
                IWebElement DeleteQueEleText = _driver.FindElement(By.XPath("(//div[@class='formStepArea'])[2]/ul/li[1]/div[4]/span[2]/a"));
                string _DeleteQueText = DeleteQueEleText.Text;
                IWebElement DeleteQueEle = _driver.FindElement(By.XPath("//div[@class='formStepArea']/ul/li[1]/div[4]/span[2]"));
                DeleteQueEle.Click();
                BaseMethods.InfoLogger("Clicked on Question Step Delete Link");
                Delete();
                string DeleteExpectedMsg = "×\r\n>   The form question '" + _DeleteQueText + "' was deleted successfully.   ";
                string DeleteActualMsg = GetAlertMessage();
                BaseMethods.SoftAssertEqual(DeleteExpectedMsg, DeleteActualMsg);
                BaseMethods.InfoLogger("Question has been Successfully Deleted");
            }
            catch (NoSuchElementException ex)
            {
                ExtentReport.test.Log(LogStatus.Fatal, "Failed to Delete the Added Question.");
                Logger.log.Info(ex.Message);
            }
            #endregion

            #region Delete the Step
            try
            {
                IWebElement eleStepDelete = _driver.FindElement(By.XPath("(//div[@class='formStepHeader'])[2]/span[3]/span/a"));
                eleStepDelete.Click();
                BaseMethods.InfoLogger("Clicked on Step Delete Link");
                BaseMethods.SleepTimeOut(2000);
                Delete();
                string StepDeleteExpectedMsg = "×\r\n>   The form step was deleted successfully.   ";
                string StepDeleteActualMsg = GetAlertMessage();
                BaseMethods.SoftAssertEqual(StepDeleteExpectedMsg, StepDeleteActualMsg);
                BaseMethods.InfoLogger("Step has been Successfully Deleted");
            }
            catch (NoSuchElementException ex)
            {
                ExtentReport.test.Log(LogStatus.Fatal, "Failed to Delete the Step.");
                Logger.log.Info(ex.Message);
            }
            #endregion
        }
        #endregion
    }
}

     



        









       
    