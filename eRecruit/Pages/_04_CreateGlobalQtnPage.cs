using eRecruit.Library;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

namespace eRecruit.Pages
{
    /// <summary>
    /// Global Questions - Question Details Page
    /// </summary>
    public class _04_CreateGlobalQtnPage
    {
        public _04_CreateGlobalQtnPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region ******************************************* Add Global Questions *************************************************

        #region ****** WebElements

        [FindsBy(How = How.Id, Using = "ui-id-2")]
        private IWebElement EleTabQuestionDetails { get; set; }

        /// <summary>
        /// Clicks on Question Details Tab
        /// </summary>
        public void QuestionDetails()
        {
            EleTabQuestionDetails.Click();
            BaseMethods.InfoLogger("Clicking on Question Details Tab");
        }

        [FindsBy(How = How.Name, Using = "ComponentTypeID")]
        public IWebElement eleddlQuestionType { get; set; }

        /// <summary>
        /// Get the Component Type IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement ComponentType()
        {
            return eleddlQuestionType;
        }


        [FindsBy(How = How.Id, Using = "FormTypeID")]
        public IWebElement eleddlFormType { get; set; }

        /// <summary>
        /// Get the Form Type IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement FormType()
        {
            return eleddlFormType;
        }

        [FindsBy(How = How.Id, Using = "isActive1")]
        public IWebElement elerdoIsActiveNO { get; set; }
        public void IsActiveNo()
        {
            elerdoIsActiveNO.Click();
            BaseMethods.InfoLogger("Question Active is No");
        }

        [FindsBy(How = How.Id, Using = "isActive2")]
        public IWebElement elerdoIsActiveYES { get; set; }
        public void IsActiveYes()
        {
            elerdoIsActiveYES.Click();
            BaseMethods.InfoLogger("Question Active is Yes");
        }

        [FindsBy(How = How.Id, Using = "GlobalQuestionReference")]
        private IWebElement eletxtReference { get; set; }
        /// <summary>
        /// Enter data in Reference Text Field
        /// </summary>
        /// <param name="value">Enter the Value</param>
        /// <param name="_date">True or False (If true, current system date will be added to the Value)</param>
        public string _QuestionReference = string.Empty;
        public void ReferenceText(string value, bool _date)
        {

            string CurrentDate = Convert.ToString(DateTime.Now);
            string ShortDate = CurrentDate.Replace("/", "_").Replace(":", "_").Replace(" ", "_");
            eletxtReference.Clear();
            if (_date == true)
            {
                value += ShortDate;
                _QuestionReference = string.Empty;
                _QuestionReference = value;
                eletxtReference.SendKeys(value);
                BaseMethods.InfoLogger("Entered Refernce Text: " + value);
            }
            else
            {
                _QuestionReference = string.Empty;
                _QuestionReference = value;
                eletxtReference.SendKeys(value);
                BaseMethods.InfoLogger("Entered Refernce Text: " + value);
            }
        }

        [FindsBy(How = How.Id, Using = "ShortQuestionText")]
        private IWebElement eletxtShortQuestionText { get; set; }
        public void ShortQuestionText(string value)
        {
            eletxtShortQuestionText.Clear();
            eletxtShortQuestionText.SendKeys(value);
            BaseMethods.InfoLogger("Entered Short Question Text: " + value);
        }

        [FindsBy(How = How.Id, Using = "tinymce")]
        private IWebElement eletxtQuestion { get; set; }

        /// <summary>
        /// Get the Tiny MCE IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement TinyMce()
        {
            return eletxtQuestion;
        }

