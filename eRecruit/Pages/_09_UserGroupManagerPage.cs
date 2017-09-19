using eRecruit.Library;
using eRecruit.Library.Excel;
using eRecruit.Library.Extent_Reports;
using eRecruit.Library.Log4Net;
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
    public class _09_UserGroupManagerPage
    {
        public static IWebDriver driver;
        public _09_UserGroupManagerPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        #region WebElements
        [FindsBy(How = How.LinkText, Using = "Create User Group")]
        private IWebElement elelnkCreateUserGroup { get; set; }

        /// <summary>
        /// Clicks on User Group Manager Link
        /// </summary>
        public void CreateUserGroupLink()
        {
            elelnkCreateUserGroup.Click();
            BaseMethods.InfoLogger("Clicked on Create User Group link");
        }

        [FindsBy(How = How.Name, Using = "UserGroupStatusID")]
        private IWebElement eleDdlUserGroupStatus { get; set; }

        [FindsBy(How = How.Id, Using = "userGroupName")]
        private IWebElement eleTxtUserGroupName { get; set; }

        /// <summary>
        /// Sets User Group Name
        /// </summary>
        /// <param name="value">Value to be set</param>
        public void UserGroupName(string value)
        {
            eleTxtUserGroupName.Clear();
            eleTxtUserGroupName.SendKeys(value);
            BaseMethods.InfoLogger(value + " : Value entered in User Group Name Text Field");
        }

        [FindsBy(How = How.Id, Using = "description")]
        private IWebElement eleTxtDescription { get; set; }

        /// <summary>
        /// Sets Description
        /// </summary>
        /// <param name="value">Value to be set</param>
        public void UserGroupDescription(string value)
        {
            eleTxtDescription.Clear();
            eleTxtDescription.SendKeys(value);
            BaseMethods.InfoLogger(value + " : Value entered in Description Text Field");
        }

        [FindsBy(How = How.Id, Using = "DefaultBEEvent")]
        private IWebElement eleDdlDefaultBEEvent { get; set; }

        [FindsBy(How = How.Name, Using = "btn_Save")]
        private IWebElement eleBtnSave { get; set; }

        /// <summary>
        /// Clicks on Save Button
        /// </summary>
        public void Save()
        {
            eleBtnSave.Click();
            BaseMethods.InfoLogger("Clicked on Save Button");
        }

        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement eleBtnCancel { get; set; }

        /// <summary>
        /// Clicks on Cancel Button
        /// </summary>
        public void Cancel()
        {
            eleBtnCancel.Click();
            BaseMethods.InfoLogger("Clicked on Cancel Button");
        }

        // ****************  Available Users

        [FindsBy(How = How.Name, Using = "NotGroupMemberList")]
        private IWebElement eleDdlNotGroupMemberList { get; set; }

        [FindsBy(How = How.Name, Using = "GroupMemberList")]
        private IWebElement eleDdlGroupMemberList { get; set; }

        [FindsBy(How = How.Name, Using = "MTGBtn")]
        private IWebElement eleBtnAdd { get; set; }

        /// <summary>
        /// Clicks on Add Button
        /// </summary>
        public void Add()
        {
            eleBtnAdd.Click();
            BaseMethods.InfoLogger("Clicked on Add Button");
        }

        [FindsBy(How = How.Name, Using = "MFGBtn")]
        private IWebElement eleBtnRemove { get; set; }

        /// <summary>
        /// Clicks on Remove Button
        /// </summary>
        public void Remove()
        {
            eleBtnRemove.Click();
            BaseMethods.InfoLogger("Clicked on Remove Button");
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleDivAlertMsg { get; set; }

        /// <summary>
        /// Alert Message
        /// </summary>
        /// <returns>Message</returns>
        public string DivAlertMsg()
        {
            return eleDivAlertMsg.Text;
        }

        [FindsBy(How = How.LinkText, Using = "Manage User Group")]
        private IWebElement eleLinkManageUserGroup { get; set; }
        /// <summary>
        /// Click on Manage User Group Link
        /// </summary>
        public void LinkManageUserGroup()
        {
            eleLinkManageUserGroup.Click();
            BaseMethods.InfoLogger("Clicked on Manage User Group Link");
        }

        #endregion

        #region Methods
        public void CreateUserGroup(string ConfigKey, string SheetName)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, "Execute", "Yes");
            int count = list.Count;
            count = count / 5;
            int j = 1;
            for (int i = 1; i <= count; i++)
            {
                CreateUserGroupLink();
                UserGroupName(list[j].ToString());
                UserGroupDescription(list[(j + 1)].ToString());
                BaseMethods.DdlSelectByText(eleDdlDefaultBEEvent, list[(j + 2)].ToString());
                Save();
                string ExpectedResult = "×\r\n>   User Group configuration updated.    >   User Group members updated.   ";
                string ActualResult = DivAlertMsg();
                Assert.AreEqual(ExpectedResult, ActualResult);
                ModulePermissions mp = new ModulePermissions(driver);
                mp.SelectModulePermissions(driver, ConfigKey, "ModulePermissions", "RowNumber", list[(j + 3)].ToString(), "UserGroup");
                FunctionPermissions FP = new FunctionPermissions(driver);
                FP.SelectFunctionPermissions(driver, ConfigKey, "FunctionPermissions", "RowNumber", list[(j + 3)].ToString(), "UserGroup");
                JobPermissions jp = new JobPermissions(driver);
                jp.AddJobPermission(driver, ConfigKey, "JobPermissions", "RowNumber", list[(j + 3)].ToString(), "UserGroup");
                RequisitionPermissions rp = new RequisitionPermissions(driver);
                rp.AddRequisitionPermissions(driver, ConfigKey, "RequisitionPermission", "RowNumber", list[(j + 3)].ToString(), "UserGroup");
                AssignUserDefinedViews Audv = new AssignUserDefinedViews(driver);
                Audv.AddAssignUserDefinedViews(ConfigKey, "AssignUDV", "RowNumber", list[(j + 3)].ToString());
                ActivityBlockPermissions abp = new ActivityBlockPermissions(driver);
                abp.SelectABIPermissions(driver, ConfigKey, "ABIPermissions", "RowNumber", list[(j + 3)].ToString(), "UserGroup");
                RolePermissions rolep = new RolePermissions(driver);
                rolep.SelectRolePermissions(driver, ConfigKey, "RolePermissions", "RowNumber", list[(j + 3)].ToString());
                JobBoardAccountPermissions jbp = new JobBoardAccountPermissions(driver);
                jbp.SelectJobBoardAccountPermissions(driver, ConfigKey, "JobBoardAccountPermissions", "RowNumber", list[(j + 3)].ToString());
                SetDefaultTalentSearchTemplate Dtst = new SetDefaultTalentSearchTemplate(driver);
                Dtst.DefaultTalentSearchTemplate(ConfigKey, "DefaultTalentSearchTemplate", "RowNumber", list[(j + 3)].ToString(), "UserGroup");
                SetListDefaults Sld = new SetListDefaults(driver);
                Sld.SetListDefaultsTaskList(ConfigKey, "SetListDefaults", "RowNumber", list[(j + 3)].ToString());
                j += 5;
            }
        }
        #endregion

        #region WebElements

        [FindsBy(How = How.LinkText, Using = "Module Permissions")]
        private IWebElement elelnkModulePermissions { get; set; }

        /// <summary>
        /// Clicks on Module Permissions Link
        /// </summary>
        public void ModulePermissions()
        {
            elelnkModulePermissions.Click();
            BaseMethods.InfoLogger("Clicked on Module Permissions  link");
        }

        [FindsBy(How = How.LinkText, Using = "Function Permissions")]
        private IWebElement elelnkFunctionPermissions { get; set; }

        /// <summary>
        /// Clicks on Function Permissions Link
        /// </summary>
        public void FunctionPermissions()
        {
            elelnkFunctionPermissions.Click();
            BaseMethods.InfoLogger("Clicked on Function Permissions  link");
        }

        [FindsBy(How = How.LinkText, Using = "Job Permissions")]
        private IWebElement elelnkJobPermissions { get; set; }

        /// <summary>
        /// Clicks on Job Permissions Link
        /// </summary>
        public void JobPermissions()
        {
            elelnkJobPermissions.Click();
            BaseMethods.InfoLogger("Clicked on Job Permissions  link");
        }

        [FindsBy(How = How.LinkText, Using = "Requisition Permissions")]
        private IWebElement elelnkRequisitionPermissions { get; set; }

        /// <summary>
        /// Clicks on Requisition Permissions Link
        /// </summary>
        public void RequisitionPermissions()
        {
            elelnkRequisitionPermissions.Click();
            BaseMethods.InfoLogger("Clicked on Requisition Permissions  link");
        }

        [FindsBy(How = How.LinkText, Using = "Restrict Talent Search Results")]
        private IWebElement elelnkRestrictTalentSearchResults { get; set; }

        /// <summary>
        /// Clicks on Restrict Talent Search Results Link
        /// </summary>
        public void RestrictTalentSearchResults()
        {
            elelnkRestrictTalentSearchResults.Click();
            BaseMethods.InfoLogger("Clicked on Restrict Talent Search Results  link");
        }

        [FindsBy(How = How.LinkText, Using = "Assign User Defined Views")]
        private IWebElement elelnkAssignUserDefinedViews { get; set; }

        /// <summary>
        /// Clicks on Assign User Defined Views Link
        /// </summary>
        public void AssignUserDefinedViews()
        {
            elelnkAssignUserDefinedViews.Click();
            BaseMethods.InfoLogger("Clicked on Assign User Defined Views  link");
        }

        [FindsBy(How = How.LinkText, Using = "Activity Block Permissions")]
        private IWebElement elelnkActivityBlockPermissions { get; set; }

        /// <summary>
        /// Clicks on Activity Block Permissions Link
        /// </summary>
        public void ActivityBlockPermissions()
        {
            elelnkActivityBlockPermissions.Click();
            BaseMethods.InfoLogger("Clicked on Activity Block Permissions  link");
        }

        [FindsBy(How = How.LinkText, Using = "Role Permissions")]
        private IWebElement elelnkRolePermissions { get; set; }

        /// <summary>
        /// Clicks on Role Permissions Link
        /// </summary>
        public void RolePermissions()
        {
            elelnkRolePermissions.Click();
            BaseMethods.InfoLogger("Clicked on Role Permissions link");
        }

        [FindsBy(How = How.LinkText, Using = "Job Board Account Permissions")]
        private IWebElement elelnkJobBoardAccountPermissions { get; set; }

        /// <summary>
        /// Clicks on Job Board Account Permissions Link
        /// </summary>
        public void JobBoardAccountPermissions()
        {
            elelnkJobBoardAccountPermissions.Click();
            BaseMethods.InfoLogger("Clicked on Job Board Account Permissions link");
        }

        [FindsBy(How = How.LinkText, Using = "Delete User Group")]
        private IWebElement elelnkDeleteUserGroup { get; set; }

        /// <summary>
        /// Clicks on Delete User Group Link
        /// </summary>
        public void DeleteUserGroup()
        {
            elelnkDeleteUserGroup.Click();
            BaseMethods.InfoLogger("Clicked on Delete User Group link");
        }

        [FindsBy(How = How.LinkText, Using = "Set Default Talent Search Template")]
        private IWebElement elelnkSetDefaultTalentSearchTemplate { get; set; }

        /// <summary>
        /// Clicks on Set Default Talent Search Template Link
        /// </summary>
        public void SetDefaultTalentSearchTemplate()
        {
            elelnkSetDefaultTalentSearchTemplate.Click();
            BaseMethods.InfoLogger("Clicked on Set Default Talent Search Template link");
        }

        [FindsBy(How = How.LinkText, Using = "Set List Defaults")]
        private IWebElement elelnkSetListDefaults { get; set; }

        /// <summary>
        /// Clicks on Set List Defaults Link
        /// </summary>
        public void SetListDefaults()
        {
            elelnkSetListDefaults.Click();
            BaseMethods.InfoLogger("Clicked on Set List Defaults link");
        }

        #endregion

    }

    public class ModulePermissions : _09_UserGroupManagerPage
    {
        public ModulePermissions(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//input[@name='JOModuleID']")]
        private IList<IWebElement> eleChkModulePermissions { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add Module Permission to the User Group
        /// </summary>
        public void SelectModulePermissions(IWebDriver _driver, string ConfigKey, string SheetName, string ConditionKey, string Condition, string TestType)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            ModulePermissions();
            BaseMethods.InfoLogger("Selecting Module Permissions");
            string[] ValueList = list[1].ToString().Split(',');
            IList<IWebElement> _list = eleChkModulePermissions;
            for (int j = 0; j < ValueList.Length; j++)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    IWebElement ele = _driver.FindElement(By.XPath("(//input[@name='JOModuleID'])[ " + (i + 1) + "]/../div"));
                    string value = ele.Text;
                    if (ValueList[j].ToString() == value)
                    {
                        _list[i].Click();
                        BaseMethods.InfoLogger(value + " is Selected");
                        break;
                    }
                }
            }
            Save();
            if (TestType == "UserGroup")
            {
                string ModuleExpectedResult = "×\r\n>   User Group configuration updated.   ";
                string ModuleActualResult = DivAlertMsg();
                Assert.AreEqual(ModuleExpectedResult, ModuleActualResult);
            }
            else
            {
                string ModuleExpectedResult = "×\r\n>   User configuration updated.    >   An error occurred when syncing user details with Analytics RT service   ";
                string ModuleActualResult = DivAlertMsg();
                Assert.AreEqual(ModuleExpectedResult, ModuleActualResult);
            }
        }
        #endregion

    }

    public class FunctionPermissions : _09_UserGroupManagerPage
    {
        public FunctionPermissions(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//input[@name='TaskID']")]
        private IList<IWebElement> eleChkFunctionPermissions { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add Function Permission to the User Group
        /// </summary>
        public void SelectFunctionPermissions(IWebDriver _driver, string ConfigKey, string SheetName, string ConditionKey, string Condition, string TestType)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            FunctionPermissions();
            BaseMethods.InfoLogger("Selecting Function Permissions");
            string[] ValueList = list[1].ToString().Split(',');
            IList<IWebElement> _list = eleChkFunctionPermissions;
            for (int j = 0; j < ValueList.Length; j++)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    IWebElement ele = _driver.FindElement(By.XPath("(//input[@name='TaskID'])[" + (i + 1) + "]/../../div"));
                    string value = ele.Text;
                    if (ValueList[j].ToString() == value)
                    {
                        _list[i].Click();
                        BaseMethods.InfoLogger(value + " is Selected");
                        break;
                    }
                }
            }
            Save();
            if (TestType == "UserGroup")
            {
                string FunctionExpectedResult = "×\r\n>   User Group configuration updated.   ";
                string FunctionActualResult = DivAlertMsg();
                Assert.AreEqual(FunctionExpectedResult, FunctionActualResult);
            }
            else
            {
                string FunctionExpectedResult = "×\r\n>   User configuration updated.    >   An error occurred when syncing user details with Analytics RT service   ";
                string FunctionActualResult = DivAlertMsg();
                Assert.AreEqual(FunctionExpectedResult, FunctionActualResult);
            }
        }
        #endregion
    }

    public class JobPermissions : _09_UserGroupManagerPage
    {
        public JobPermissions(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.LinkText, Using = "Add Job Permission")]
        private IWebElement eleLnkAddJobPermission { get; set; }

        /// <summary>
        /// Click on Add Job Permission Link
        /// </summary>
        public void AddJobPermissionLink()
        {
            eleLnkAddJobPermission.Click();
            BaseMethods.InfoLogger("Clicked on Add Job Permission Link");
        }

        [FindsBy(How = How.Name, Using = "UserGroupIsSuper")]
        private IWebElement eleChkUserGroupIsSuper { get; set; }

        /// <summary>
        /// Selects the User Group Is Super CheckBox
        /// </summary>
        public void UserGroupIsSuper()
        {
            eleChkUserGroupIsSuper.Click();
            BaseMethods.InfoLogger("Selected User Group Is Super Checkbox ");
        }

        [FindsBy(How = How.Id, Using = "CandidateCardUDViewID")]
        private IWebElement eleDdlCandidateCardUDV { get; set; }

        [FindsBy(How = How.Name, Using = "JobPermissionType")]
        public IWebElement eleDdlJobPermissionType { get; set; }

        // Job Web Elements
        [FindsBy(How = How.Id, Using = "jobSelect")]
        private IWebElement eleDdlJobSelect { get; set; }

        [FindsBy(How = How.Id, Using = "jobGroupSelect")]
        private IWebElement eleDdlJobGroupSelect { get; set; }

        [FindsBy(How = How.Id, Using = "jobStatusSelect")]
        private IWebElement eleDdlJobStatusSelect { get; set; }

        [FindsBy(How = How.Name, Using = "isRestricted")]
        private IWebElement eleChkIsRestricted { get; set; }

        /// <summary>
        /// Selects the IsRestricted CheckBox
        /// </summary>
        public void IsRestricted()
        {
            eleChkIsRestricted.Click();
            BaseMethods.InfoLogger("Selected IsRestricted Checkbox ");
        }

        // Job Template
        [FindsBy(How = How.Id, Using = "jobTemplateselect")]
        public IWebElement eleDdlJobTemplate { get; set; }

        // AudienceType
        [FindsBy(How = How.Name, Using = "Audienceselect")]
        public IWebElement eleDdlAudienceType { get; set; }

        // User Job
        [FindsBy(How = How.XPath, Using = "//input[@class='cp_checkbox']")]
        private IList<IWebElement> eleChkUserJob { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Add Job Permission to the User Group
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// </summary>
        public void AddJobPermission(IWebDriver _driver, string ConfigKey, string SheetName, string ConditionKey, string Condition, string TestType)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            JobPermissions();
            BaseMethods.InfoLogger("Selecting Job Permissions");
            if (list[1].ToString() == "Yes")
            {
                UserGroupIsSuper();
            }
            else
            {
                AddJobPermissionLink();
                BaseMethods.DdlSelectByText(eleDdlCandidateCardUDV, list[3].ToString());
                BaseMethods.DdlSelectByText(eleDdlJobPermissionType, list[4].ToString());

                // *********  Job  ******************
                if (list[4].ToString() == "Job")
                {
                    BaseMethods.InfoLogger(list[4].ToString() + " is Selected as Job");
                    BaseMethods.DdlSelectByText(eleDdlJobSelect, list[5].ToString());
                    BaseMethods.InfoLogger(list[5].ToString() + " : Job Name");
                    string[] CandidateGroupsList = list[6].ToString().Split(',');
                    BaseMethods.CtrlKeyDown(_driver);
                    for (int j = 0; j < CandidateGroupsList.Length; j++)
                    {
                        BaseMethods.DdlSelectByText(eleDdlJobGroupSelect, CandidateGroupsList[j]);
                        BaseMethods.InfoLogger("Candidate Groups: " + CandidateGroupsList[j].ToString());
                    }
                    BaseMethods.CtrlKeyUp(_driver);
                    BaseMethods.CtrlKeyDown(_driver);
                    string[] CandidateStatusList = list[7].ToString().Split(',');
                    BaseMethods.CtrlKeyDown(_driver);
                    for (int j = 0; j < CandidateStatusList.Length; j++)
                    {
                        BaseMethods.DdlSelectByText(eleDdlJobStatusSelect, CandidateStatusList[j]);
                        BaseMethods.InfoLogger("Candidate Status: " + CandidateStatusList[j].ToString());
                    }
                    if (list[8].ToString() == "Yes")
                    {
                        eleChkIsRestricted.Click();
                        BaseMethods.InfoLogger("Restricted Acess checkbox is Selected");
                    }
                }
                // *********  JobTemplate  ******************
                else if (list[4].ToString() == "Job Template")
                {
                    BaseMethods.InfoLogger(list[4].ToString() + " is Selected as Job");
                    BaseMethods.DdlSelectByText(eleDdlJobTemplate, list[9].ToString());
                    if (list[8].ToString() == "Yes")
                    {
                        eleChkIsRestricted.Click();
                        BaseMethods.InfoLogger("Restricted Acess checkbox is Selected");
                    }
                }
                // *********  AudienceType  ******************
                else if (list[4].ToString() == "Audience Type")
                {
                    BaseMethods.InfoLogger(list[4].ToString() + " is Selected as Job");
                    BaseMethods.DdlSelectByText(eleDdlAudienceType, list[10].ToString());
                    if (list[8].ToString() == "Yes")
                    {
                        eleChkIsRestricted.Click();
                        BaseMethods.InfoLogger("Restricted Acess checkbox is Selected");
                    }
                }
                // *********  UserJob  ******************
                else if (list[4].ToString() == "User Job")
                {
                    BaseMethods.InfoLogger(list[4].ToString() + " is Selected as Job");
                    string[] ValueList = list[11].ToString().Split(',');
                    IList<IWebElement> _list = eleChkUserJob;
                    for (int j = 0; j < ValueList.Length; j++)
                    {
                        for (int i = 0; i < _list.Count; i++)
                        {
                            IWebElement ele = _driver.FindElement(By.XPath("(//input[@class='cp_checkbox'])[" + (i + 1) + "]/../label[" + (i + 1) + "]"));
                            string value = ele.Text;
                            if (ValueList[j] == value)
                            {
                                _list[i].Click();
                                BaseMethods.InfoLogger(value + " is Selected");
                                break;
                            }
                        }
                    }
                    if (list[8].ToString() == "Yes")
                    {
                        eleChkIsRestricted.Click();
                        BaseMethods.InfoLogger("Restricted Acess checkbox is Selected");
                    }
                }
                else
                {
                    ExtentReport.test.Log(LogStatus.Error, "Job Permissions Data is mismatched! Please Check the Data and Re-Run");
                }
                Save();
            }
            Save();
            if (TestType == "UserGroup")
            {
                string _JobExpectedResult = "×\r\n>   User Group configuration updated.   ";
                string _JobActualResult = DivAlertMsg();
                Assert.AreEqual(_JobExpectedResult, _JobActualResult);
            }
            else
            {
                string _JobExpectedResult = "×\r\n>   User configuration updated.   ";
                string _JobActualResult = DivAlertMsg();
                Assert.AreEqual(_JobExpectedResult, _JobActualResult);
            }
            LinkManageUserGroup();
        }
        #endregion
    }

    public class RequisitionPermissions : _09_UserGroupManagerPage
    {
        public RequisitionPermissions(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.LinkText, Using = "Add Requisition Permission")]
        private IWebElement eleLnkAddRequisitionPermission { get; set; }

        /// <summary>
        /// Click on Add Requisition Permission Link
        /// </summary>
        public void LinkAddRequisitionPermission()
        {
            eleLnkAddRequisitionPermission.Click();
            BaseMethods.InfoLogger("Clicked on Add Requisition Permission Link");
        }

        [FindsBy(How = How.Id, Using = "requisitionPermissionType")]
        private IWebElement eleDdlRequisitionPermissionType { get; set; }

        [FindsBy(How = How.Id, Using = "requisitionProcessSelect")]
        private IWebElement eleDdlRequisitionProcessSelect { get; set; }

        #endregion

        #region Methods
        public void AddRequisitionPermissions(IWebDriver _driver, string ConfigKey, string SheetName, string ConditionKey, string Condition, string TestType)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            RequisitionPermissions();
            BaseMethods.InfoLogger("Selecting Requisition Permissions");
            LinkAddRequisitionPermission();
            BaseMethods.DdlSelectByText(eleDdlRequisitionPermissionType, list[1].ToString());
            BaseMethods.InfoLogger(list[1].ToString() + " option is selected for Requisition Permission Type");

            if (list[1].ToString() == "Requisition")
            {
                BaseMethods.DdlSelectByText(eleDdlRequisitionProcessSelect, list[2].ToString());
                BaseMethods.InfoLogger(list[2].ToString() + " is selected as Requisition Template");
            }
            else if (list[1].ToString() == "Requisition Template")
            {
                BaseMethods.DdlSelectByText(eleDdlRequisitionProcessSelect, list[3].ToString());
                BaseMethods.InfoLogger(list[3].ToString() + " is selected as Requisition Template");
            }
            else
            {
                Logger.log.Info("Invalid Option Selected");
                ExtentReport.test.Log(LogStatus.Error, "Invalid Option is Provided");
            }
            Save();
            if (TestType == "UserGroup")
            {
                string RequisitionExpectedResult = "×\r\n>   User Group configuration updated.   ";
                string RequisitionActualResult = DivAlertMsg();
                Assert.AreEqual(RequisitionExpectedResult, RequisitionActualResult);
            }
            else
            {
                string RequisitionExpectedResult = "×\r\n>   User configuration updated.   ";
                string RequisitionActualResult = DivAlertMsg();
                Assert.AreEqual(RequisitionExpectedResult, RequisitionActualResult);
            }
            LinkManageUserGroup();
        }
        #endregion
    }

    public class RestrictTalentSearchResults : _09_UserGroupManagerPage
    {
        public RestrictTalentSearchResults(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.LinkText, Using = "Add Talent Search Restriction")]
        private IWebElement eleLnkAddTalentSearchRestriction { get; set; }

        /// <summary>
        /// Click on Add Talent Search Restriction Link
        /// </summary>
        public void AddTalentSearchRestriction()
        {
            eleLnkAddTalentSearchRestriction.Click();
            BaseMethods.InfoLogger("Clicked on Add Talent Search Restriction Link");
        }

        [FindsBy(How = How.Id, Using = "cboOperator")]
        private IWebElement eleDdlOperator { get; set; }

        [FindsBy(How = How.Id, Using = "cboRestrictionType")]
        private IWebElement eleDdlCriteriaforRestriction { get; set; }

        [FindsBy(How = How.Id, Using = "AudienceTypeID")]
        private IWebElement eleDdlAudienceType { get; set; }
        #endregion
    }

    public class AssignUserDefinedViews : _09_UserGroupManagerPage
    {
        public AssignUserDefinedViews(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "TalentCardUDViewID")]
        public IWebElement eleDdlTalentCardUDV { get; set; }

        [FindsBy(How = How.Id, Using = "HeaderUDViewID")]
        public IWebElement eleDdlHeaderUDV { get; set; }

        [FindsBy(How = How.Id, Using = "HomePageUDViewID")]
        public IWebElement eleDdlHomePageUDV { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add Assign User Defined Views 
        /// </summary>
        public void AddAssignUserDefinedViews(string ConfigKey, string SheetName, string ConditionKey, string Condition)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            AssignUserDefinedViews();
            BaseMethods.InfoLogger("Selecting Assign User Defined Views");
            if (list != null)
            {
                BaseMethods.DdlSelectByText(eleDdlTalentCardUDV, list[1].ToString());
                BaseMethods.InfoLogger("Talent Card UDV: " + list[1].ToString());
                BaseMethods.DdlSelectByText(eleDdlHeaderUDV, list[2].ToString());
                BaseMethods.InfoLogger("Header UDV: " + list[2].ToString());
                BaseMethods.DdlSelectByText(eleDdlHomePageUDV, list[3].ToString());
                BaseMethods.InfoLogger("Home Page UDV: " + list[3].ToString());
            }
            Save();
            string AudvExpectedResult = "×\r\n>   Assigned User Defined Views Updated.   ";
            string AudvActualResult = DivAlertMsg();
            Assert.AreEqual(AudvExpectedResult, AudvActualResult);
        }
        #endregion
    }

    public class ActivityBlockPermissions : _09_UserGroupManagerPage
    {
        public ActivityBlockPermissions(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//input[@name='ActivityBlockTypeID']")]
        private IList<IWebElement> eleChkABIPermissions { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Select Activity Blocker Permissions
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public void SelectABIPermissions(IWebDriver _driver, string ConfigKey, string SheetName, string ConditionKey, string Condition, string TestType)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            ActivityBlockPermissions();
            BaseMethods.InfoLogger("Selecting Activity Block Permissions");
            string[] ValueList = list[1].ToString().Split(',');
            if (list != null)
            {
                IList<IWebElement> _list = eleChkABIPermissions;
                for (int j = 0; j < ValueList.Length; j++)
                {
                    for (int i = 0; i < _list.Count; i++)
                    {
                        IWebElement ele = _driver.FindElement(By.XPath("(//input[@name='ActivityBlockTypeID'])[" + (i + 1) + "]/../div"));
                        string value = ele.Text;
                        if (ValueList[j].ToString() == value)
                        {
                            _list[i].Click();
                            BaseMethods.InfoLogger(value + " is Selected");
                            break;
                        }
                    }
                }
                Save();
                if (TestType == "UserGroup")
                {
                    string ABIPermissionsExpectedResult = "×\r\n>   User Group configuration updated.   ";
                    string ABIPermissionsActualResult = DivAlertMsg();
                    Assert.AreEqual(ABIPermissionsExpectedResult, ABIPermissionsActualResult);
                }
                else
                {
                    string ABIPermissionsExpectedResult = "×\r\n>   User configuration updated.   ";
                    string ABIPermissionsActualResult = DivAlertMsg();
                    Assert.AreEqual(ABIPermissionsExpectedResult, ABIPermissionsActualResult);
                }
            }
        }
        #endregion
    }

    public class RolePermissions : _09_UserGroupManagerPage
    {
        public RolePermissions(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//input[@name='RoleID']")]
        private IList<IWebElement> eleChkRoleID { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Select Role Permissions
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public void SelectRolePermissions(IWebDriver _driver, string ConfigKey, string SheetName, string ConditionKey, string Condition)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            RolePermissions();
            BaseMethods.InfoLogger("Selecting Role Permissions");
            string[] ValueList = list[1].ToString().Split(',');
            if (list != null)
            {
                IList<IWebElement> _list = eleChkRoleID;
                for (int j = 0; j < ValueList.Length; j++)
                {
                    for (int i = 0; i < _list.Count; i++)
                    {
                        IWebElement ele = _driver.FindElement(By.XPath("(//input[@name='RoleID'])[" + (i + 1) + "]/../label"));
                        string value = ele.Text;
                        if (ValueList[j].ToString() == value)
                        {
                            _list[i].Click();
                            BaseMethods.InfoLogger(value + " is Selected");
                            break;
                        }
                    }
                }
                Save();
                string RolePermissionsExpectedResult = "×\r\n>   Role permissions updated.   ";
                string RolePermissionsActualResult = DivAlertMsg();
                Assert.AreEqual(RolePermissionsExpectedResult, RolePermissionsActualResult);
            }
        }
        #endregion
    }

    public class JobBoardAccountPermissions : _09_UserGroupManagerPage
    {
        public JobBoardAccountPermissions(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//input[@name='JobBoardAccountID']")]
        private IList<IWebElement> eleChkRoleID { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Select Job Board Account Permissions
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public void SelectJobBoardAccountPermissions(IWebDriver _driver, string ConfigKey, string SheetName, string ConditionKey, string Condition)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            JobBoardAccountPermissions();
            BaseMethods.InfoLogger("Selecting Job Board Account Permissions");
            string[] ValueList = list[1].ToString().Split(',');
            if (list != null)
            {
                IList<IWebElement> _list = eleChkRoleID;
                for (int j = 0; j < ValueList.Length; j++)
                {
                    for (int i = 0; i < _list.Count; i++)
                    {
                        try
                        {
                            IWebElement ele = _driver.FindElement(By.XPath("(//input[@name='JobBoardAccountID'])[" + (i + 1) + "]/../label"));
                            string value = ele.Text;
                            if (ValueList[j].ToString() == value)
                            {
                                _list[i].Click();
                                BaseMethods.InfoLogger(value + " is Selected");
                                break;
                            }
                        }
                        catch (NoSuchElementException ex)
                        {
                            ExtentReport.test.Log(LogStatus.Warning, "No Elements present in Job Board Account Permissions");
                            Logger.log.Info("No Elements present in Job Board Account Permissions");
                            Logger.log.Info(ex.Message);
                        }
                    }
                }
            }
            Save();
            string JBAPermissionsExpectedResult = "×\r\n>   Job board account permissions updated.   ";
            string JBAPermissionsActualResult = DivAlertMsg();
            Assert.AreEqual(JBAPermissionsExpectedResult, JBAPermissionsActualResult);
        }
        #endregion
    }

    public class DeleteUserGroup : _09_UserGroupManagerPage
    {
        public DeleteUserGroup(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.Name, Using = "btn_Confirm_Delete_User_Group")]
        private IWebElement eleBtnConfirmDeleteUserGroup { get; set; }

        /// <summary>
        /// Clicks on Confirm Delete User Group
        /// </summary>
        public void ConfirmDeleteUserGroup()
        {
            eleBtnConfirmDeleteUserGroup.Click();
            BaseMethods.InfoLogger("Clicked on Delete User Group Button");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Search the User Group
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="UserGroupName">User Group Name</param>
        public void SearchToDeleteUserGruop(IWebDriver driver, string UserGroupName)
        {
            IList<IWebElement> list = driver.FindElements(By.XPath("//form[@id='formList']/div[2]/table/tbody[2]/tr"));
            BaseMethods.InfoLogger("Total Number of User Groups Available are: " + list.Count);
            for (int i = 1; i <= list.Count; i++)
            {
                IWebElement ele = driver.FindElement(By.XPath("//form[@id='formList']/div[2]/table/tbody[2]/tr[" + (i) + "]/td[1]"));
                if (ele.Text == UserGroupName)
                {
                    IWebElement del = driver.FindElement(By.XPath("//form[@id='formList']/div[2]/table/tbody[2]/tr[" + (i) + "]/td[4]/span[1]/a"));
                    del.Click();
                    BaseMethods.InfoLogger("Clicked on " + UserGroupName + "Group Edit link");
                    break;
                }
            }
        }

        /// <summary>
        /// Delete the UserGroups
        /// </summary>
        /// <param name="ConfigKey">Configuration Key</param>
        /// <param name="SheetName">Sheet Name</param>
        public void DeleteUserGroups(string ConfigKey, string SheetName)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName,"Execute","Yes");
            int count = list.Count;
            count = count / 2;
            int j = 1;
            for (int i = 0; i < count; i++)
            {
                SearchToDeleteUserGruop(driver, list[j].ToString());
                DeleteUserGroup();
                ConfirmDeleteUserGroup();
                string ExpectedResult = "×\r\n>   User Group deleted.   ";
                string ActualResult = DivAlertMsg();
                Assert.AreEqual(ExpectedResult, ActualResult);
                BaseMethods.InfoLogger(list[j].ToString() + " : User Group Delete Successfully");
                j += 2;
            }            
        }
        #endregion
    }

    public class SetDefaultTalentSearchTemplate : _09_UserGroupManagerPage
    {
        public SetDefaultTalentSearchTemplate(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.Name, Using = "TalentSearchID")]
        private IWebElement eleDdlTalentSearchID { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Select Default Talent Search Template
        /// </summary>
        public void DefaultTalentSearchTemplate(string ConfigKey, string SheetName, string ConditionKey, string Condition, string TestType)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            SetDefaultTalentSearchTemplate();
            BaseMethods.InfoLogger("Selecting Set Default Talent Search Template");
            if (list != null)
            {
                BaseMethods.DdlSelectByText(eleDdlTalentSearchID, list[1].ToString());
                BaseMethods.InfoLogger(list[1].ToString() + " is Selected as Default Talent Search Template");
            }
            Save();
            if (TestType == "UserGroup")
            {
                string DTSTExpectedResult = "×\r\n>   Default user group talent search template has been saved.   ";
                string DTSTPermissionsActualResult = DivAlertMsg();
                Assert.AreEqual(DTSTExpectedResult, DTSTPermissionsActualResult);
            }
            else
            {
                string DTSTExpectedResult = "×\r\n>   Default user talent search template has been saved.   ";
                string DTSTPermissionsActualResult = DivAlertMsg();
                Assert.AreEqual(DTSTExpectedResult, DTSTPermissionsActualResult);
            }
            LinkManageUserGroup();
        }
        #endregion
    }

    public class SetListDefaults : _09_UserGroupManagerPage
    {
        public SetListDefaults(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region WebElements
        [FindsBy(How = How.Name, Using = "statusFilter")]
        private IWebElement eleDdlTalentSearchID { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Select List Defaults
        /// </summary>
        public void SetListDefaultsTaskList(string ConfigKey, string SheetName, string ConditionKey, string Condition)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, ConditionKey, Condition);
            SetListDefaults();
            BaseMethods.InfoLogger("Selecting Set List Defaults");
            if (list != null)
            {
                BaseMethods.DdlSelectByText(eleDdlTalentSearchID, list[1].ToString());
                BaseMethods.InfoLogger(list[1].ToString() + " is Selected as Set List sDefaults");
            }
            Save();
        }
        #endregion
    }
}
