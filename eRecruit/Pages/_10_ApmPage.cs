
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
using eRecruit.Library;
using eRecruit.Library.Excel;
using System.Collections;

namespace eRecruit.Pages
{
    public class _10_ApmPage
    {
        static IWebDriver driver;

        public _10_ApmPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//a[text()=' Create Assessment Process Template']")]
        private IWebElement elelinkCreateAPM { get; set; }
        public void LinkCreateAPM()
        {
            elelinkCreateAPM.Click();
            BaseMethods.InfoLogger("Clicked on Create Assesment Process Link");
        }

        [FindsBy(How = How.Name, Using = "processName")]
        private IWebElement eleTxtProcessName { get; set; }

        public void ProcessName(string Value)
        {
            eleTxtProcessName.Clear();
            eleTxtProcessName.SendKeys(Value);
            BaseMethods.InfoLogger("Entered '" + Value + "' in the Process Name Text Field");
        }

        [FindsBy(How = How.Name, Using = "processJobID")]
        private IWebElement eleDdlJobTemplate { get; set; }

        [FindsBy(How = How.Name, Using = "processIsActive")]
        private IWebElement eleChkActive { get; set; }

        [FindsBy(How = How.Name, Using = "processUseScores")]
        public IWebElement eleChkUsesScores { get; set; }

        [FindsBy(How = How.Name, Using = "processDisplayDecimalPlaces")]
        private IWebElement eleTxtDecimalPlacesScore { get; set; }
        public void DecimalPlacesScore(string Value)
        {
            eleTxtDecimalPlacesScore.Clear();
            eleTxtDecimalPlacesScore.SendKeys(Value);
            BaseMethods.InfoLogger("Entered '" + Value + "' in the Decimal Places for Candidate Scores");
        }

        [FindsBy(How = How.Name, Using = "ProcessHasOOM")]
        public IWebElement eleChkOrderofMerit { get; set; }

