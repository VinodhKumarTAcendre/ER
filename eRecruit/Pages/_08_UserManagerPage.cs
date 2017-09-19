using eRecruit.Library;
using eRecruit.Library.Excel;
using eRecruit.Library.Extent_Reports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    public class _08_UserManagerPage
    {
        static IWebDriver driver;

        public _08_UserManagerPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        #region WebElements

        [FindsBy(How = How.LinkText, Using = "Create User")]
        private IWebElement eleLnkCreateUser { get; set; }

        public void LinkCreateUser()
        {
            eleLnkCreateUser.Click();
            BaseMethods.InfoLogger("Clicked on 'Create User' Link");
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement eleTxtUserName { get; set; }
        public void TxtUserName(string Value)
        {
            eleTxtUserName.Clear();
            eleTxtUserName.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Username' Text Field");
        }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement eleTxtPassword { get; set; }
        public void TxtPassword(string Value)
        {
            eleTxtPassword.Clear();
            eleTxtPassword.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Password' Text Field");
        }

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        private IWebElement eleTxtConfirmPassword { get; set; }
        public void TxtConfirmPassword(string Value)
        {
            eleTxtConfirmPassword.Clear();
            eleTxtConfirmPassword.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Confirm Password' Text Field");
        }

        [FindsBy(How = How.Id, Using = "UserStatusID")]
        private IWebElement eleDdlUserStatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='UserExpiryDate']")]
        private IWebElement eleDateExpiryDate { get; set; }

        [FindsBy(How = How.Name, Using = "passwordExpired")]
        private IWebElement eleRadioChangePasswordNextLogin { get; set; }

        [FindsBy(How = How.Id, Using = "userGroup")]
        private IWebElement eleDdlUserGroup { get; set; }

        [FindsBy(How = How.Id, Using = "RegionID")]
        private IWebElement eleDdlRegion { get; set; }

        [FindsBy(How = How.Id, Using = "languageID")]
        private IWebElement eleDdlLanguage { get; set; }

        [FindsBy(How = How.Id, Using = "TimezoneID")]
        private IWebElement eleDdlTimeZone { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Employee Number:']/../../div[2]/input")]
        private IWebElement eleTxtEmployeeNumber { get; set; }
        public void TxtEmployeeNumber(string Value)
        {
            eleTxtEmployeeNumber.Clear();
            eleTxtEmployeeNumber.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Employee Number' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Email address ']/../../div[2]/input")]
        private IWebElement eleTxtEmailAddress { get; set; }
        public void TxtEmailAddress(string Value)
        {
            eleTxtEmailAddress.Clear();
            eleTxtEmailAddress.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Email Address' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='First Name ']/../../div[2]/input")]
        private IWebElement eleTxtFirstName { get; set; }
        public void TxtFirstName(string Value)
        {
            eleTxtFirstName.Clear();
            eleTxtFirstName.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'First Name' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Last Name ']/../../div[2]/input")]
        private IWebElement eleTxtLastName { get; set; }
        public void TxtLastName(string Value)
        {
            eleTxtLastName.Clear();
            eleTxtLastName.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Last Name' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Position Number:']/../../div[2]/input")]
        private IWebElement eleTxtPositionNumber { get; set; }
        public void TxtPositionNumber(string Value)
        {
            eleTxtPositionNumber.Clear();
            eleTxtPositionNumber.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Position Number' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Position Title:']/../../div[2]/input")]
        private IWebElement eleTxtPositionTitle { get; set; }
        public void TxtPositionTitle(string Value)
        {
            eleTxtPositionTitle.Clear();
            eleTxtPositionTitle.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Position Title' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Reports to Position Number:']/../../div[2]/input")]
        private IWebElement eleTxtReportsPositionNumber { get; set; }
        public void TxtReportsPositionNumber(string Value)
        {
            eleTxtReportsPositionNumber.Clear();
            eleTxtReportsPositionNumber.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Reports to Position Number' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Reports to Title:']/../../div[2]/input")]
        private IWebElement eleTxtReportstoTitle { get; set; }
        public void TxtReportstoTitle(string Value)
        {
            eleTxtReportstoTitle.Clear();
            eleTxtReportstoTitle.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Reports to Title' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Reports to Name:']/../../div[2]/input")]
        private IWebElement eleTxtReportstoName { get; set; }
        public void TxtReportstoName(string Value)
        {
            eleTxtReportstoName.Clear();
            eleTxtReportstoName.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Reports to Name' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='DefaultBEEvent_chosen']/a")]
        private IWebElement eleDdlDHB { get; set; }
        public void DefaultBackendHomepage(string Value)
        {
            eleDdlDHB.Click();
            Actions action = new Actions(driver);
            try
            {
                IWebElement ele = driver.FindElement(By.XPath("//li[text()='" + Value + "']"));
                action.MoveToElement(ele).Perform();
                ele.Click();
                BaseMethods.InfoLogger(Value + ": selected as Default Backend Homepage");
            }
            catch (NoSuchElementException)
            {
                BaseMethods.InfoLogger("Default is selected as Default Backend Homepage due to No Such Element Exception");
            }
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

        // Search User

        [FindsBy(How = How.Name, Using = "Keywords")]
        private IWebElement eleTxtKeywords { get; set; }
        public void TxtKeywords(string Value)
        {
            eleTxtKeywords.Clear();
            eleTxtKeywords.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Keywords Search' Text Field");
        }

        [FindsBy(How = How.Name, Using = "btn_Search")]
        private IWebElement eleBtnSearch { get; set; }
        public void Search()
        {
            eleBtnSearch.Click();
            BaseMethods.InfoLogger("Clicked on 'Search' button");
        }

        [FindsBy(How = How.Name, Using = "UserStatusID")]
        private IWebElement eleDdlStatus { get; set; }

        // Edit

        [FindsBy(How = How.XPath, Using = "//a[text()='Change Username']")]
        private IWebElement eleLnkChangeUsername { get; set; }
        public void LinkChangeUsername()
        {
            eleLnkChangeUsername.Click();
            BaseMethods.InfoLogger("Clicked on 'Change Username' link");
        }

        [FindsBy(How = How.Id, Using = "newUsername")]
        private IWebElement eleTxtNewUsername { get; set; }
        public void TxtNewUsername(string Value)
        {
            eleTxtNewUsername.Clear();
            eleTxtNewUsername.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'New Username' Text Field");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='User List']")]
        private IWebElement eleLnkUserList { get; set; }
        public void LinkUserList()
        {
            eleLnkUserList.Click();
            BaseMethods.InfoLogger("Clicked on 'User List' link");
        }

        // Change Password

        [FindsBy(How = How.XPath, Using = "//a[text()='Change Password']")]
        private IWebElement eleLnkChangePassword { get; set; }
        public void LinkChangePassword()
        {
            eleLnkChangePassword.Click();
            BaseMethods.InfoLogger("Clicked on 'Change Password' link");
        }

        [FindsBy(How = How.Id, Using = "newPassword")]
        private IWebElement eleTxtNewPassword { get; set; }
        public void TxtNewPassword(string Value)
        {
            eleTxtNewPassword.Clear();
            eleTxtNewPassword.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'New Password' Text Field");
        }

        [FindsBy(How = How.Id, Using = "confirmNewPassword")]
        private IWebElement eleTxtConfirmNewPassword { get; set; }
        public void TxtConfirmNewPassword(string Value)
        {
            eleTxtConfirmNewPassword.Clear();
            eleTxtConfirmNewPassword.SendKeys(Value);
            BaseMethods.InfoLogger(Value + ": entered in 'Confirm New Password' Text Field");
        }

        // Send Email

        [FindsBy(How = How.XPath, Using = "//a[text()='Send Email']")]
        private IWebElement eleLnkSendEmail { get; set; }
        public void LinkSendEmail()
        {
            eleLnkSendEmail.Click();
            BaseMethods.InfoLogger("Clicked on 'SendEmail' link");
        }

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

        [FindsBy(How = How.XPath, Using = "//label[text()='Email Display Template']/../../div[2]/div/a")]
        private IWebElement eleDdlEmailDisplayTemplate { get; set; }
        public void EmailDisplayTemplate(string Value)
        {
            eleDdlEmailDisplayTemplate.Click();
            Actions action = new Actions(driver);
            try
            {
                IWebElement ele = driver.FindElement(By.XPath("//li[text()='" + Value + "']"));
                action.MoveToElement(ele).Perform();
                ele.Click();
                BaseMethods.InfoLogger(Value + ": selected as Email Display Template");
            }
            catch (NoSuchElementException)
            {
                BaseMethods.InfoLogger("Default Value is selected as Email Display Template due to No Such Element Exception");
            }
        }

        [FindsBy(How = How.Id, Using = "EmailContent_ifr")]
        private IWebElement eleIframeEmailBody { get; set; }

        [FindsBy(How = How.Id, Using = "EmailAttachment")]
        private IWebElement eleBtnEmailAttachment { get; set; }

        [FindsBy(How = How.Name, Using = "Get_Email_Template")]
        private IWebElement eleBtnGetEmailTemplate { get; set; }
        public void GetEmailTemplate()
        {
            eleBtnGetEmailTemplate.Click();
            BaseMethods.InfoLogger("Clicked on 'Get Email Template' button");
        }

        [FindsBy(How = How.Id, Using = "EmailTemplateID")]
        private IWebElement eleDdlEmailTemplate { get; set; }

        [FindsBy(How = How.Name, Using = "btn_Use_Template")]
        private IWebElement eleBtnUseTemplate { get; set; }
        public void UseTemplate()
        {
            eleBtnUseTemplate.Click();
            BaseMethods.InfoLogger("Clicked on 'Use Template Template' button");
        }

        [FindsBy(How = How.Name, Using = "btn___Preview__")]
        private IWebElement eleBtnPreview { get; set; }
        public void Preview()
        {
            eleBtnPreview.Click();
            BaseMethods.InfoLogger("Clicked on 'Preview' button");
        }

        [FindsBy(How = How.Name, Using = "btn___Send__")]
        private IWebElement eleBtnSend { get; set; }
        public void Send()
        {
            eleBtnSend.Click();
            BaseMethods.InfoLogger("Clicked on 'Send' button");
        }

        // Email Log

        [FindsBy(How = How.XPath, Using = "//a[text()='Email Log']")]
        private IWebElement eleLnkEmailLog { get; set; }
        public void LinkEmailLog()
        {
            eleLnkEmailLog.Click();
            BaseMethods.InfoLogger("Clicked on 'Email Log' link");
        }

        [FindsBy(How = How.Id, Using = "TB_iframeContent")]
        private IWebElement eleIframeEmailLog { get; set; }

        // Impersonate User

        [FindsBy(How = How.XPath, Using = "//a[text()='Impersonate User']")]
        private IWebElement eleLnkImpersonateUser { get; set; }
        public void LinkImpersonateUser()
        {
            eleLnkImpersonateUser.Click();
            BaseMethods.InfoLogger("Clicked on 'Impersonate User' link");
        }

        #endregion

        #region Methods

        public void CreateUser(string ConfigKey, string SheetName)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, "Execute", "Yes");
            int count = list.Count;
            count = count / 21;
            int j = 1;
            for (int i = 0; i < count; i++)
            {
                LinkCreateUser();
                TxtUserName(list[j].ToString());
                TxtPassword(list[(j + 1)].ToString());
                TxtConfirmPassword(list[(j + 1)].ToString());
                BaseMethods.DdlSelectByText(eleDdlUserStatus, list[(j + 2)].ToString());
                BaseMethods.ScrollToView(driver, eleDateExpiryDate);
                eleDateExpiryDate.Clear();
                eleDateExpiryDate.SendKeys(list[(j + 3)].ToString());
                BaseMethods.YesNoRadioButtons(driver, eleRadioChangePasswordNextLogin, list[(j + 4)].ToString());
                BaseMethods.DdlSelectByText(eleDdlUserGroup, list[(j + 5)].ToString());
                BaseMethods.DdlSelectByText(eleDdlRegion, list[(j + 6)].ToString());
                BaseMethods.DdlSelectByText(eleDdlLanguage, list[(j + 7)].ToString());
                BaseMethods.DdlSelectByText(eleDdlTimeZone, list[(j + 8)].ToString());
                if (list[(j + 9)].ToString() != "Null")
                    TxtEmployeeNumber(list[(j + 9)].ToString());
                TxtEmailAddress(list[(j + 10)].ToString());
                TxtFirstName(list[(j + 11)].ToString());
                TxtLastName(list[(j + 12)].ToString());
                if (list[(j + 13)].ToString() != "Null")
                    TxtPositionNumber(list[(j + 13)].ToString());
                if (list[(j + 14)].ToString() != "Null")
                    TxtPositionTitle(list[(j + 14)].ToString());
                if (list[(j + 15)].ToString() != "Null")
                    TxtReportsPositionNumber(list[(j + 15)].ToString());
                if (list[(j + 16)].ToString() != "Null")
                    TxtReportstoTitle(list[(j + 16)].ToString());
                if (list[(j + 17)].ToString() != "Null")
                    TxtReportstoName(list[(j + 17)].ToString());
                DefaultBackendHomepage(list[(j + 18)].ToString());
                Save();
                string ExpectedValue = "×\r\n>   User configuration updated.    >   User Details saved successfully    ";
                string ActualValue = DivAlertMsg();
                BaseMethods.SoftAssertEqual(ExpectedValue, ActualValue);
                ModulePermissions mp = new ModulePermissions(driver);
                mp.SelectModulePermissions(driver, ConfigKey, "ModulePermissions", "RowNumber", list[(j + 19)].ToString(), "User");
                FunctionPermissions FP = new FunctionPermissions(driver);
                FP.SelectFunctionPermissions(driver, ConfigKey, "FunctionPermissions", "RowNumber", list[(j + 19)].ToString(), "User");
                JobPermissions jp = new JobPermissions(driver);
                jp.AddJobPermission(driver, ConfigKey, "JobPermissions", "RowNumber", list[(j + 19)].ToString(), "User");
                RequisitionPermissions rp = new RequisitionPermissions(driver);
                rp.AddRequisitionPermissions(driver, ConfigKey, "RequisitionPermission", "RowNumber", list[(j + 19)].ToString(), "User");
                AssignUserDefinedViews Audv = new AssignUserDefinedViews(driver);
                Audv.AddAssignUserDefinedViews(ConfigKey, "AssignUDV", "RowNumber", list[(j + 19)].ToString());
                ActivityBlockPermissions abp = new ActivityBlockPermissions(driver);
                abp.SelectABIPermissions(driver, ConfigKey, "ABIPermissions", "RowNumber", list[(j + 19)].ToString(), "User");
                RolePermissions rolep = new RolePermissions(driver);
                rolep.SelectRolePermissions(driver, ConfigKey, "RolePermissions", "RowNumber", list[(j + 19)].ToString());
                JobBoardAccountPermissions jbp = new JobBoardAccountPermissions(driver);
                jbp.SelectJobBoardAccountPermissions(driver, ConfigKey, "JobBoardAccountPermissions", "RowNumber", list[(j + 19)].ToString());
                SetDefaultTalentSearchTemplate Dtst = new SetDefaultTalentSearchTemplate(driver);
                Dtst.DefaultTalentSearchTemplate(ConfigKey, "DefaultTalentSearchTemplate", "RowNumber", list[(j + 19)].ToString(), "User");
                SetListDefaults Sld = new SetListDefaults(driver);
                Sld.SetListDefaultsTaskList(ConfigKey, "SetListDefaults", "RowNumber", list[(j + 19)].ToString());
                j += 21;
            }
        }

        public void ChangeUsername(string ConfigKey, string SheetName)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, "Execute", "Yes");
            int count = list.Count;
            count = count / 5;
            int j = 1;
            for (int i = 0; i < count; i++)
            {
                BaseMethods.InfoLogger("Searching for the User:");
                TxtKeywords(list[(j + 1)].ToString());
                Search();
                BaseMethods.DdlSelectByText(eleDdlStatus, list[j].ToString());
                try
                {
                    IWebElement eleUser = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]"));
                    IWebElement eleUGr = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[2]"));
                    string _UserGroup = eleUGr.Text;
                    if (_UserGroup == list[(j + 2)].ToString())
                    {
                        IWebElement _edit = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[6]/span/a"));
                        _edit.Click();
                        BaseMethods.InfoLogger("Clicked on 'Edit' link");
                        LinkChangeUsername();
                        TxtNewUsername(list[(j + 3)].ToString());
                        Save();
                        string ExpectedResult = "×\r\n>   The username was successfully updated.   ";
                        string ActualResult = DivAlertMsg();
                        Assert.AreEqual(ExpectedResult, ActualResult);
                        BaseMethods.InfoLogger("User Name: " + list[(j + 1)].ToString() + " is changed to " + list[(j + 3)].ToString());
                        LinkUserList();
                        j += 5;
                    }
                }
                catch (NoSuchElementException)
                {
                    ExtentReport.test.Log(LogStatus.Error, list[j].ToString() + ": user not Found");
                }
            }
        }

        public void ChangePassword(string ConfigKey, string SheetName)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, "Execute", "Yes");
            int count = list.Count;
            count = count / 5;
            int j = 1;
            for (int i = 0; i < count; i++)
            {
                BaseMethods.InfoLogger("Searching for the User:");
                TxtKeywords(list[(j + 1)].ToString());
                Search();
                BaseMethods.DdlSelectByText(eleDdlStatus, list[j].ToString());
                try
                {
                    IWebElement eleUser = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]"));
                    IWebElement eleUGr = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[2]"));
                    string _UserGroup = eleUGr.Text;
                    if (_UserGroup == list[(j + 2)].ToString())
                    {
                        IWebElement _edit = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[6]/span/a"));
                        _edit.Click();
                        BaseMethods.InfoLogger("Clicked on 'Edit' link");
                        LinkChangePassword();
                        TxtNewPassword(list[(j + 3)].ToString());
                        TxtConfirmNewPassword(list[(j + 3)].ToString());
                        Save();
                        string ExpectedResult = "×\r\n>   The password was successfully updated.   ";
                        string ActualResult = DivAlertMsg();
                        Assert.AreEqual(ExpectedResult, ActualResult);
                        LinkUserList();
                        j += 5;
                    }
                }
                catch (NoSuchElementException)
                {
                    ExtentReport.test.Log(LogStatus.Error, list[j].ToString() + ": user not Found");
                }
            }
        }

        public void SendEmail(string ConfigKey, string SheetName)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, "Execute", "Yes");
            int count = list.Count;
            count = count / 8;
            int j = 1;
            for (int i = 0; i < count; i++)
            {
                BaseMethods.InfoLogger("Searching for the User:");
                TxtKeywords(list[(j + 1)].ToString());
                Search();
                BaseMethods.DdlSelectByText(eleDdlStatus, list[j].ToString());
                try
                {
                    IWebElement eleUser = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]"));
                    IWebElement eleUGr = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[2]"));
                    string _UserGroup = eleUGr.Text;
                    if (_UserGroup == list[(j + 2)].ToString())
                    {
                        IWebElement _edit = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[6]/span/a"));
                        _edit.Click();
                        BaseMethods.InfoLogger("Clicked on 'Edit' link");
                        LinkSendEmail();
                        if (list[(j + 3)].ToString() == "Yes")
                        {
                            GetEmailTemplate();
                            BaseMethods.DdlSelectByText(eleDdlEmailTemplate, list[(j + 4)].ToString());
                            BaseMethods.SleepTimeOut(2000);
                            UseTemplate();
                            BaseMethods.SleepTimeOut(2000);
                            Preview();
                            Send();
                        }
                        else
                        {
                            TxtReplyTo(list[(j + 5)].ToString());
                            TxtEmailSubject(list[(j + 6)].ToString());
                            EmailDisplayTemplate(list[(j + 7)].ToString());
                            BaseMethods.TinyMCEEditor(driver, eleIframeEmailBody, list[(j + 8)].ToString());
                            eleBtnEmailAttachment.Click();
                            BaseMethods.AutoItUpload(list[(j + 9)].ToString());
                            Preview();
                            Send();
                        }
                        string ExpectedResult = "×\r\n>   The email has been sent   ";
                        string ActualResult = DivAlertMsg();
                        Assert.AreEqual(ExpectedResult, ActualResult);

                        // Verify Email

                        LinkEmailLog();
                        IWebElement eleSub = driver.FindElement(By.XPath("//td[text()='"+ list[(j + 6)].ToString() + "']"));
                        IWebElement eleView = driver.FindElement(By.XPath("//td[text()='" + list[(j + 6)].ToString() + "']/../td[5]/a"));
                        eleView.Click();
                        driver.SwitchTo().Frame(eleIframeEmailLog);
                        IWebElement SubText = driver.FindElement(By.XPath("//div[@id='main-content']//label[text()='Subject :']/..//div"));
                        string SubjectText = SubText.Text;
                        BaseMethods.SoftAssertEqual(SubjectText, list[(j + 6)].ToString());
                        IWebElement EleContentText = driver.FindElement(By.XPath("//div[@id='main-content']//label[text()='Content :']/../div[1]"));
                        string ContentText = EleContentText.Text;
                        BaseMethods.SoftAssertEqual(ContentText, list[(j + 8)].ToString());
                        IWebElement EleClose = driver.FindElement(By.XPath("//a[@id='TB_closeWindowButton']/span"));
                        EleClose.Click();
                        driver.SwitchTo().ParentFrame();
                        LinkUserList();
                        j += 8;
                    }
                }
                catch (NoSuchElementException)
                {
                    ExtentReport.test.Log(LogStatus.Error, list[j].ToString() + ": user not Found");
                }
            }
        }

        public void ChangeUserStatus(string ConfigKey, string SheetName)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, "Execute", "Yes");
            int count = list.Count;
            count = count / 5;
            int j = 1;
            for (int i = 0; i < count; i++)
            {
                BaseMethods.InfoLogger("Searching for the User:");
                TxtKeywords(list[(j + 1)].ToString());
                Search();
                BaseMethods.DdlSelectByText(eleDdlStatus, list[j].ToString());
                try
                {
                    IWebElement eleUser = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]"));
                    IWebElement eleUGr = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[2]"));
                    string _UserGroup = eleUGr.Text;
                    if (_UserGroup == list[(j + 2)].ToString())
                    {
                        IWebElement _edit = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[6]/span/a"));
                        _edit.Click();
                        BaseMethods.InfoLogger("Clicked on 'Edit' link");
                        BaseMethods.DdlSelectByText(eleDdlUserStatus, list[(j + 3)].ToString());
                        Save();
                        LinkUserList();
                        j += 5;
                    }
                }
                catch (NoSuchElementException)
                {
                    ExtentReport.test.Log(LogStatus.Error, list[j].ToString() + ": user not Found");
                }
            }
        }

        public void ImpersonateUser(string ConfigKey, string SheetName)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, "Execute", "Yes");
            int count = list.Count;
            count = count / 4;
            int j = 1;
            for (int i = 0; i < count; i++)
            {
                BaseMethods.InfoLogger("Searching for the User:");
                TxtKeywords(list[(j + 1)].ToString());
                Search();
                BaseMethods.DdlSelectByText(eleDdlStatus, list[j].ToString());
                try
                {
                    IWebElement eleUser = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]"));
                    IWebElement eleUGr = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[2]"));
                    string _UserGroup = eleUGr.Text;
                    if (_UserGroup == list[(j + 2)].ToString())
                    {
                        IWebElement _edit = driver.FindElement(By.XPath("//td[contains(text(),'" + list[(j + 1)].ToString() + "')]/../td[6]/span/a"));
                        _edit.Click();
                        BaseMethods.InfoLogger("Clicked on 'Edit' link");
                        LinkImpersonateUser();
                        driver.SwitchTo().Frame(eleIframeEmailLog);
                        driver.FindElement(By.Name("btn_Proceed")).Click();
                        driver.SwitchTo().ParentFrame();
                        driver.FindElement(By.XPath("//a[@id='lnkImpersonation']")).Click();
                        driver.SwitchTo().Frame(eleIframeEmailLog);
                        driver.FindElement(By.Name("btn_Proceed")).Click();
                        j += 5;
                    }
                }
                catch (NoSuchElementException)
                {
                    ExtentReport.test.Log(LogStatus.Error, list[j].ToString() + ": user not Found");
                }
            }
        }
        #endregion
    }
}