        [FindsBy(How = How.Name, Using = "Save")]
        private IWebElement elebtnSave { get; set; }
        public void Save()
        {
            elebtnSave.Click();
            BaseMethods.InfoLogger("Clicked on Save button");
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleSuccessMsg { get; set; }
        public string GetAlertMessage()
        {
            string msg = eleSuccessMsg.Text;
            BaseMethods.InfoLogger("Div Alert Message is: " + msg);
            return msg;
        }

        [FindsBy(How = How.LinkText, Using = "Global Question List")]
        private IWebElement eleGlobalQuestionListLink { get; set; }
        public void GlobalQuestionLink()
        {
            eleGlobalQuestionListLink.Click();
            BaseMethods.InfoLogger("Clicked on Global Question Link");
        }

        [FindsBy(How = How.Id, Using = "GlobalQuestionLabel_ifr")]
        public IWebElement eleFrame { get; set; }

        /// <summary>
        /// Get the Global Question Label IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement GlobalQuestionLabel()
        {
            return eleFrame;
        }

        [FindsBy(How = How.Id, Using = "ui-id-4")]
        private IWebElement EleTabAnswerOptions { get; set; }

        /// <summary>
        /// Clicks on Answer Options Tab
        /// </summary>
        public void AnswerOptions()
        {
            EleTabAnswerOptions.Click();
            BaseMethods.InfoLogger("Clicking on Answer Options Tab");
        }

        #endregion

        #region ****** Methods
        /// <summary>
        /// Create Global Questions
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public void CreateQuestions(IWebDriver _driver, string Key, string Sheet, string ConditionValue, string Value)
        {
            _04_GlobalQtnListPage GQP = new _04_GlobalQtnListPage(_driver);
            ArrayList list = ExcelData.GetData(Key, Sheet, ConditionValue, Value);
            int Count = list.Count;
            int _actualRowCount = Count / 8;
            int j = 1;
            for (int i = 0; i < _actualRowCount; i++)
            {
                BaseMethods.InfoLogger("Creating Global 0" + (i + 1) + " Question Started");
                QuestionDetails();
                BaseMethods.DdlSelectByText(eleddlQuestionType, list[j].ToString());
                BaseMethods.InfoLogger("Question Type: " + list[(j)].ToString());
                string[] formTypesList = list[(j + 1)].ToString().Split(',');
                BaseMethods.CtrlKeyDown(_driver);
                for (int k = 0; k < formTypesList.Length; k++)
                {
                    BaseMethods.DdlSelectByText(eleddlFormType, formTypesList[k]);
                    BaseMethods.InfoLogger("Question Use: " + formTypesList[k].ToString());
                }
                if (list[(j + 2)].ToString() == "Yes")
                {
                    IsActiveYes();
                }
                else
                {
                    IsActiveNo();
                }
                ReferenceText(list[(j + 3)].ToString(), true);
                ShortQuestionText(list[(j + 4)].ToString());
                BaseMethods.TinyMCEEditor(_driver, eleFrame, list[(j + 5)].ToString());
                Save();
                string ExpectedSucessMsg = "×\r\n>   Global Question configuration updated successfully.   ";
                string ActualSucessMsg = GetAlertMessage();
                BaseMethods.SoftAssertEqual(ExpectedSucessMsg, ActualSucessMsg);
                if (list[j].ToString() == "Group Question")
                {
                    CreateGlobalQueWithOptionsPage ChildQue = new CreateGlobalQueWithOptionsPage(_driver);
                    // Click on Answer Options Tab
                    AnswerOptions();
                    ChildQue.CreateNewChildQuestion(_driver);
                }
                if (list[j].ToString() == "Group Question" || list[j].ToString() == "Multi Select")
                {
                    // Click on Answer Options Tab
                    AnswerOptions();
                    AddNewAnswers(_driver, list[(j + 6)].ToString());
                }
                j = j + 8;
                GlobalQuestionLink();
                GQP.CreateNewGlbQtn();
            }
        }

        #endregion
        #endregion

        #region ******************************************* Add New Answers *************************************************

        #region ****** WebElements
        [FindsBy(How = How.XPath, Using = "//a[text()=' Add New Answers']")]
        private IWebElement EleAddNewAnswersLink { get; set; }

        public void LinkAddNewAnswers()
        {
            EleAddNewAnswersLink.Click();
            BaseMethods.InfoLogger("Clicked on Add New Answers Link");
        }

        [FindsBy(How = How.Name, Using = "btn_Save")]
        private IWebElement EleChildBtnSave { get; set; }

        public void ChildSave()
        {
            EleChildBtnSave.Click();
            BaseMethods.InfoLogger("Clicked on Save Button");
        }

        #endregion

        #region ****** Methods
        public void AddNewAnswers(IWebDriver _driver, string Answers)
        {
            BaseMethods.InfoLogger("Answer Options: Add New Answers Started");
            LinkAddNewAnswers();
            string[] ValueList = Answers.ToString().Split(',');
            for (int i = 1; i <= ValueList.Length; i++)
            {
                IWebElement ele = _driver.FindElement(By.XPath("//input[@name='DisplayValue" + (i) + "']"));
                ele.SendKeys(ValueList[(i - 1)]);
            }
            ChildSave();
            string ExpectedSucessMsg = "×\r\n>   " + (ValueList.Length) + " answers added successfully.   ";
            string ActualSucessMsg = GetAlertMessage();
            Assert.AreEqual(ExpectedSucessMsg, ActualSucessMsg);
            BaseMethods.InfoLogger("Answer Options: Add New Answers Completed");
        }
        #endregion

        #endregion

    }

