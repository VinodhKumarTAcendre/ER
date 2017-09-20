using eRecruit.Library.Log4Net;
using eRecruit.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using eRecruit.Library.Extent_Reports;
using System.Collections;
using eRecruit.Library.Excel;
using eRecruit.Library;
using System.Diagnostics;

namespace eRecruit.Pages
{
    public class _12_EmailTemplateCreationPage
    {
        static IWebDriver driver;
        public _12_EmailTemplateCreationPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        [FindsBy(How = How.XPath, Using = "(//button[@type='button'])[2]")]
        private IWebElement elebtncloseFeedBack { get; set; }
        public void CloseFeedBackPopup()
        {
            BaseMethods.ScrollToView(driver, elebtncloseFeedBack);
            elebtncloseFeedBack.Click();
            BaseMethods.InfoLogger("Clicked on 'Close FeedBack Popup' button ");
        }

        [FindsBy(How = How.Name, Using = "emailTypeID")]
        private IWebElement eleDdlCreateNewEmailTemplateType { get; set; }

        [FindsBy(How = How.Name, Using = "btn_Go")]
        private IWebElement eleBtnGo { get; set; }
        public void Go()
        {
            eleBtnGo.Click();
            BaseMethods.InfoLogger("Clicked On 'Go' Button");
        }

        // Email Template

        [FindsBy(How = How.Name, Using = "EmailTemplateName")]
        private IWebElement eleTxtTemplateName { get; set; }
        public void TxtTemplateName(string Value)
        {
            eleTxtTemplateName.Clear();
            eleTxtTemplateName.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Template Name' Text Field");
        }

        [FindsBy(How = How.Id, Using = "UseConfiguredEmail")]
        private IWebElement eleDdlReplyAddressType { get; set; }

        [FindsBy(How = How.Name, Using = "EmailSenderEmail")]
        private IWebElement eleTxtReplyTo { get; set; }
        public void TxtReplyTo(string Value)
        {
            eleTxtReplyTo.Clear();
            eleTxtReplyTo.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Reply To' Text Field");
        }

        [FindsBy(How = How.Name, Using = "EmailSubject")]
        private IWebElement eleTxtEmailSubject { get; set; }
        public void TxtEmailSubject(string Value)
        {
            eleTxtEmailSubject.Clear();
            eleTxtEmailSubject.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Email Subject' Text Field");
        }

        [FindsBy(How = How.Name, Using = "DisplayTemplateID")]
        private IWebElement eleDdlEmailDisplayTemplate { get; set; }

        [FindsBy(How = How.Id, Using = "EmailContent_ifr")]
        private IWebElement eleIframeEmailBody { get; set; }

        [FindsBy(How = How.Name, Using = "EmailAttachment")]
        private IWebElement eleBrowseEmailAttachment { get; set; }
        public void EmailAttachmentButton()
        {
            eleBrowseEmailAttachment.Click();
            BaseMethods.InfoLogger("Clicked on 'Browse' button to Upload Email 'Attachment'");
        }

        [FindsBy(How = How.Name, Using = "btn_Save_and_Review")]
        private IWebElement eleBtnSaveandReview { get; set; }
        public void SaveAndReview()
        {
            eleBtnSaveandReview.Click();
            BaseMethods.InfoLogger("Clicked on 'Save and Review' button");
        }

        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement eleBtnCancel { get; set; }
        public void Cancel()
        {
            eleBtnCancel.Click();
            BaseMethods.InfoLogger("Clicked on 'Cancel' button");
        }

        [FindsBy(How = How.Name, Using = "Finish")]
        private IWebElement eleBtnFinish { get; set; }
        public void Finish()
        {
            eleBtnFinish.Click();
            BaseMethods.InfoLogger("Clicked on 'Finish' button");
        }

        [FindsBy(How = How.Name, Using = "Edit")]
        private IWebElement eleBtnEdit { get; set; }
        public void Edit()
        {
            eleBtnEdit.Click();
            BaseMethods.InfoLogger("Clicked on 'Edit' button");
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleDivAlertMsg { get; set; }
        public string DivAlertMsg()
        {
            BaseMethods.ExplicitWait(driver, "//div[@class='alert alert-warning']");
            return eleDivAlertMsg.Text;
        }

        public void CreateEmailTemplate()
        {
            ArrayList list = ExcelData.GetData("EmailTemplatesData", "EmailTemplateCreation", "Execute", "Yes");
            int count = list.Count;
            count = count / 9;
            int j = 1;
            for (int i = 0; i < count; i++)
            {
                BaseMethods.InfoLogger("Email Template Creation Started");
                BaseMethods.DdlSelectByText(eleDdlCreateNewEmailTemplateType, list[j].ToString());
                Go();
                BaseMethods.SleepTimeOut(3000);
                TxtTemplateName(list[(j + 1)].ToString());
                if (list[(j + 2)].ToString() != "Null")
                    BaseMethods.DdlSelectByText(eleDdlReplyAddressType, list[(j + 2)].ToString());
                TxtReplyTo(list[(j + 3)].ToString());
                TxtEmailSubject(list[(j + 4)].ToString());
                BaseMethods.DdlSelectByText(eleDdlEmailDisplayTemplate, list[(j + 5)].ToString());
                BaseMethods.TinyMCEEditor(driver, eleIframeEmailBody, list[(j + 6)].ToString());
                BaseMethods.PageScrollDown(driver);
                EmailAttachmentButton();
                BaseMethods.AutoItUpload(driver, list[(j + 7)].ToString());
                BaseMethods.ExplicitWait(driver, "//div[@id='uploadingListDiv']/div/a");
                SaveAndReview();
                string ExpectedValue = "×\r\n>   Email configuration updated.   ";
                string ActualValue = DivAlertMsg();
                Assert.AreEqual(ExpectedValue, ActualValue);
                Finish();
                BaseMethods.SleepTimeOut(3000);
                IWebElement ele = driver.FindElement(By.XPath("//td[text()='" + list[(j + 1)].ToString() + "']"));
                if (ele.Displayed)
                    BaseMethods.InfoLogger("Email Template Verified");
                else
                    ExtentReport.test.Log(LogStatus.Warning,"Email Templare could not be Verified");
                j += 9;
            }
        }
    }
}


