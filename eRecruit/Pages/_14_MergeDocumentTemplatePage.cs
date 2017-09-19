using eRecruit.Library;
using eRecruit.Library.Excel;
using eRecruit.Library.Extent_Reports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Pages
{
    public class _14_MergeDocumentTemplatePage
    {
        static IWebDriver driver;
        public _14_MergeDocumentTemplatePage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//a[text()=' Create Merge Document Template']")]
        private IWebElement eleLnkCreateMergeDocumentTemplate { get; set; }
        public void LinkCreateMergeDocumentTemplate()
        {
            eleLnkCreateMergeDocumentTemplate.Click();
            BaseMethods.InfoLogger("Clicked on 'Create Merge Document Template' Link ");
        }

        [FindsBy(How = How.Name, Using = "mergeDocumentName")]
        private IWebElement eleTxtName { get; set; }
        public void TxtMergeDocumentName(string Value)
        {
            eleTxtName.Clear();
            eleTxtName.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Merge Document Name' Text Field");
        }

        [FindsBy(How = How.Name, Using = "mergeDocumentFile")]
        private IWebElement eleUploadMergeDocumentFile { get; set; }
        public void UploadMergeDocumentFile()
        {
            eleUploadMergeDocumentFile.Click();
            BaseMethods.InfoLogger("Clicked on 'Browse' button");
        }

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

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleDivAlertMsg { get; set; }
        public string DivAlertMsg()
        {
            BaseMethods.ExplicitWait(driver, "//div[@class='alert alert-warning']");
            return eleDivAlertMsg.Text;
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Merge Document Template List']")]
        private IWebElement eleLnkMergeDocumentTemplateList { get; set; }
        public void LinkMergeDocumentTemplateList()
        {
            eleLnkMergeDocumentTemplateList.Click();
            BaseMethods.InfoLogger("Clicked on 'Merge Document Template List' link");
        }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        private IWebElement eleChkErrorDisplay { get; set; }
        
        #endregion

        #region Methods
        public void CreateMergeDocTemplate()
        {
            ArrayList list = ExcelData.GetData("MergeDocTemplatesData", "MergeDocTemplateCreation", "Execute", "Yes");
            int count = list.Count;
            count = count / 3;
            int j = 1;
            for (int i = 0; i < count; i++)
            {
                BaseMethods.InfoLogger("Merge Document Template Creation Started");
                TxtMergeDocumentName(list[j].ToString());
                UploadMergeDocumentFile();
                BaseMethods.AutoItUpload(list[(j+1)].ToString());
                Save();
                if (eleChkErrorDisplay.Displayed)
                {
                    BaseMethods.SelectCheckBox(eleChkErrorDisplay,"Yes", "Fixing Errors");
                    Save();
                    BaseMethods.SleepTimeOut(3000);
                    Save();
                }
                string ExpectedValue = "×\r\n>   Merge Document configuration updated.   ";
                string ActualValue = DivAlertMsg();
                Assert.AreEqual(ExpectedValue, ActualValue);
                LinkMergeDocumentTemplateList();
                IWebElement ele = driver.FindElement(By.XPath("//td[text()='" + list[j].ToString() + "']"));
                if (ele.Displayed)
                    BaseMethods.InfoLogger("Merge Document Template Verified");
                else
                    ExtentReport.test.Log(LogStatus.Warning, "Merge Document Templare could not be Verified");
                j += 3;
            }
        }
        #endregion
    }
}