    /// <summary>
    /// Global Questions - Question Options Page
    /// </summary>
    public class CreateGlobalQueWithOptionsPage : _04_CreateGlobalQtnPage
    {
        public CreateGlobalQueWithOptionsPage(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        #region ******************************************* Add Global Questions with Options *************************************************

        #region ****** Web Elements

        [FindsBy(How = How.Id, Using = "ui-id-3")]
        private IWebElement EleTabQuestionOptions { get; set; }

        /// <summary>
        /// Clicks on Question Options Tab
        /// </summary>
        public void QuestionOptions()
        {
            EleTabQuestionOptions.Click();
            BaseMethods.InfoLogger("Clicking on Question Options Tab");
        }

        // Question Options

        [FindsBy(How = How.Name, Using = "AnswerFormat")]
        private IWebElement EleDdlAnswerDisplayFormat { get; set; }

        /// <summary>
        /// Get the Answer Display Format IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement AnswerDisplayFormat()
        {
            return EleDdlAnswerDisplayFormat;
        }

        [FindsBy(How = How.Name, Using = "DataType")]
        private IWebElement EleDdlDataType { get; set; }

        /// <summary>
        /// Get the Data Type IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement DataType()
        {
            return EleDdlDataType;
        }

        // // Pre-population Options
        [FindsBy(How = How.Name, Using = "UsesCandidatePrefill")]
        private IWebElement EleRadioUsesCandidatePrefill { get; set; }

        /// <summary>
        /// Get the Candidate Prefill IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement CandidatePrefill()
        {
            return EleRadioUsesCandidatePrefill;
        }

        [FindsBy(How = How.Name, Using = "UsesJobPrefill")]
        private IWebElement EleRadioUsesJobPrefill { get; set; }

        /// <summary>
        /// Get the Job Prefill IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement JobPrefill()
        {
            return EleRadioUsesJobPrefill;
        }

        // // Single-instance Update Options
        [FindsBy(How = How.Name, Using = "IsCandidateSingleInstanced")]
        private IWebElement EleRadioIsCandidateSingleInstanced { get; set; }

        /// <summary>
        /// Get the Candidate Single Instanced IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement CandidateSingleInstanced()
        {
            return EleRadioIsCandidateSingleInstanced;
        }

        [FindsBy(How = How.Name, Using = "LimitSingleInstanceToJob")]
        private IWebElement EleRadioLimitSingleInstanceToJob { get; set; }

        /// <summary>
        /// Get the Limit Single Instance To Job IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement LimitSingleInstanceToJob()
        {
            return EleRadioLimitSingleInstanceToJob;
        }

        [FindsBy(How = How.Name, Using = "IsJobSingleInstanced")]
        private IWebElement EleRadioIsJobSingleInstanced { get; set; }

        /// <summary>
        /// Get the Job Single Instanced IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement JobSingleInstanced()
        {
            return EleRadioIsJobSingleInstanced;
        }

        // // Versioning Options

        [FindsBy(How = How.Name, Using = "IsVersioned")]
        private IWebElement EleRadioIsVersioned { get; set; }

        /// <summary>
        /// Get the Versioned IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement Versioned()
        {
            return EleRadioIsVersioned;
        }

        // // Validation Options

        [FindsBy(How = How.Name, Using = "IsRequired")]
        private IWebElement EleRadioIsRequiredYes { get; set; }

        /// <summary>
        /// Get the Versioned IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement IsRequired()
        {
            return EleRadioIsRequiredYes;
        }

        [FindsBy(How = How.Name, Using = "MaxLengthType")]
        private IWebElement EleRadioMaxLengthType1 { get; set; }

        /// <summary>
        /// Get the Max Length Type IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement MaxLengthType()
        {
            return EleRadioMaxLengthType1;
        }

        [FindsBy(How = How.Name, Using = "MaxLength")]
        private IWebElement EleTxtMaxLength { get; set; }

        /// <summary>
        /// Set the Max Length
        /// </summary>
        /// <param name="Value">Value to be entered in the Text Box</param>
        public void MaxLength(string Value)
        {
            EleTxtMaxLength.Clear();
            EleTxtMaxLength.SendKeys(Value);
            BaseMethods.InfoLogger("Value entered in Max Length field is: " + Value);
        }

        [FindsBy(How = How.Name, Using = "componentValidationTypeID")]
        private IWebElement EleDdlValidationType { get; set; }

        /// <summary>
        /// Get the Validation Type IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement ValidationType()
        {
            return EleDdlValidationType;
        }

        // // Display Options

        [FindsBy(How = How.Name, Using = "HTMLComponentOrientation")]
        private IWebElement EleRadioHTMLComponentOrientation { get; set; }

        /// <summary>
        /// Get the HTML Component Orientation IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement HTMLComponentOrientation()
        {
            return EleRadioHTMLComponentOrientation;
        }

        [FindsBy(How = How.Name, Using = "HTMLAnswerAlignment")]
        private IWebElement EleRadioHTMLAnswerAlignment { get; set; }

        /// <summary>
        /// Get the HTML Answer Alignment IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement HTMLAnswerAlignment()
        {
            return EleRadioHTMLAnswerAlignment;
        }

        [FindsBy(How = How.Name, Using = "isNoRecruiterView")]
        private IWebElement EleRadioisNoRecruiterView { get; set; }

        /// <summary>
        /// Get the RecruiterView IWebElement
        /// </summary>
        /// <returns>IWebElement</returns>
        public IWebElement RecruiterView()
        {
            return EleRadioisNoRecruiterView;
        }

        [FindsBy(How = How.Id, Using = "GlobalComponentXMLName")]
        private IWebElement EleTxtGlobalComponentXMLName { get; set; }

        /// <summary>
        /// Set the Max Global Component XML Name
        /// </summary>
        /// <param name="Value">Value to be entered in the Text Box</param>
        public void GlobalComponentXMLName(string Value)
        {
            EleTxtGlobalComponentXMLName.Clear();
            EleTxtGlobalComponentXMLName.SendKeys(Value);
            BaseMethods.InfoLogger("Value entered in Global Component XML Name field is: " + Value);
        }

        // Cancel Button

        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement EleBtnCancel { get; set; }

        /// <summary>
        /// Clicks on the Cancel button
        /// </summary>
        public void Cancel()
        {
            EleBtnCancel.Click();
            BaseMethods.InfoLogger("Clicked on Cancel Button");
        }

        #endregion

        #region ****** Methods
        public void CreateQuestionWithOptions(IWebDriver _driver)
        {
            _04_GlobalQtnListPage GQP = new _04_GlobalQtnListPage(_driver);

            ArrayList list = ExcelData.GetData("GlobalQuestionsData", "GlobalQuestionWithOptions", "Execute", "Yes");
            int Count = list.Count;
            int _actualRowCount = Count / 21;
            int j = 1;
            for (int i = 0; i < _actualRowCount; i++)
            {
                BaseMethods.InfoLogger("Creating Global Question with Options Started");

                QuestionDetails();

                BaseMethods.DdlSelectByText(ComponentType(), list[j].ToString());
                BaseMethods.InfoLogger("Question Type: " + list[j].ToString());

                string[] formTypesList = list[(j + 1)].ToString().Split(',');
                for (int k = 0; k < formTypesList.Length; k++)
                {
                    BaseMethods.DdlSelectByText(FormType(), formTypesList[k]);
                    BaseMethods.InfoLogger("Question Use: " + formTypesList[k].ToString());
                }
                if (list[(j + 2)].ToString() == "Yes")
                {
                    IsActiveYes();
                }
                else
                {
                    IsActiveNo();
                }
                ReferenceText(list[(j + 3)].ToString(), true);
                ShortQuestionText(list[(j + 4)].ToString());
                BaseMethods.TinyMCEEditor(_driver, GlobalQuestionLabel(), list[(j + 5)].ToString());

                BaseMethods.PageScrollUp(_driver);

                BaseMethods.SleepTimeOut(2000);
                QuestionOptions();
                BaseMethods.DdlSelectByText(AnswerDisplayFormat(), list[(j + 6)].ToString());
                BaseMethods.InfoLogger("Answer Display Format: " + list[(j + 6)].ToString());

                BaseMethods.DdlSelectByText(DataType(), list[(j + 7)].ToString());
                BaseMethods.InfoLogger("Data Type: " + list[(j + 7)].ToString());

                BaseMethods.NoYesRadioButtons(_driver, CandidatePrefill(), list[(j + 8)].ToString());
                BaseMethods.InfoLogger("Candidate Prefil: " + list[(j + 8)].ToString());

                BaseMethods.NoYesRadioButtons(_driver, JobPrefill(), list[(j + 9)].ToString());
                BaseMethods.InfoLogger("Job Prefil: " + list[(j + 9)].ToString());

                BaseMethods.NoYesRadioButtons(_driver, CandidateSingleInstanced(), list[(j + 10)].ToString());
                BaseMethods.InfoLogger("Candidate Single Instanced: " + list[(j + 10)].ToString());

                BaseMethods.NoYesRadioButtons(_driver, JobSingleInstanced(), list[(j + 11)].ToString());
                BaseMethods.InfoLogger("Job Single Instanced: " + list[(j + 11)].ToString());

                BaseMethods.NoYesRadioButtons(_driver, Versioned(), list[(j + 12)].ToString());
                BaseMethods.InfoLogger("Is Versioned: " + list[(j + 12)].ToString());

                BaseMethods.NoYesRadioButtons(_driver, IsRequired(), list[(j + 13)].ToString());
                BaseMethods.InfoLogger("Is Required: " + list[(j + 13)].ToString());

                // BaseMethods.CtrlKeyDown(_driver);

                if (list[(j + 14)].ToString() != "Null")
                {
                    MaxLength(list[(j + 14)].ToString());
                }

                if (ValidationType().Displayed)
                {
                    BaseMethods.DdlSelectByText(ValidationType(), list[(j + 15)].ToString());
                    BaseMethods.InfoLogger("Validation Type: " + list[(j + 15)].ToString());
                }

                BaseMethods.SelectRadioButtonWithValue(_driver, HTMLComponentOrientation(), list[(j + 16)].ToString());
                BaseMethods.InfoLogger("Input Orientation: " + list[(j + 16)].ToString());

                BaseMethods.SelectRadioButtonWithValue(_driver, HTMLAnswerAlignment(), list[(j + 17)].ToString());
                BaseMethods.InfoLogger("Input Orientation: " + list[(j + 17)].ToString());

                BaseMethods.NoYesRadioButtons(_driver, RecruiterView(), list[(j + 18)].ToString());
                BaseMethods.InfoLogger("Hide From Recruiters: " + list[(j + 18)].ToString());

                GlobalComponentXMLName(list[(j + 19)].ToString());

                Save();

                string ExpectedSucessMsg = "×\r\n>   Global Question configuration updated successfully.   ";
                string ActualSucessMsg = GetAlertMessage();
                Assert.AreEqual(ExpectedSucessMsg, ActualSucessMsg);
                j = j + 21;
                GlobalQuestionLink();
                GQP.CreateNewGlbQtn();
            }

        }

        #endregion

        #endregion

        #region ******************************************* Add Child Question *************************************************

        #region ****** Web Elemets

        [FindsBy(How = How.XPath, Using = "//a[text()=' Add New Child Question']")]
        private IWebElement EleAddNewChildQuestionLink { get; set; }

        public void LinkAddNewChildQuestion()
        {
            EleAddNewChildQuestionLink.Click();
            BaseMethods.InfoLogger("Clicked on Add New Child Question Link");
        }

        [FindsBy(How = How.Name, Using = "GlobalComponentReference")]
        private IWebElement EleQuestionReference { get; set; }

        public void QuestionReference(string value)
        {
            EleQuestionReference.SendKeys(value);
            BaseMethods.InfoLogger(value + " : entered value in the Question Reference Text Field");
        }

        [FindsBy(How = How.Id, Using = "GlobalComponentLabel_ifr")]
        private IWebElement eleChildFrame { get; set; }

        public IWebElement GlobalComponentLabel()
        {
            return eleChildFrame;
        }

        [FindsBy(How = How.Name, Using = "isRequired")]
        private IWebElement EleChildRadioIsRequiredYes { get; set; }

        public IWebElement ChildIsRequired()
        {
            return EleChildRadioIsRequiredYes;
        }

        [FindsBy(How = How.Name, Using = "IsHidden")]
        private IWebElement EleRadioIsHidden { get; set; }

        public IWebElement IsHidden()
        {
            return EleRadioIsHidden;
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='DisplayAndValue']")]
        private IList<IWebElement> EleRadioAnswerConfiguration { get; set; }

        public void AnswerConfiguration(string Value)
        {
            if (Value == "Display Only")
            {
                EleRadioAnswerConfiguration[0].Click();
            }
            else if (Value == "Display And Value")
                EleRadioAnswerConfiguration[1].Click();
            else
                BaseMethods.InfoLogger("Wrong Option is selected for Answer Configuration");
        }


        [FindsBy(How = How.LinkText, Using = "Global Question")]
        private IWebElement EleLinkGlobalQuestion { get; set; }

        /// <summary>
        /// Click on Global Question Link
        /// </summary>
        public void LinkGlobalQuestion()
        {
            EleLinkGlobalQuestion.Click();
            BaseMethods.InfoLogger("Clicked on Global Questions Link");
        }

        #endregion

        #region ****** Methods
        public void CreateNewChildQuestion(IWebDriver _driver)
        {
            ArrayList list = ExcelData.GetData("GlobalQuestionsData", "GQwithChildQuestions", "Execute", "Yes");
            int Count = list.Count;
            int _actualRowCount = Count / 12;
            int j = 1;
            for (int i = 0; i < _actualRowCount; i++)
            {
                BaseMethods.InfoLogger("Creating Child Question Started");
                // Click on Add New Child Question Link
                LinkAddNewChildQuestion();
                //  Fill the Fileds
                QuestionReference(list[j].ToString());

                BaseMethods.TinyMCEEditor(_driver, GlobalComponentLabel(), list[(j + 1)].ToString());

                BaseMethods.DdlSelectByText(ComponentType(), list[(j + 2)].ToString());
                BaseMethods.InfoLogger("Question Type: " + list[(j + 2)].ToString());

                BaseMethods.DdlSelectByText(AnswerDisplayFormat(), list[(j + 3)].ToString());
                BaseMethods.InfoLogger("Answer Display Format: " + list[(j + 3)].ToString());

                BaseMethods.DdlSelectByText(DataType(), list[(j + 4)].ToString());
                BaseMethods.InfoLogger("Data Type: " + list[(j + 4)].ToString());

                if (list[6].ToString() != "Null")
                {
                    AnswerConfiguration(list[(j + 5)].ToString());
                }

                BaseMethods.NoYesRadioButtons(_driver, ChildIsRequired(), list[(j + 6)].ToString());
                BaseMethods.InfoLogger("Is Required: " + list[(j + 6)].ToString());

                BaseMethods.NoYesRadioButtons(_driver, IsHidden(), list[(j + 7)].ToString());
                BaseMethods.InfoLogger("Is Hidden: " + list[(j + 7)].ToString());

                if (list[(j + 8)].ToString() != "Null")
                {
                    MaxLength(list[(j + 8)].ToString());
                }

                if (ValidationType().Displayed)
                {
                    BaseMethods.DdlSelectByText(ValidationType(), list[(j + 9)].ToString());
                    BaseMethods.InfoLogger("Validation Type: " + list[(j + 9)].ToString());
                }
                GlobalComponentXMLName(list[(j + 10)].ToString());
                ChildSave();
                string ExpectedSucessMsg = "×\r\n>   Child Question configuration updated successfully.   ";
                string ActualSucessMsg = GetAlertMessage();
                Assert.AreEqual(ExpectedSucessMsg, ActualSucessMsg);
                LinkGlobalQuestion();
                j = j + 12;
            }
        }

        #endregion

        #endregion
    }

