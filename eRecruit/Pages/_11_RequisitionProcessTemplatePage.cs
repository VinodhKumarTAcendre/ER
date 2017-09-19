using eRecruit.Library;
using eRecruit.Library.Excel;
using eRecruit.Library.Extent_Reports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Pages
{
    public class _11_RequisitionProcessTemplatePage
    {
        static IWebDriver driver;

        public _11_RequisitionProcessTemplatePage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//a[text()=' Create Requisition Process Template']")]
        private IWebElement elelinkCreateRequisitionProcessTemplate { get; set; }
        public void LinkCreateRequisitionProcessTemplate()
        {
            elelinkCreateRequisitionProcessTemplate.Click();
            BaseMethods.InfoLogger("Clicked on Create Requisition Process Template Link");
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Requisition Process Template']")]
        private IWebElement elelinkRequisitionProcessTemplate { get; set; }
        public void LinkRequisitionProcessTemplate()
        {
            elelinkRequisitionProcessTemplate.Click();
            BaseMethods.InfoLogger("Clicked on Requisition Process Template Link");
        }

        [FindsBy(How = How.Name, Using = "processName")]
        private IWebElement eleTxtProcessName { get; set; }
        public void TxtProcessName(string Value)
        {
            eleTxtProcessName.Clear();
            eleTxtProcessName.SendKeys(Value);
            BaseMethods.InfoLogger("Entered '" + Value + "' in the Process Name Text Field");
        }

        [FindsBy(How = How.Name, Using = "processJobID")]
        private IWebElement eleDdlProcessJobId { get; set; }

        [FindsBy(How = How.Name, Using = "processIsActive")]
        private IWebElement eleChkProcessIsActive { get; set; }

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

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleDivAlertMsg { get; set; }
        public string DivAlertMsg()
        {
            BaseMethods.ExplicitWait(driver, "//div[@class='alert alert-warning']");
            return eleDivAlertMsg.Text;
        }

        // Create Step
        [FindsBy(How = How.XPath, Using = "//a[text()=' Create Step']")]
        private IWebElement eleLnkCreateStep { get; set; }
        public void LinkCreateStep()
        {
            eleLnkCreateStep.Click();
            BaseMethods.InfoLogger("Clicked on Create Step Link");
        }

        [FindsBy(How = How.Name, Using = "processStepName")]
        private IWebElement eleTxtProcessStepName { get; set; }
        public void TxtProcessStepName(string Value)
        {
            eleTxtProcessStepName.Clear();
            eleTxtProcessStepName.SendKeys(Value);
            BaseMethods.InfoLogger("Entered '" + Value + "' in the Process Step Name Text Field");
        }

        [FindsBy(How = How.Name, Using = "processStepTypeID")]
        private IWebElement eleDdlProcessStepTypeID { get; set; }

        // *******   Requisition Form

        [FindsBy(How = How.Id, Using = "ProcessStepContinuousExecution")]
        private IWebElement eleChkProcessStepContinuousExecution { get; set; }

        [FindsBy(How = How.Id, Using = "stepFormSelect")]
        private IWebElement eleDdlForm { get; set; }

        [FindsBy(How = How.Id, Using = "attachMergeDocument")]
        private IWebElement eleChkAttachMergeDocument { get; set; }

        [FindsBy(How = How.Name, Using = "mergeDocumentID")]
        private IWebElement eleDdlMergeDocumentID { get; set; }

        [FindsBy(How = How.Id, Using = "displayStepDetailsInWorkflow")]
        private IWebElement eleChkDisplayStepDetailsInWorkflow { get; set; }

        // *******  Criteria Setup

        [FindsBy(How = How.Name, Using = "AllSelectionCriteriaMandatory")]
        private IWebElement eleRadioAllSelectionCriteriaMandatory { get; set; }

        [FindsBy(How = How.Name, Using = "UseSelectionCriteriaWeightings")]
        private IWebElement eleRadioUseSelectionCriteriaWeightings { get; set; }

        // ******* Talent Search

        [FindsBy(How = How.Id, Using = "userSearchTemplateID")]
        private IWebElement eleDdlSelectSearchTemplate { get; set; }

        [FindsBy(How = How.Id, Using = "EnableCloseRequisition")]
        private IWebElement eleChkEnableCloseRequisition { get; set; }

        [FindsBy(How = How.Name, Using = "PreSelectClosingJobTemplate")]
        private IList<IWebElement> eleRadioPreSelectClosingJobTemplate { get; set; }
        public void CompleteRequisition(string Value)
        {
            if (Value == "Select Job Template when completing Requisition")
            {
                eleRadioPreSelectClosingJobTemplate[0].Click();
            }
            else if (Value == "Select Job Template Now")
            {
                eleRadioPreSelectClosingJobTemplate[1].Click();
            }
            else
            {
                BaseMethods.InfoLogger("Invalid Option is provided for Complete Requisition");
            }
        }

        [FindsBy(How = How.Id, Using = "closingJobTemplateID")]
        private IWebElement eleDdlClosingJobTemplateID { get; set; }

        [FindsBy(How = How.Id, Using = "UserCanChangeClosingJobTemplate")]
        private IWebElement eleChkUserCanChangeClosingJobTemplate { get; set; }

        [FindsBy(How = How.Name, Using = "PreSelectContinuingJobTemplate")]
        private IList<IWebElement> eleRadioPreSelectContinuingJobTemplate { get; set; }
        public void ContinueRequisition(string Value)
        {
            if (Value == "Select Job Template when Continuing Requisition")
            {
                eleRadioPreSelectContinuingJobTemplate[0].Click();
            }
            else if (Value == "Select Job Template Now")
            {
                eleRadioPreSelectContinuingJobTemplate[1].Click();
            }
            else
            {
                BaseMethods.InfoLogger("Invalid Option is provided for Continue Requisition");
            }
        }

        [FindsBy(How = How.Id, Using = "ContinuingJobTemplateID")]
        private IWebElement eleDdlContinuingJobTemplateID { get; set; }

        [FindsBy(How = How.Id, Using = "UserCanChangeContinuingJobTemplate")]
        private IWebElement eleChkUserCanChangeContinuingJobTemplate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='SelectedProcessStepConfigurableRoles']")]
        private IList<IWebElement> eleChkDisplayRoles { get; set; }

        // ******* Assign Roles

        [FindsBy(How = How.Id, Using = "IncrementalRoleUserSelection")]
        private IWebElement eleChkChooseRoles { get; set; }


        // Permissions

        [FindsBy(How = How.XPath, Using = "//a[@id='PermissionsTabLabel']")]
        private IWebElement eleLinkPermissions { get; set; }
        public void PermissionsTab()
        {
            eleLinkPermissions.Click();
            BaseMethods.InfoLogger("Clicked on Permissions Tab");
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='useSetupTask']")]
        private IList<IWebElement> eleRadioPermissions { get; set; }
        public void RadioPermissions(string Value)
        {
            if (Value == "Configure Now")
            {
                eleRadioPermissions[0].Click();
                BaseMethods.InfoLogger(Value + ": is selected for Permissions");
            }
            else if (Value == "Configure immediately prior to step opening")
            {
                eleRadioPermissions[1].Click();
                BaseMethods.InfoLogger(Value + ": is selected for Permissions");
            }
            else if (Value == "Assign to Creator")
            {
                eleRadioPermissions[2].Click();
                BaseMethods.InfoLogger(Value + ": is selected for Permissions");
            }
            else
            {
                BaseMethods.InfoLogger("Invalid Option is Provided for Permissions");
            }
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='usersGrouping']")]
        private IList<IWebElement> eleChkRequisitionUsers { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='usersUsersDiv']/select")]
        public IWebElement eleDdlUsers { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='setupUsersGrouping']")]
        private IList<IWebElement> eleChkSetUpTaskUsers { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='setupUsersUsersDiv']/select")]
        public IWebElement eleDdlSetUpUsers { get; set; }

        [FindsBy(How = How.Id, Using = "sendSetupTaskNotificationEmail")]
        public IWebElement eleChkSendSetupTaskEmailNotification { get; set; }

        [FindsBy(How = How.Name, Using = "SetupTaskEmailID")]
        public IWebElement eleDdlSendSetupTaskEmailNotification { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='processStepSetupFilter']")]
        private IList<IWebElement> eleRadioDisplayUsergroupUsers { get; set; }
        public void RadioDisplayUsergroupUsers(string Value)
        {
            if (Value == "All")
            {
                eleRadioDisplayUsergroupUsers[0].Click();
                BaseMethods.InfoLogger(Value + ": is Selected for Display Usergroup & Users");
            }
            else if (Value == "None (Roles Only)")
            {
                eleRadioDisplayUsergroupUsers[1].Click();
                BaseMethods.InfoLogger(Value + ": is Selected for Display Usergroup & Users");
            }
            else if (Value == "Filter by Creators User Group")
            {
                eleRadioDisplayUsergroupUsers[2].Click();
                BaseMethods.InfoLogger(Value + ": is Selected for Display Usergroup & Users");
            }
            else if (Value == "Filter By Usergroup")
            {
                eleRadioDisplayUsergroupUsers[3].Click();
                BaseMethods.InfoLogger(Value + ": is Selected for Display Usergroup & Users");
            }
            else
            {
                BaseMethods.InfoLogger("Invalid option is provided for Display Usergroup & Users");
            }
        }

        [FindsBy(How = How.Id, Using = "processStepSetupFilterUserGroupID")]
        public IWebElement eleDdlFilterByGroup { get; set; }

        [FindsBy(How = How.Id, Using = "sendTaskNotificationEmail")]
        public IWebElement eleChkSendTaskNotificationEmail { get; set; }

        [FindsBy(How = How.Name, Using = "EmailID")]
        public IWebElement eleDdlEmailID { get; set; }

        // Filter the Template

        [FindsBy(How = How.Name, Using = "ProcessIsActive")]
        private IWebElement eleDdlProcessIsActive { get; set; }

        // FeedBack PopUp
        [FindsBy(How = How.XPath, Using = "//div[@id='productFeedbackPromptDialog']/p/a")]
        public IWebElement elePopUpNoThanks { get; set; }

        // Delete Process

        [FindsBy(How = How.XPath, Using = "//form[@id='DeleteProcessTemplate']/a")]
        public IWebElement eleLinkDeleteProcess { get; set; }
        public void LinkDeleteProcess()
        {
            eleLinkDeleteProcess.Click();
            BaseMethods.InfoLogger("Clicked on Delete Process Link");
        }

        [FindsBy(How = How.Name, Using = "btn_Delete")]
        private IWebElement elebtnDelete { get; set; }
        public void Delete()
        {
            BaseMethods.ScrollToView(driver, elebtnDelete);
            elebtnDelete.Click();
            BaseMethods.InfoLogger("Clicked on Delete Button");
        }

        // Add Rule

        [FindsBy(How = How.Name, Using = "ruleName")]
        private IWebElement eleTxtRuleName { get; set; }
        public void TxtRuleName(string Value)
        {
            eleTxtRuleName.Clear();
            eleTxtRuleName.SendKeys(Value);
            BaseMethods.InfoLogger("Entered '" + Value + "' in the Rule Name Text Field");
        }

        [FindsBy(How = How.Name, Using = "ruleTypeID")]
        private IWebElement eleDdlRuleTrigger { get; set; }

        [FindsBy(How = How.Name, Using = "formID")]
        private IWebElement eleDdlSource { get; set; }

        [FindsBy(How = How.Name, Using = "questionID")]
        private IWebElement eleDdlQuestion { get; set; }

        [FindsBy(How = How.Name, Using = "RuleComparatorID")]
        private IWebElement eleDdlApplyActionsIf { get; set; }

        [FindsBy(How = How.Name, Using = "RuleAnswerTextValue")]
        private IWebElement eleTxtApplyActions { get; set; }
        public void TxtApplyActions(string Value)
        {
            eleTxtApplyActions.Clear();
            eleTxtApplyActions.SendKeys(Value);
            BaseMethods.InfoLogger("Entered '" + Value + "' in the Apply Actions Text Field");
        }

        [FindsBy(How = How.Name, Using = "CriteriaID")]
        private IWebElement eleDdlCriteria { get; set; }

        // Add Action 

        [FindsBy(How = How.XPath, Using = "//a[text()=' Add Action']")]
        private IWebElement eleLinkAddAction { get; set; }
        public void LinkAddAction()
        {
            eleLinkAddAction.Click();
            BaseMethods.InfoLogger("Clicked on 'Add Action Link' ");
        }

        [FindsBy(How = How.Name, Using = "actionTypeID")]
        private IWebElement eleDdlActionType { get; set; }

        [FindsBy(How = How.Name, Using = "ProcessStepExecStatusID")]
        private IWebElement eleDdlDecision { get; set; }

        #endregion

        #region Methods

        public void CreateRequisitionFormTemplate(IWebDriver _driver)
        {
            _03_HomePage HP = new _03_HomePage(_driver);
            HP.SystemHeader();
            SystemConfirgPage SysConPage = new SystemConfirgPage(_driver);
            SysConPage.LinkFormTemplates();
            _05_FormTemplatePage FormTempPage = new _05_FormTemplatePage(_driver);
            FormTempPage.AddNewFormTemplate();
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList list = FormTempCreaPage.GetFormDetails("RequisitionProcessTemplateData", "FormTemplate", "FormType", "Requisition Form");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormType(), list[0].ToString());
            FormTempCreaPage.FormName(list[1].ToString());
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), list[2].ToString());
            FormTempCreaPage.SaveFormTemplate();
            BaseMethods.InfoLogger("Requisition Form Template is Created");
            FormTempCreaPage.CreateMultipleSteps(_driver, "RequisitionProcessTemplateData", "FormTemplateSteps", "FormType");
            //FormTempCreaPage.AddQuestionToStep(_driver, "RequisitionProcessTemplateData", "AddQuestiontoStep");
            FormTempCreaPage.AddGlobalQuestionToStep(_driver, "RequisitionProcessTemplateData", "AddGlobalQuestiontoStep");
            BaseMethods.DdlSelectByText(FormTempCreaPage.FormStatus(), "Active");
            FormTempCreaPage.SaveFormTemplate();
            BaseMethods.InfoLogger("Requisition Form Template is Created");
            HP.SystemHeader();
            SysConPage.LinkRequisitionProcessTemplates();
            CreateRequisitionProcessTemplate("RequisitionProcessTemplateData", "CreateRequisitionProcessTemp", "Execute", "Yes");
        }

        public void CreateRequisitionProcessTemplate(string ConfigKey, string SheetName, string CondKey, string CondValue)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, SheetName, CondKey, CondValue);
            if (list != null && list.Count > 0)
            {
                LinkCreateRequisitionProcessTemplate();
                int Count = list.Count;
                Count = Count / 5;
                int j = 1;
                for (int i = 0; i < Count; i++)
                {
                    TxtProcessName(list[j].ToString());
                    BaseMethods.DdlSelectByText(eleDdlProcessJobId, list[(j + 1)].ToString());
                    BaseMethods.SelectCheckBox(eleChkProcessIsActive, list[(j + 2)].ToString(), "Is Active");
                    Save();
                    string ExpectedValue = "×\r\n>   Active process must have at least one step and rule.    >   Process configuration incomplete, process set to inactive.   ";
                    string ActualValue = DivAlertMsg();
                    Assert.AreEqual(ExpectedValue, ActualValue);
                    CreateStep(list[(j + 3)].ToString());
                    CreateRule();
                    BaseMethods.SelectCheckBox(eleChkProcessIsActive, "Yes", "Is Active");
                    Save();
                }                
            }
        }

        public void CreateStep(string _KeyValue)
        {
            string[] _list = _KeyValue.ToString().Split(',');
            for (int i = 0; i < _list.Length; i++)
            {
                ArrayList list = ExcelData.GetData("RequisitionProcessTemplateData", "CreateStep", "StepTypeKey", _list[i].ToString());
                if (list != null && list.Count > 0)
                {
                    LinkCreateStep();
                    TxtProcessStepName(list[1].ToString());
                    BaseMethods.DdlSelectByText(eleDdlProcessStepTypeID, list[2].ToString());

                    if (list[2].ToString() == "Requisition Form")
                    {
                        #region Step Type = Requisition
                        BaseMethods.SelectCheckBox(eleChkProcessStepContinuousExecution, list[3].ToString(), "Continuous Execution");
                        BaseMethods.DdlSelectByText(eleDdlForm, list[4].ToString());
                        BaseMethods.SelectCheckBox(eleChkAttachMergeDocument, list[17].ToString(), "Attach Merge Document Template");
                        if (eleChkAttachMergeDocument.Selected)
                        {
                            BaseMethods.DdlSelectByText(eleDdlMergeDocumentID, list[18].ToString());
                        }
                        BaseMethods.SelectCheckBox(eleChkDisplayStepDetailsInWorkflow, list[19].ToString(), "Access step details from workflow");
                        #endregion
                    }
                    if (list[2].ToString() == "Criteria Setup")
                    {
                        #region Step Type = Criteria Setup
                        BaseMethods.SelectCheckBox(eleChkProcessStepContinuousExecution, list[3].ToString(), "Continuous Execution");
                        BaseMethods.YesNoRadioButtons(driver, eleRadioAllSelectionCriteriaMandatory, list[5].ToString());
                        BaseMethods.YesNoRadioButtons(driver, eleRadioUseSelectionCriteriaWeightings, list[6].ToString());
                        BaseMethods.SelectCheckBox(eleChkAttachMergeDocument, list[17].ToString(), "Attach Merge Document Template");
                        if (eleChkAttachMergeDocument.Selected)
                        {
                            BaseMethods.DdlSelectByText(eleDdlMergeDocumentID, list[18].ToString());
                        }
                        BaseMethods.SelectCheckBox(eleChkDisplayStepDetailsInWorkflow, list[19].ToString(), "Access step details from workflow");
                        #endregion
                    }
                    if (list[2].ToString() == "Select Job Template")
                    {
                        #region Step Type = Select Job Template
                        BaseMethods.SelectCheckBox(eleChkProcessStepContinuousExecution, list[3].ToString(), "Continuous Execution");
                        BaseMethods.SelectCheckBox(eleChkDisplayStepDetailsInWorkflow, list[19].ToString(), "Access step details from workflow");
                        #endregion
                    }
                    if (list[2].ToString() == "Assign Permissions")
                    {
                        #region Step Type = Assign Permissions
                        BaseMethods.SelectCheckBox(eleChkProcessStepContinuousExecution, list[3].ToString(), "Continuous Execution");
                        BaseMethods.SelectCheckBox(eleChkDisplayStepDetailsInWorkflow, list[19].ToString(), "Access step details from workflow");

                        #endregion
                    }
                    if (list[2].ToString() == "Talent Search")
                    {
                        #region Step Type = Talent Search
                        BaseMethods.SelectCheckBox(eleChkProcessStepContinuousExecution, list[3].ToString(), "Continuous Execution");
                        BaseMethods.DdlSelectByText(eleDdlSelectSearchTemplate, list[7].ToString());
                        BaseMethods.SelectCheckBox(eleChkEnableCloseRequisition, list[8].ToString(), "Enable Requisition Completion when Applying Candidates");
                        if (eleChkEnableCloseRequisition.Selected)
                        {
                            CompleteRequisition(list[9].ToString());
                            if (list[9].ToString() == "Select Job Template Now")
                            {
                                BaseMethods.DdlSelectByText(eleDdlClosingJobTemplateID, list[10].ToString());
                                BaseMethods.SelectCheckBox(eleChkUserCanChangeClosingJobTemplate, list[11].ToString(), "Allow user to change the Job Template during Requisition step");
                            }
                        }
                        ContinueRequisition(list[12].ToString());
                        if (list[12].ToString() == "Select Job Template Now")
                        {
                            BaseMethods.DdlSelectByText(eleDdlContinuingJobTemplateID, list[13].ToString());
                            BaseMethods.SelectCheckBox(eleChkUserCanChangeContinuingJobTemplate, list[14].ToString(), "Allow user to change the Job Template during Requisition step");
                        }
                        BaseMethods.SelectCheckBox(eleChkDisplayStepDetailsInWorkflow, list[19].ToString(), "Access step details from workflow");

                        #endregion
                    }
                    if (list[2].ToString() == "Assign Roles")
                    {
                        #region Step Type = Assign Roles
                        BaseMethods.SelectCheckBox(eleChkProcessStepContinuousExecution, list[3].ToString(), "Continuous Execution");
                        BaseMethods.SelectCheckBox(eleChkChooseRoles, list[15].ToString(), "Choose Rules");
                        if (eleChkChooseRoles.Selected)
                        {
                            string[] RolesList = list[16].ToString().ToString().Split(',');
                            for (int j = 0; j < RolesList.Length; j++)
                            {
                                for (int k = 1; k <= eleChkDisplayRoles.Count; k++)
                                {
                                    IWebElement ele = driver.FindElement(By.XPath("(//input[@name='SelectedProcessStepConfigurableRoles'])[" + (k) + "]/.."));
                                    string _text = ele.Text;
                                    if (RolesList[j] == _text)
                                    {
                                        IWebElement eleRoles = driver.FindElement(By.XPath("(//input[@name='SelectedProcessStepConfigurableRoles'])[" + (k) + "]"));
                                        eleRoles.Click();
                                        BaseMethods.InfoLogger(_text + ": role Selected");
                                        IWebElement AllUsersele = driver.FindElement(By.XPath("(//input[@name='ProcessStepConfigurableRolesSelectAllUsers'])[" + (k) + "]"));
                                        AllUsersele.Click();
                                    }
                                }
                            }
                        }
                        BaseMethods.SelectCheckBox(eleChkDisplayStepDetailsInWorkflow, list[19].ToString(), "Access step details from workflow");
                        #endregion
                    }
                    Save();
                    string ExpectedValue = "×\r\n>   Process Step configuration updated.    >   You must now configure Permissions on the Permissions tab page. Default permission set to 'Configure Now' with 'All Users with Permission to Job'.   ";
                    string ActualValue = DivAlertMsg();
                    Assert.AreEqual(ExpectedValue, ActualValue);

                    // Permissions
                    CreatePermissions(_list[i].ToString());
                }
            }            
        }

        public string AssessmentUsers(IWebDriver _driver, ArrayList list)
        {
            string _ActionsPerformed = string.Empty;
            if (list[2].ToString() != "Null")
            {
                BaseMethods.SelectCheckBox(eleChkRequisitionUsers[0], "Yes", "General");
                if (list[2].ToString() == "All Users with Permission to this Job")
                {
                    IWebElement ele = _driver.FindElement(By.XPath("//input[@id='allJobUsersCheck']"));
                    BaseMethods.SelectCheckBox(ele, "Yes", "All Users with Permission to this Job");
                    _ActionsPerformed += "General : All Users with Permission to this Job \n";
                }
            }
            if (list[3].ToString() != "Null")
            {
                BaseMethods.ScrollToView(_driver, eleChkRequisitionUsers[1]);
                eleChkRequisitionUsers[1].Click();
                string[] RolesList = list[3].ToString().Split(',');
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
                            BaseMethods.InfoLogger("Provied Role: " + RolesList[j] + " is not found");
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
            if (list[4].ToString() != "Null")
            {
                BaseMethods.PageScrollDown(_driver);
                BaseMethods.ScrollToView(_driver, eleChkRequisitionUsers[2]);
                eleChkRequisitionUsers[2].Click();
                // Randomely selecting first three groups due to Xpath issue
                for (int i = 1; i <= 3; i++)
                {
                    IWebElement ele = _driver.FindElement(By.XPath("//div[@id='usersUserGroupsDiv']/input[" + (i) + "]"));
                    ele.Click();
                }
                _ActionsPerformed += "User Groups \n ";
            }
            if (list[5].ToString() != "Null")
            {
                BaseMethods.ScrollToView(_driver, eleChkRequisitionUsers[3]);
                eleChkRequisitionUsers[3].Click();
                string[] UserList = list[5].ToString().ToString().Split('_');
                BaseMethods.CtrlKeyDown(_driver);
                for (int k = 0; k < UserList.Length; k++)
                {
                    BaseMethods.DdlSelectByText(eleDdlUsers, UserList[k]);
                }
                BaseMethods.InfoLogger("Users: " + list[5].ToString() + " are Selected");
                _ActionsPerformed += "Users \n ";
            }
            return _ActionsPerformed;
        }

        public string AssessmentUsers(IWebDriver _driver, ArrayList list, string Value)
        {
            string _ActionsPerformed = string.Empty;
            if (list[2].ToString() != "Null")
            {
                BaseMethods.SelectCheckBox(eleChkSetUpTaskUsers[0], "Yes", "General");
                if (list[2].ToString() == "All Users with Permission to this Job")
                {
                    IWebElement ele = _driver.FindElement(By.XPath("//input[@name='setupUsers']"));
                    BaseMethods.SelectCheckBox(ele, "Yes", "All Users with Permission to this Job");
                    _ActionsPerformed += "General : All Users with Permission to this Job \n";
                }
            }
            if (list[3].ToString() != "Null")
            {
                BaseMethods.ScrollToView(_driver, eleChkSetUpTaskUsers[1]);
                eleChkSetUpTaskUsers[1].Click();
                string[] RolesList = list[3].ToString().Split(',');
                for (int j = 0; j < RolesList.Length; j++)
                {
                    string _xpath = string.Empty;
                    #region
                    switch (RolesList[j])
                    {
                        case "Hiring Manager":
                            _xpath = "//div[@id='setupUsersRolesDiv']/input[1]";
                            break;
                        case "HRBP":
                            _xpath = "//div[@id='setupUsersRolesDiv']/input[2]";
                            break;
                        case "Recruitment Specialist":
                            _xpath = "//div[@id='setupUsersRolesDiv']/input[3]";
                            break;
                        case "Approving Manager":
                            _xpath = "//div[@id='setupUsersRolesDiv']/input[4]";
                            break;
                        case "GM":
                            _xpath = "//div[@id='setupUsersRolesDiv']/input[5]";
                            break;
                        case "Group Exec":
                            _xpath = "//div[@id='setupUsersRolesDiv']/input[6]";
                            break;
                        case "CEO":
                            _xpath = "//div[@id='setupUsersRolesDiv']/input[7]";
                            break;
                        case "GMIC":
                            _xpath = "//div[@id='setupUsersRolesDiv']/input[8]";
                            break;
                        case "GMIT":
                            _xpath = "//div[@id='setupUsersRolesDiv']/input[9]";
                            break;
                        default:
                            BaseMethods.InfoLogger("Provied Role: " + RolesList[j] + " is not found");
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
            if (list[4].ToString() != "Null")
            {
                BaseMethods.PageScrollDown(_driver);
                BaseMethods.ScrollToView(_driver, eleChkSetUpTaskUsers[2]);
                eleChkSetUpTaskUsers[2].Click();
                // Randomely selecting first three groups due to Xpath issue
                for (int i = 1; i <= 3; i++)
                {
                    IWebElement ele = _driver.FindElement(By.XPath("//div[@id='setupUsersUserGroupsDiv']/input[" + (i) + "]"));
                    ele.Click();
                }
                _ActionsPerformed += "User Groups \n ";
            }
            if (list[5].ToString() != "Null")
            {
                BaseMethods.ScrollToView(_driver, eleChkSetUpTaskUsers[3]);
                eleChkSetUpTaskUsers[3].Click();
                string[] UserList = list[5].ToString().ToString().Split('_');
                BaseMethods.CtrlKeyDown(_driver);
                for (int k = 0; k < UserList.Length; k++)
                {
                    BaseMethods.DdlSelectByText(eleDdlSetUpUsers, UserList[k]);
                }
                BaseMethods.InfoLogger("Users: " + list[5].ToString() + " are Selected");
                _ActionsPerformed += "Users \n ";
            }
            return _ActionsPerformed;
        }

        public void CreatePermissions(string _KeyValue)
        {
            ArrayList Permissionslist = ExcelData.GetData("RequisitionProcessTemplateData", "CreateStep_Permissions", "StepTypeKey", _KeyValue);
            if (Permissionslist != null && Permissionslist.Count > 0)
            {
                PermissionsTab();
                RadioPermissions(Permissionslist[1].ToString());
                if (Permissionslist[1].ToString() == "Configure Now")
                {
                    AssessmentUsers(driver, Permissionslist);
                    BaseMethods.SelectCheckBox(eleChkSendTaskNotificationEmail, Permissionslist[10].ToString(), "Send Task Notification Email");
                    if (Permissionslist[10].ToString() == "Yes" && eleChkSendTaskNotificationEmail.Selected)
                        BaseMethods.DdlSelectByText(eleDdlEmailID, Permissionslist[11].ToString());
                }
                else if (Permissionslist[1].ToString() == "Configure immediately prior to step opening")
                {
                    AssessmentUsers(driver, Permissionslist, "SetupTaskUsers");
                    BaseMethods.SelectCheckBox(eleChkSendSetupTaskEmailNotification, Permissionslist[6].ToString(), "Send Setup Task Email Notification");
                    BaseMethods.DdlSelectByText(eleDdlSendSetupTaskEmailNotification, Permissionslist[7].ToString());
                    RadioDisplayUsergroupUsers(Permissionslist[8].ToString());
                    if (Permissionslist[8].ToString() == "Filter By Usergroup")
                    {
                        BaseMethods.DdlSelectByText(eleDdlFilterByGroup, Permissionslist[9].ToString());
                    }
                    BaseMethods.SelectCheckBox(eleChkSendTaskNotificationEmail, Permissionslist[10].ToString(), "Send Task Notification Email");
                    if (Permissionslist[10].ToString() == "Yes" && eleChkSendTaskNotificationEmail.Selected)
                        BaseMethods.DdlSelectByText(eleDdlEmailID, Permissionslist[11].ToString());
                }
                else if (Permissionslist[1].ToString() == "Assign to Creator")
                {
                    BaseMethods.SelectCheckBox(eleChkSendTaskNotificationEmail, Permissionslist[10].ToString(), "Send Task Notification Email");
                    if (Permissionslist[10].ToString() == "Yes" && eleChkSendTaskNotificationEmail.Selected)
                        BaseMethods.DdlSelectByText(eleDdlEmailID, Permissionslist[11].ToString());
                }
                else
                {
                    ExtentReport.test.Log(LogStatus.Error, "Invalid Data..Please check the Data provided in the 'CreateStep_Permissions' sheet.");
                }
                Save();
                string PermissionsExpectedMsg = "×\r\n>   Process Step configuration updated.   ";
                string PermissionsActualMsg = DivAlertMsg();
                Assert.AreEqual(PermissionsExpectedMsg, PermissionsActualMsg);
                LinkRequisitionProcessTemplate();
            }
        }

        public void CreateRule()
        {
            ArrayList AddRule = ExcelData.GetData("RequisitionProcessTemplateData", "AddRule");
            if (AddRule != null && AddRule.Count > 0)
            {
                int count = AddRule.Count;
                count = count / 11;
                int j = 1;
                for (int i = 1; i <= count; i++)
                {
                    ArrayList AddRuleList = ExcelData.GetData("RequisitionProcessTemplateData", "AddRule", "StepNumber", i.ToString());
                    IWebElement ele = driver.FindElement(By.XPath("//form[@id='AssessmentProcessDetails']/table/tbody/tr[" + (j) + "]/td[2]/span[1]/a"));
                    ele.Click();
                    TxtRuleName(AddRuleList[1].ToString());
                    BaseMethods.DdlSelectByText(eleDdlRuleTrigger, AddRuleList[2].ToString());
                    BaseMethods.DdlSelectByText(eleDdlSource, AddRuleList[3].ToString());
                    BaseMethods.ExplicitWait(driver, "//select[@name='questionID']");
                    BaseMethods.DdlSelectByText(eleDdlQuestion, AddRuleList[4].ToString());
                    BaseMethods.SleepTimeOut(1000);
                    BaseMethods.DdlSelectByText(eleDdlApplyActionsIf, AddRuleList[5].ToString());
                    TxtApplyActions(AddRuleList[6].ToString());
                    BaseMethods.DdlSelectByText(eleDdlCriteria, AddRuleList[7].ToString());
                    Save();
                    if (AddRuleList[8].ToString() == "Yes")
                    {
                        LinkAddAction();
                        BaseMethods.DdlSelectByText(eleDdlActionType, AddRuleList[9].ToString());
                        BaseMethods.DdlSelectByText(eleDdlDecision, AddRuleList[10].ToString());
                        Save();
                        string ActionExpectedMsg = "×\r\n>   Action configuration updated.   ";
                        string ActionActualMsg = DivAlertMsg();
                        Assert.AreEqual(ActionExpectedMsg, ActionActualMsg);
                        Save();
                        string RuleExpectedMsg = "×\r\n>   Rule configuration updated.   ";
                        string RuleActualMsg = DivAlertMsg();
                        Assert.AreEqual(RuleExpectedMsg, RuleActualMsg);
                    }
                    Cancel();
                    j = j + 3;
                }
            }
        }

       

        public void DeleteRequisitionProcess(IWebDriver _driver)
        {
            ArrayList Deletelist = ExcelData.GetData("RequisitionProcessTemplateData", "Delete_RequisitionProcess");
            if (Deletelist != null && Deletelist.Count > 0)
            {
                BaseMethods.DdlSelectByText(eleDdlProcessIsActive, "All");
                for (int i = 0; i < Deletelist.Count; i++)
                {
                    string _DelName = Deletelist[i].ToString();
                    try
                    {
                        IWebElement ele = driver.FindElement(By.XPath("(//a[text()='" + _DelName + "'])[1]"));
                        ele.Click();
                    }
                    catch (NoSuchElementException)
                    {
                        BaseMethods.InfoLogger("Record not found to Delete");
                    }
                    BaseMethods.ExplicitWait(_driver, "//div[@id='productFeedbackPromptDialog']/p/a");
                    elePopUpNoThanks.Click();
                    LinkDeleteProcess();
                    Delete();
                    string PermissionsExpectedMsg = "×\r\n>   The Requisition Process Template " + _DelName + " has been deleted.   ";
                    string PermissionsActualMsg = DivAlertMsg();
                    Assert.AreEqual(PermissionsExpectedMsg, PermissionsActualMsg);
                    BaseMethods.InfoLogger("The Requisition Process Template " + _DelName + " has been deleted");
                }
            }
        }
        #endregion
    }
}