        [FindsBy(How = How.Name, Using = "btn_Save")]
        private IWebElement elebtnSave { get; set; }
        public void Save()
        {
            BaseMethods.ScrollToView(driver, elebtnSave);
            elebtnSave.Click();
            BaseMethods.InfoLogger("Clicked on Save Button");
        }

        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement elebtnCancel { get; set; }
        public void Cancel()
        {
            elebtnCancel.Click();
            BaseMethods.InfoLogger("Clicked on Cancel Button");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()=' Create Assessment Step']")]
        private IWebElement elelnkCreateAssesmentStep { get; set; }
        public void LinkCreateAssesmentStep()
        {
            elelnkCreateAssesmentStep.Click();
            BaseMethods.InfoLogger("Clicked on Create Assessment Step Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()=' Create Approval Step']")]
        private IWebElement elelnkCreateApprovalStep { get; set; }
        public void LinkCreateApprovalStep()
        {
            elelnkCreateApprovalStep.Click();
            BaseMethods.InfoLogger("Clicked on Create Approval Step Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Assessment Process Template']")]
        private IWebElement elelnkAssessmentProcessTemplate { get; set; }
        public void LinkAssessmentProcessTemplate()
        {
            elelnkAssessmentProcessTemplate.Click();
            BaseMethods.InfoLogger("Clicked on Assessment Process Template Link");
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleDivAlertMsg { get; set; }
        public string DivAlertMsg()
        {
            return eleDivAlertMsg.Text;
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Manage Form']")]
        private IWebElement elelnkManageForm { get; set; }
        public void LinkManageForm()
        {
            elelnkManageForm.Click();
            BaseMethods.InfoLogger("Clicked on ManageForm Link");
        }


        // Create Assessment Step

        [FindsBy(How = How.Name, Using = "processStepName")]
        private IWebElement eletxtStepName { get; set; }
        public void TextStepName(string Value)
        {
            eletxtStepName.Clear();
            eletxtStepName.SendKeys(Value);
            BaseMethods.InfoLogger("Entered " + Value + " in the Step Name Text Field");
        }

        [FindsBy(How = How.Id, Using = "processStepTypeID")]
        private IWebElement eleddlStepType { get; set; }

        [FindsBy(How = How.Id, Using = "processStepAutoComplete")]
        public IWebElement eleChkAutoComplete { get; set; }

        [FindsBy(How = How.Id, Using = "stepFormSelect")]
        private IWebElement eleDdlForm { get; set; }

        [FindsBy(How = How.Id, Using = "processStepConcurrencyIndex")]
        public IWebElement eleChkTaskSequence { get; set; }

        [FindsBy(How = How.Name, Using = "processStepMandatory")]
        private IList<IWebElement> eleRadioMandatory { get; set; }
        public void Mandatory(string Value)
        {
            if (Value == "Step must be completed for candidate to pass through")
            {
                eleRadioMandatory[0].Click();
                BaseMethods.InfoLogger("Mandatory - 'Step must be completed for candidate to pass through' : is selected");
            }
            else if (Value == "Step may be skipped for candidate")
            {
                eleRadioMandatory[1].Click();
                BaseMethods.InfoLogger("Mandatory - 'Step may be skipped for candidate' : is selected");
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "Mandatory - Invalid Option is provided");
            }
        }

        [FindsBy(How = How.Id, Using = "displayStepDetailsInWorkflow")]
        private IWebElement eleChkAccessStepWorkflow { get; set; }
        public void AccessStepWorkFlowCheckBox()
        {
            eleChkAccessStepWorkflow.Click();
            BaseMethods.InfoLogger("Clicked on Access Step Workflow Checkbox");
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='PermissionsTabLabel']")]
        private IWebElement eleLinkPermissions { get; set; }
        public void PermissionsTab()
        {
            eleLinkPermissions.Click();
            BaseMethods.InfoLogger("Clicked on Permissions Tab");
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='useSetupTask']")]
        private IList<IWebElement> eleRadioPermissions { get; set; }
        public void PermissionsRadio(string Value)
        {
            if (Value == "Configure Now")
            {
                eleRadioPermissions[0].Click();
                BaseMethods.InfoLogger("Permissions: 'Configure Now' is selected");
            }
            else if (Value == "Configure immediately prior to step opening")
            {
                eleRadioPermissions[1].Click();
                BaseMethods.InfoLogger("Permissions: 'Configure immediately prior to step opening' is selected");
            }
            else if (Value == "Configure now, Roles setup immediately prior to step opening")
            {
                eleRadioPermissions[2].Click();
                BaseMethods.InfoLogger("Permissions: 'Configure now, Roles setup immediately prior to step opening' is selected");
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "Permissions - Invalid Option is provided");
            }
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='method']")]
        private IList<IWebElement> eleRadioAssessmentMethod { get; set; }
        public void AssessmentMethodRadio(string Value)
        {
            if (Value == "Single Assessor Per Candidate")
            {
                eleRadioAssessmentMethod[0].Click();
                BaseMethods.InfoLogger("Assessment Method: 'Single Assessor Per Candidate' is selected");
            }
            else if (Value == "Multiple Assessors Per Candidate" || Value == "Multiple Assessors Per Candidate:")
            {
                eleRadioAssessmentMethod[1].Click();
                BaseMethods.InfoLogger("Assessment Method: 'Multiple Assessors Per Candidate' is selected");
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "Assessment Method - Invalid Option is provided");
            }
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='apmTaskAccessViaList']")]
        private IList<IWebElement> eleRadioTaskAccess { get; set; }
        public void TaskAccessRadio(string Value)
        {

            if (Value == "Go to form from Task List")
            {
                BaseMethods.ScrollToView(driver, eleRadioTaskAccess[0]);
                eleRadioTaskAccess[0].Click();
                BaseMethods.InfoLogger("Task Access: 'Go to form from Task List' is selected");
            }
            else if (Value == "Select Candidates to assess from list")
            {
                BaseMethods.ScrollToView(driver, eleRadioTaskAccess[1]);
                eleRadioTaskAccess[1].Click();
                BaseMethods.InfoLogger("Task Access: 'Select Candidates to assess from list' is selected");
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "Task Access - Invalid Option is provided");
            }
        }

        //  Create Approval Step

        [FindsBy(How = How.Id, Using = "targetProcessStepID")]
        private IWebElement eleDdlTargetStep { get; set; }

        [FindsBy(How = How.Id, Using = "HeaderID")]
        private IWebElement eleDdlHeaderID { get; set; }

        [FindsBy(How = How.Name, Using = "ApprovalStepMode")]
        private IList<IWebElement> eleRadioApprovalMode { get; set; }
        public void ApprovalMode(string Value)
        {
            if (Value == "Drag and Drop")
            {
                eleRadioApprovalMode[0].Click();
                BaseMethods.InfoLogger("Approval Mode: 'Drag and Drop' is selected");
            }
            else if (Value == "Cut Off")
            {
                eleRadioApprovalMode[1].Click();
                BaseMethods.InfoLogger("Approval Mode: 'Cut Off' is selected");
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "Invalid option is provided for 'Approval Mode'");
            }
        }


        [FindsBy(How = How.Name, Using = "DisplayOnHoldStepStatus")]
        private IList<IWebElement> eleRadioOnHold { get; set; }
        public void OnHold(string Value)
        {
            if (Value == "Visible" && eleRadioOnHold[0].Displayed)
            {
                eleRadioOnHold[0].Click();
                BaseMethods.InfoLogger("On Hold: 'Visible' is selected");
            }
            else if (Value == " Hidden" || Value == "Hidden" && eleRadioOnHold[1].Displayed)
            {
                eleRadioOnHold[1].Click();
                BaseMethods.InfoLogger("On Hold: 'Hidden' is selected");
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "Invalid option is provided for 'On Hold'");
            }
        }

        [FindsBy(How = How.Name, Using = "processStepDisplayCriteriaScores")]
        private IList<IWebElement> eleRadioDisplayColumnTypes { get; set; }
        public void DisplayColumnTypes(string Value)
        {
            if (Value == "Step Totals")
            {
                eleRadioDisplayColumnTypes[0].Click();
                BaseMethods.InfoLogger("Display Column Types: 'Step Totals' is selected");
            }
            else if (Value == "Selection Criteria Averages")
            {
                eleRadioDisplayColumnTypes[1].Click();
                BaseMethods.InfoLogger("Display Column Types: 'Selection Criteria Averages' is selected");
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "Invalid option is provided for 'Display Column Types'");
            }
        }

        [FindsBy(How = How.Name, Using = "processStepDisplayCriteriaRangeLabel")]
        private IWebElement eleChkDisplayRangeLabels { get; set; }

        [FindsBy(How = How.Name, Using = "DisplayCandidateAssessmentForms")]
        private IList<IWebElement> eleRadioCandidateAF { get; set; }
        public void CandidateAssForms(string Value)
        {
            if (Value == "Visible")
            {
                eleRadioCandidateAF[0].Click();
                BaseMethods.InfoLogger("Candidate Assessment Forms: 'Visible' is selected");
            }
            else if (Value == " Hidden" || Value == "Hidden")
            {
                eleRadioCandidateAF[1].Click();
                BaseMethods.InfoLogger("Candidate Assessment Forms: 'Hidden' is selected");
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "Invalid option is provided for 'Candidate Assessment Forms'");
            }
        }

        [FindsBy(How = How.Name, Using = "DisplayScoreProcessStep")]
        private IList<IWebElement> eleChkStepstoInclude { get; set; }

        [FindsBy(How = How.Name, Using = "DisplayRecruiterFiles")]
        private IList<IWebElement> eleRadioRecruiterFiles { get; set; }
        public void RecruiterFiles(string Value)
        {
            if (Value == "Visible")
            {
                eleRadioRecruiterFiles[0].Click();
                BaseMethods.InfoLogger("Recruiter Files: 'Visible' is selected");
            }
            else if (Value == " Hidden" || Value == "Hidden")
            {
                eleRadioRecruiterFiles[1].Click();
                BaseMethods.InfoLogger("Recruiter Files: 'Hidden' is selected");
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "Invalid option is provided for 'Recruiter Files'");
            }
        }

        [FindsBy(How = How.Id, Using = "attachMergeDocument")]
        private IWebElement eleChkAttachMergeDocTemp { get; set; }

        [FindsBy(How = How.Name, Using = "mergeDocumentID")]
        private IWebElement eleDdlAttachMergeDocTemp { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='usersUsersDiv']/select")]
        public IWebElement eleDdlUsers { get; set; }

        // ***** Assessment Users WebElements and Methods

        [FindsBy(How = How.XPath, Using = "//input[@name='usersGrouping']")]
        private IList<IWebElement> eleChkAssessmentUsers { get; set; }

        [FindsBy(How = How.Id, Using = "TaskUsesPreAllocation")]
        public IWebElement eleChkTaskUsesPreAllocation { get; set; }

        [FindsBy(How = How.Id, Using = "sendTaskNotificationEmail")]
        public IWebElement eleChkSendTaskNotificationEmail { get; set; }

        [FindsBy(How = How.Name, Using = "EmailID")]
        public IWebElement eleChkEmailID { get; set; }

        public string AssessmentUsers(IWebDriver _driver, ArrayList list)
        {
            BaseMethods.PartialPageScrollDown(_driver);
            string _ActionsPerformed = string.Empty;
            if (list[4].ToString() != "Null")
            {
                BaseMethods.SelectCheckBox(eleChkAssessmentUsers[0], "Yes", "General");
                if (list[4].ToString() == "All Users with Permission to this Job")
                {
                    IWebElement ele = _driver.FindElement(By.XPath("//input[@id='allJobUsersCheck']"));
                    BaseMethods.SelectCheckBox(ele, "Yes", "All Users with Permission to this Job");
                    _ActionsPerformed += "General : All Users with Permission to this Job \n";
                }
                else
                {
                    IWebElement ele = _driver.FindElement(By.XPath("//input[@id='candidatePermissionChecked']"));
                    ele.Click();
                    return "General : All Task Candidates Selected";
                }
            }
            if (list[5].ToString() != "Null")
            {
                BaseMethods.PageScrollDown(_driver);
                BaseMethods.ScrollToView(_driver, eleChkAssessmentUsers[1]);
                eleChkAssessmentUsers[1].Click();
                string[] RolesList = list[5].ToString().Split(',');
                for (int j = 0; j < RolesList.Length; j++)
                {
                    string _xpath = string.Empty;
                    #region
                    switch (RolesList[j])
                    {
                        case "Hiring Manager":
                            _xpath = "//div[@id='usersRolesDiv']/input[1]";
                            break;
                        case "HRBP":
                            _xpath = "//div[@id='usersRolesDiv']/input[2]";
                            break;
                        case "Recruitment Specialist":
                            _xpath = "//div[@id='usersRolesDiv']/input[3]";
                            break;
                        case "Approving Manager":
                            _xpath = "//div[@id='usersRolesDiv']/input[4]";
                            break;
                        case "GM":
                            _xpath = "//div[@id='usersRolesDiv']/input[5]";
                            break;
                        case "Group Exec":
                            _xpath = "//div[@id='usersRolesDiv']/input[6]";
                            break;
                        case "CEO":
                            _xpath = "//div[@id='usersRolesDiv']/input[7]";
                            break;
                        case "GMIC":
                            _xpath = "//div[@id='usersRolesDiv']/input[8]";
                            break;
                        case "GMIT":
                            _xpath = "//div[@id='usersRolesDiv']/input[9]";
                            break;
                        default:
                            ExtentReport.test.Log(LogStatus.Error, "Provied Role: " + RolesList[j] + " is not found");
                            break;
                    }
                    #endregion

                    IWebElement ele = _driver.FindElement(By.XPath(_xpath));
                    BaseMethods.ScrollToView(_driver, ele);
                    ele.Click();
                    BaseMethods.InfoLogger(RolesList[j].ToString() + " is Selected");
                }
                _ActionsPerformed += "Roles \n ";
            }
            if (list[6].ToString() != "Null")
            {
                BaseMethods.PageScrollDown(_driver);
                BaseMethods.ScrollToView(_driver, eleChkAssessmentUsers[2]);
                eleChkAssessmentUsers[2].Click();
                // string[] UserGroupList = list[6].ToString().Split(',');

                // Randomely selecting first three groups due to Xpath issue
                for (int i = 1; i <= 3; i++)
                {
                    IWebElement ele = _driver.FindElement(By.XPath("//div[@id='usersUserGroupsDiv']/input[" + (i) + "]"));
                    ele.Click();
                }
                _ActionsPerformed += "User Groups \n ";
            }
            if (list[7].ToString() != "Null")
            {
                BaseMethods.SleepTimeOut(3000);
                BaseMethods.PageScrollDown(_driver);
                BaseMethods.PageScrollDown(_driver);
                BaseMethods.ScrollToView(_driver, eleChkAssessmentUsers[3]);
                eleChkAssessmentUsers[3].Click();
                string[] UserList = list[7].ToString().ToString().Split('_');
                BaseMethods.CtrlKeyDown(_driver);
                for (int k = 0; k < UserList.Length; k++)
                {
                    BaseMethods.DdlSelectByText(eleDdlUsers, UserList[k]);
                }
                BaseMethods.InfoLogger("Users: " + list[7].ToString() + " are Selected");
                _ActionsPerformed += "Users \n ";
            }
            return _ActionsPerformed;
        }

        #endregion

        #region Methods

        public void CreateAssessmentProcessTemplate(IWebDriver _driver, string ConfigKey, string SheetName, string CondKey, string CondValue)
        {
            LinkCreateAPM();
            ArrayList list = ExcelData.GetData(ConfigKey,SheetName,CondKey, CondValue);

            if (list != null && list.Count > 0)
            {
                ProcessName(list[1].ToString());
                BaseMethods.DdlSelectByText(eleDdlJobTemplate, list[2].ToString());
                BaseMethods.SelectCheckBox(eleChkActive, list[3].ToString(), "Active Check Box");
                BaseMethods.SelectCheckBox(eleChkUsesScores, list[4].ToString(), "Uses Score Check Box");
                DecimalPlacesScore(list[5].ToString());
                BaseMethods.SelectCheckBox(eleChkOrderofMerit, list[6].ToString(), "Order of Merit Check Box");
                Save();
                string ExpectedValue = "×\r\n>   Active process must have at least one step and rule.    >   Process configuration incomplete, process set to inactive.   ";
                string ActualValue = DivAlertMsg();
                Assert.AreEqual(ExpectedValue, ActualValue);
                CreateAssessmentStep(_driver);
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Fail, "'CreateAPTemplate' sheet does not have any data to execute");
            }
        }

        public void CreateAssessmentStep(IWebDriver _driver)
        {
            LinkCreateAssesmentStep();
            ArrayList list = ExcelData.GetData("AssessmentProcessTemplateData", "AssessmentStep", "Execute", "Yes");
            if (list != null && list.Count > 0)
            {
                int count = list.Count;
                count = count / 8;
                int j = 0;
                for (int i = 0; i < count; i++)
                {
                    TextStepName(list[(j + 1)].ToString());
                    BaseMethods.DdlSelectByText(eleddlStepType, list[(j + 2)].ToString());
                    if (list[2].ToString() == "Automatic Screening")
                    {
                        BaseMethods.SelectCheckBox(eleChkAutoComplete, list[(j + 3)].ToString(), "Auto Complete Check Box");
                        Save();
                        string ASExpectedValue = "×\r\n>   Process Step configuration updated.   ";
                        string ASActualValue = DivAlertMsg();
                        Assert.AreEqual(ASExpectedValue, ASActualValue);
                    }
                    else if (list[(j + 2)].ToString() == "Assessment Form")
                    {
                        BaseMethods.DdlSelectByText(eleDdlForm, list[(j + 4)].ToString());
                        BaseMethods.SelectCheckBox(eleChkTaskSequence, list[(j + 5)].ToString(), "Task Sequence Check Box");
                        Mandatory(list[(j + 6)].ToString());
                        BaseMethods.SelectCheckBox(eleChkAccessStepWorkflow, list[(j + 7)].ToString(), "Task Sequence Check Box");
                        Save();
                        string ExpectedValue = "×\r\n>   Process Step configuration updated.    >   You must now configure Permissions on the Permissions tab page. Default permission set to 'Configure Now', 'Single Assessor per Candidate' and 'All Users with Permission to Job'.   ";
                        string ActualValue = DivAlertMsg();
                        Assert.AreEqual(ExpectedValue, ActualValue);
                        ArrayList Permissionslist = ExcelData.GetData("AssessmentProcessTemplateData", "AssessmentStep_Permissions", "StepName", list[(j + 1)].ToString());
                        if (Permissionslist != null && Permissionslist.Count > 0)
                        {
                            PermissionsTab();
                            PermissionsRadio(Permissionslist[1].ToString());
                            BaseMethods.PartialPageScrollDown(_driver);
                            AssessmentMethodRadio(Permissionslist[2].ToString());
                            TaskAccessRadio(Permissionslist[3].ToString());
                            string _Assessment = AssessmentUsers(_driver, Permissionslist);
                            BaseMethods.InfoLogger("******" + _Assessment);
                            if (eleChkTaskUsesPreAllocation.Displayed)
                            {
                                BaseMethods.SelectCheckBox(eleChkTaskUsesPreAllocation, Permissionslist[8].ToString(), "Uses Pre-Allocation");
                            }
                            BaseMethods.SelectCheckBox(eleChkSendTaskNotificationEmail, Permissionslist[9].ToString(), "Send Task Notification Email");
                            if (Permissionslist[9].ToString() == "Yes")
                            {
                                BaseMethods.DdlSelectByText(eleChkEmailID, Permissionslist[10].ToString());
                            }
                            Save();
                            string PermissionsExpectedValue = "×\r\n>   Process Step configuration updated.   ";
                            string PermissionsActualValue = DivAlertMsg();
                            Assert.AreEqual(PermissionsExpectedValue, PermissionsActualValue);
                        }
                        else
                        {
                            ExtentReport.test.Log(LogStatus.Warning, "'AssessmentStep_Permissions' sheet does not have any data to execute");
                        }
                    }
                    else
                    {
                        ExtentReport.test.Log(LogStatus.Warning, "Invalid Option is provided for 'Step Type'");
                    }
                    LinkAssessmentProcessTemplate();
                }
                j += 8;
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "'AssessmentStep' sheet does not have any data to execute");
            }
            CreateApprovalStep(_driver);
        }

        public void CreateApprovalStep(IWebDriver _driver)
        {
            LinkCreateApprovalStep();
            ArrayList list = ExcelData.GetData("AssessmentProcessTemplateData", "ApprovalStep", "Execute", "Yes");
            if (list != null && list.Count > 0)
            {
                int count = list.Count;
                count = count / 15;
                int j = 0;
                #region Approval Step
                for (int i = 0; i < count; i++)
                {
                    TextStepName(list[(j + 1)].ToString());
                    BaseMethods.DdlSelectByText(eleddlStepType, list[(j + 2)].ToString());
                    BaseMethods.DdlSelectByText(eleDdlTargetStep, list[(j + 3)].ToString());
                    BaseMethods.DdlSelectByText(eleDdlForm, list[(j + 4)].ToString());
                    BaseMethods.DdlSelectByText(eleDdlHeaderID, list[(j + 5)].ToString());
                    ApprovalMode(list[(j + 6)].ToString());
                    if (list[(j + 6)].ToString() == "Drag and Drop")
                    {
                        OnHold(list[(j + 7)].ToString());
                    }
                    DisplayColumnTypes(list[(j + 8)].ToString());
                    if (list[(j + 8)].ToString() == "Selection Criteria Averages")
                    {
                        BaseMethods.SelectCheckBox(eleChkDisplayRangeLabels, list[(j + 9)].ToString(), "Display Range Labels Instead of Scores");
                    }

                    string[] slist = list[(j + 10)].ToString().Split(',');
                    for (int k = 0; k < eleRadioCandidateAF.Count; k++)
                    {
                        int b = 2;
                        for (int a = 0; a < slist.Length; a++)
                        {
                            IWebElement ele = _driver.FindElement(By.XPath("//input[@name='DisplayScoreProcessStep']/../label[ " + b + "]"));
                            string _temp = ele.Text;
                            if (_temp == slist[a].ToString())
                            {
                                ele.Click();
                            }
                        }
                        b += 2;
                    }

                    CandidateAssForms(list[(j + 11)].ToString());
                    RecruiterFiles(list[(j + 12)].ToString());
                    BaseMethods.SelectCheckBox(eleChkAttachMergeDocTemp, list[(j + 13)].ToString(), "Attach Merge Document Template");
                    BaseMethods.DdlSelectByText(eleDdlAttachMergeDocTemp, list[(j + 14)].ToString());
                    Save();
                    #region Permissions
                    ArrayList Permissionslist = ExcelData.GetData("AssessmentProcessTemplateData", "ApprovalStep_Permissions", "StepName", list[(j + 1)].ToString());
                    if (Permissionslist != null && Permissionslist.Count > 0)
                    {
                        PermissionsTab();
                        ArrayList _list = new ArrayList();
                        _list.Add("Null"); _list.Add("Null"); _list.Add("Null"); _list.Add("Null");
                        _list.Add(Permissionslist[1].ToString());
                        _list.Add(Permissionslist[2].ToString());
                        _list.Add(Permissionslist[3].ToString());
                        _list.Add(Permissionslist[4].ToString());
                        string _Assessment = AssessmentUsers(_driver, _list);
                        BaseMethods.InfoLogger("******" + _Assessment);
                        BaseMethods.SelectCheckBox(eleChkSendTaskNotificationEmail, Permissionslist[5].ToString(), "Send Task Notification Email");
                        if (Permissionslist[5].ToString() == "Yes")
                        {
                            BaseMethods.DdlSelectByText(eleChkEmailID, Permissionslist[6].ToString());
                        }
                    }
                    #endregion
                    j = j + 15;
                    LinkAssessmentProcessTemplate();
                    #endregion
                }
            }
            else
            {
                ExtentReport.test.Log(LogStatus.Warning, "'ApprovalStep' sheet does not have any data to execute");
            }
        }
        #endregion
    }
}