    public class Edit_Delete_GlobalQtnPage : _04_CreateGlobalQtnPage
    {
        public Edit_Delete_GlobalQtnPage(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Name, Using = "btn_Delete")]
        private IWebElement eleBtnDelete { get; set; }

        public void Delete()
        {
            eleBtnDelete.Click();
            BaseMethods.InfoLogger("Clicked on Delete Button");
        }

        public void EditGlobalQuestion(IWebDriver _driver, string Key, string Sheet, string ConditionValue, string Value)
        {
            _04_GlobalQtnListPage GQP = new _04_GlobalQtnListPage(_driver);
            ArrayList list = ExcelData.GetData(Key, Sheet, ConditionValue, Value);
            int Count = list.Count;
            int _actualRowCount = Count / 8;
            int j = 1;
            for (int i = 0; i < _actualRowCount; i++)
            {
                BaseMethods.InfoLogger("Creating Global 0" + (i + 1) + " Question Started");
                QuestionDetails();
                BaseMethods.DdlSelectByText(eleddlQuestionType, list[j].ToString());
                BaseMethods.InfoLogger("Question Type: " + list[(j)].ToString());
                string[] formTypesList = list[(j + 1)].ToString().Split(',');
                BaseMethods.CtrlKeyDown(_driver);
                for (int k = 0; k < formTypesList.Length; k++)
                {
                    BaseMethods.DdlSelectByText(eleddlFormType, formTypesList[k]);
                    BaseMethods.InfoLogger("Question Use: " + formTypesList[k].ToString());
                }
                BaseMethods.CtrlKeyUp(_driver);
                if (list[(j + 2)].ToString() == "Yes")
                {
                    IsActiveYes();
                }
                else
                {
                    IsActiveNo();
                }
                ReferenceText(list[(j + 3)].ToString(), true);
                ShortQuestionText(list[(j + 4)].ToString());
                BaseMethods.TinyMCEEditor(_driver, eleFrame, list[(j + 5)].ToString());
                Save();
                string ExpectedSucessMsg = "×\r\n>   Global Question configuration updated successfully.   ";
                string ActualSucessMsg = GetAlertMessage();
                BaseMethods.SoftAssertEqual(ExpectedSucessMsg, ActualSucessMsg);
                if (list[j].ToString() == "Group Question")
                {
                    CreateGlobalQueWithOptionsPage ChildQue = new CreateGlobalQueWithOptionsPage(_driver);
                    // Click on Answer Options Tab
                    AnswerOptions();
                    ChildQue.CreateNewChildQuestion(_driver);
                }
                if (list[j].ToString() == "Group Question" || list[j].ToString() == "Multi Select")
                {
                    // Click on Answer Options Tab
                    AnswerOptions();
                    AddNewAnswers(_driver, list[(j + 6)].ToString());
                }

                // Edit the Question
                GlobalQuestionLink();
                _04_GlobalQtnListPage GlbQtnListPage = new _04_GlobalQtnListPage(_driver);
                string SearchKeyword = _QuestionReference.Replace("_PM", "").Replace("_AM", "");
                GlbQtnListPage.SearchKeyword(_QuestionReference);
                GlbQtnListPage.Search();
                BaseMethods.DdlSelectByText(GlbQtnListPage.eleDdlIsActive, "All");
                try
                {
                    IWebElement ele = _driver.FindElement(By.XPath("//div[@class='tableBoundaries']/table/tbody/tr/td[1]/span/../../td[6]/span[1]"));
                    ele.Click();
                    QuestionDetails();
                    
                    if (elerdoIsActiveYES.Selected)
                    {
                        IsActiveNo();
                    }
                    else
                    {
                        IsActiveYes();
                    }                    
                    ReferenceText("Edit_Question Reference Edited", true);
                    ShortQuestionText("Edit_Short Question Edited");
                    BaseMethods.TinyMCEEditor(_driver, eleFrame, "Global Question Editior Text Modified");
                    BaseMethods.PageScrollDown(_driver);
                    Save();
                    string EditExpectedSucessMsg = "×\r\n>   Global Question configuration updated successfully.   ";
                    string EditActualSucessMsg = GetAlertMessage();
                    BaseMethods.SoftAssertEqual(EditExpectedSucessMsg, EditActualSucessMsg);
                    ExcelData.InsertData("GlobalQuestionsData", "Delete_GlobalQuestion", "Question_Reference", _QuestionReference);
                }
                catch (Exception ex)
                {
                    Logger.log.Info("No Records Found to Edit" + ex.Message);
                    ExtentReport.test.Log(LogStatus.Fatal, "No Records Found to Edit");
                }
                j = j + 8;
                GlobalQuestionLink();
                GQP.CreateNewGlbQtn();
            }
        }

        public void DeleteGlobalQuestions(IWebDriver _driver, string Key, string Sheet)
        {
            ArrayList list = ExcelData.GetData(Key, Sheet);
            int Count = list.Count;
            for (int i = 0; i < Count; i++)
            {
                BaseMethods.InfoLogger("Deleting Global 0" + (i + 1) + " Question Started");
                _04_GlobalQtnListPage GlbQtnListPage = new _04_GlobalQtnListPage(_driver);
                if (list[i].ToString() != "EnterQuestionName")
                {
                    GlbQtnListPage.SearchKeyword(list[i].ToString());
                    GlbQtnListPage.Search();
                    BaseMethods.DdlSelectByText(GlbQtnListPage.eleDdlIsActive, "All");
                    try
                    {
                        IWebElement ele = _driver.FindElement(By.XPath("//div[@class='tableBoundaries']/table/tbody/tr/td[1]/span/../../td[6]/span[2]"));
                        ele.Click();
                        Delete();
                        string DeleteExpectedSucessMsg = "×\r\n>   Global Question deleted successfully.   ";
                        string DeleteActualSucessMsg = GetAlertMessage();
                        BaseMethods.SoftAssertEqual(DeleteExpectedSucessMsg, DeleteActualSucessMsg);
                        ExcelData.UpdateData("GlobalQuestionsData", "Delete_GlobalQuestion", "Question_Reference", "EnterQuestionName", "Question_Reference", list[i].ToString());
                    }
                    catch (Exception ex)
                    {
                        Logger.log.Info("No Records Found to Delete" + ex.Message);
                        ExtentReport.test.Log(LogStatus.Fatal, "No Records Found to Delete");
                    }
                }
                else
                {
                    BaseMethods.InfoLogger("Question name is not provided. Skipping this..");
                }
            }
        }
    }

}

