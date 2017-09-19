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
    public class _05_FormTemplateCreationPage
    {
        public _05_FormTemplateCreationPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.Name, Using = "FormTypeID")]
        private IWebElement eleddlFormTypeID { get; set; }
        /// <summary>
        /// Get Form Type Web Element
        /// </summary>
        /// <returns></returns>
        public IWebElement FormType()
        {
            return eleddlFormTypeID;
        }



        [FindsBy(How = How.LinkText, Using = "Form List")]
        private IWebElement eleLinkFormList { get; set; }

        public void LinkFormList()
        {
            eleLinkFormList.Click();
            BaseMethods.InfoLogger("Clicked on Form List Link");
        }

        [FindsBy(How = How.Name, Using = "FormName")]
        public IWebElement eletxtFormName { get; set; }
        /// <summary>
        /// Form Template Name
        /// </summary>
        /// <param name="Value">Name</param>
        public void FormName(string Value)
        {
            eletxtFormName.Clear();
            eletxtFormName.SendKeys(Value);
            BaseMethods.InfoLogger("Entered Form Template Name: " + Value);
        }

        [FindsBy(How = How.Name, Using = "templateIsActive")]
        private IWebElement eleddltemplateIsActive { get; set; }
        /// <summary>
        /// Get Form Status Web Element
        /// </summary>
        /// <returns></returns>
        public IWebElement FormStatus()
        {
            return eleddltemplateIsActive;
        }

        [FindsBy(How = How.Name, Using = "Save")]
        private IWebElement elebtnSave { get; set; }

        /// <summary>
        /// Save Form Template
        /// </summary>
        public void SaveFormTemplate()
        {
            elebtnSave.Click();
            BaseMethods.InfoLogger("Clicked on Save Button");
        }

        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement elebtnCancel { get; set; }

        /// <summary>
        /// Cancel Form Template
        /// </summary>
        public void CancelFormTemplate()
        {
            elebtnCancel.Click();
            BaseMethods.InfoLogger("Clicked on Cancel Button");
        }

        [FindsBy(How = How.LinkText, Using = "Add New Form Step")]
        private IWebElement eleAddNewFormSteplink { get; set; }

        /// <summary>
        /// Add New Form Step
        /// </summary>
        public void AddNewFormStep()
        {
            eleAddNewFormSteplink.Click();
            BaseMethods.InfoLogger("Clicked on Add New Form Step Link");
        }

        [FindsBy(How = How.Name, Using = "StepTitle")]
        private IWebElement eletxtsteptitle { get; set; }

        public void StepTitle(string Value)
        {
            eletxtsteptitle.Clear();
            eletxtsteptitle.SendKeys(Value);
            BaseMethods.InfoLogger("Entered step Title: " + Value);
        }

        [FindsBy(How = How.Id, Using = "StepDescription_ifr")]
        private IWebElement eleStepDescription { get; set; }

        public IWebElement StepDescription()
        {
            return eleStepDescription;
        }

        [FindsBy(How = How.Id, Using = "labelWidthType1")]
        private IWebElement eleradioSystemDefault { get; set; }

        public void SystemDefaultQuestionLabelWidth()
        {
            eleradioSystemDefault.Click();
        }

        [FindsBy(How = How.Id, Using = "labelWidthType2")]
        private IWebElement eleradioCustomPixel { get; set; }

        public void CustomPixelQuestionLabelWidth()
        {
            eleradioCustomPixel.Click();
            BaseMethods.InfoLogger("Question Label Width : Custom Pixel");
        }

        [FindsBy(How = How.Id, Using = "labelWidthType3")]
        private IWebElement eleradioCustomPercentage { get; set; }

        public void CustomPercentageQuestionLabelWidth()
        {
            eleradioCustomPercentage.Click();
            BaseMethods.InfoLogger("Question Label Width : Custom Percentage");
        }

        [FindsBy(How = How.Name, Using = "btnSubmit")]
        private IWebElement elebtnsave { get; set; }

        /// <summary>
        /// Save Form Step
        /// </summary>
        public void SaveStepdetails()
        {
            elebtnsave.Click();
            BaseMethods.InfoLogger("Clicked on Save Button");
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleSuccessMsg { get; set; }
        public string GetAlertMessage()
        {
            string msg = eleSuccessMsg.Text;
            BaseMethods.InfoLogger("Div Alert Message is: " + msg);
            return msg;
        }

        /// <summary>
        /// Cancel Form Step
        /// </summary>
        public void CancelStepdetails()
        {
            elebtnCancel.Click();
            BaseMethods.InfoLogger("Clicked on Cancel Button");
        }

        [FindsBy(How = How.Name, Using = "btn_Delete")]
        private IWebElement eleBtnDelete { get; set; }

        public void Delete()
        {
            eleBtnDelete.Click();
            BaseMethods.InfoLogger("Clicked on Delete Button");
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleDivAlertMsg { get; set; }

        /// <summary>
        /// Alert Message after adding a Form Step
        /// </summary>
        /// <returns>Message</returns>
        public string DivAlertMsg()
        {
            return eleDivAlertMsg.Text;
        }

        [FindsBy(How = How.LinkText, Using = "Preview Form")]
        private IWebElement elePreviewForm { get; set; }

        /// <summary>
        /// Preview Form will be opened. Control will be switched to Preview Form Window
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public void OpenPreviewForm(IWebDriver _driver)
        {
            elePreviewForm.Click();
            BaseMethods.InfoLogger("Clicked on Preview Form Button");
            string newTabHandle = _driver.WindowHandles.Last();
            var newTab = _driver.SwitchTo().Window(newTabHandle);
            BaseMethods.InfoLogger("Switched to Preview Form Window");
        }

        [FindsBy(How = How.Id, Using = "Close")]
        private IWebElement eleClosePreviewForm { get; set; }

        /// <summary>
        /// Preview Form will be Closed. Control will be switched to Main Window
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public void ClosePreviewForm(IWebDriver _driver)
        {
            eleClosePreviewForm.Click();
            BaseMethods.InfoLogger("Clicked on Close Button in Preview From");
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            BaseMethods.InfoLogger("Switched to Main Window");
        }

        string _FormType = null, _FormName = null, _FormStatus = null;
        /// <summary>
        /// Get Form Details From Excel
        /// </summary>
        /// <param name="FormName">Form Name</param>
        /// <returns>Array List</returns>
        public ArrayList GetFormDetails(string ConfigKey, string Sheet, string ConditionKey, string FormName)
        {
            ArrayList list = ExcelData.GetData(ConfigKey, Sheet, ConditionKey, FormName);
            _FormType = list[0].ToString();
            _FormName = list[1].ToString();
            _FormStatus = list[2].ToString();
            return list;
        }

        #region Code not in use

        /// <summary>
        /// Create Single Step for Form Template
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="_StepTitle">Step Title</param>
        /// <param name="_StepDescription">Step Description</param>
        /// <param name="_LableWidth">Question Label Width</param>
        //public void CreateSingleStep(IWebDriver _driver, string _StepTitle, string _StepDescription, string _LableWidth)
        //{
        //    AddNewFormStep();
        //    StepTitle(_StepTitle);
        //    BaseMethods.TinyMCEEditor(_driver, StepDescription(), _StepDescription);
        //    BaseMethods.PageScrollDown(_driver);
        //    QuestionLabelWidth(_driver, _LableWidth);
        //    SaveStepdetails();
        //    Logger.log.Info("Step has been added to Form Template");
        //    ExtentReport.test.Log(LogStatus.Pass, "Step has been added to Form Template");
        //}

        #endregion

        /// <summary>
        /// Create Multiple Steps for Form Template
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public void CreateMultipleSteps(IWebDriver _driver, string ConfigKey, string Sheet, string ConditionKey)
        {
            ArrayList list = null;
            if (ConfigKey == "PositionDetailsFormData")
            {
                list = ExcelData.GetData(ConfigKey, Sheet, ConditionKey, "Yes");
            }
            else
            {
                list = ExcelData.GetData(ConfigKey, Sheet, ConditionKey, _FormType);
            }
            if (list != null)
            {
                int _Count = list.Count;
                int _actualRowCount = _Count / 4;
                int j = 1;
                for (int i = 1; i <= _actualRowCount; i++)
                {
                    AddNewFormStep();
                    StepTitle(list[j].ToString());
                    BaseMethods.TinyMCEEditor(_driver, StepDescription(), list[j + 1].ToString());
                    BaseMethods.PageScrollDown(_driver);
                    QuestionLabelWidth(_driver, list[j + 2].ToString());
                    SaveStepdetails();
                    BaseMethods.InfoLogger("Step has been added successfully");
                    j = j + 4;
                }
            }

        }

        [FindsBy(How = How.Id, Using = "slider")]
        private IWebElement eleSlider { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='slider']/span")]
        private IWebElement eleSlide { get; set; }

        /// <summary>
        /// Question Label Width with Slider Actions
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="Value">Option</param>
        public void QuestionLabelWidth(IWebDriver _driver, string Value)
        {
            if (Value == "Custom Pixel Width")
            {
                CustomPixelQuestionLabelWidth();
                BaseMethods.SleepTimeOut(5000);
                int WidthSliderBar = eleSlider.Size.Width;
                Actions action = new Actions(_driver);
                action.ClickAndHold(eleSlide);
                action.MoveByOffset(50, 50).Build().Perform();
                action.Release();
            }
            else if (Value == "Custom Percentage Width")
            {
                CustomPercentageQuestionLabelWidth();
                BaseMethods.SleepTimeOut(5000);
                int WidthSliderBar = eleSlider.Size.Width;
                Actions action = new Actions(_driver);
                action.ClickAndHold(eleSlide);
                action.MoveByOffset(50, 50).Build().Perform();
                action.Release();
            }
            else
            {
                BaseMethods.InfoLogger("Question Label Width : System Default");
            }
        }

        /// <summary>
        /// Add Local Question to Step
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        public void AddQuestionToStep(IWebDriver _driver, string ConfigKey, string Sheet)
        {
            AddQuestiontoStepPage AQS = new AddQuestiontoStepPage(_driver);

            IList<IWebElement> eleList = QuestionEleList(_driver);
            for (int i = 0; i < eleList.Count; i++)
            {
                IWebElement ele = eleList[i];
                if (_FormType == "Pre Application Form")
                {
                    AQS.AddQuestion(_driver, i, ConfigKey, "PreApplicationFormLocalQue", (i + 1).ToString());
                }
                else
                {
                    AQS.AddQuestion(_driver, i, ConfigKey, Sheet, (i + 1).ToString());
                }
            }
        }

        /// <summary>
        /// Gets Add a Question to Step Elements
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <returns>List of IWebElements</returns>
        public IList<IWebElement> QuestionEleList(IWebDriver _driver)
        {
            IList<IWebElement> eleList = _driver.FindElements(By.XPath("//a[@class='addQuestion']"));
            return eleList;
        }

        public void AddGlobalQuestionToStep(IWebDriver _driver, string ConfigKey, string SheetName)
        {
            _04_SearchGlobalQuestionPage SGQ = new _04_SearchGlobalQuestionPage(_driver);

            IList<IWebElement> eleList = GlobalQuestionEleList(_driver);
            for (int i = 0; i < eleList.Count; i++)
            {
                IWebElement ele = eleList[i];
                if (_FormType == "Pre Application Form")
                {
                    SGQ.AddGlobalQuestion(_driver, i, ConfigKey, "PreApplicationFormGlobalQue", (i + 1).ToString());
                }
                else
                {
                    SGQ.AddGlobalQuestion(_driver, i, ConfigKey, SheetName, (i + 1).ToString());
                }
            }
        }

        public IList<IWebElement> GlobalQuestionEleList(IWebDriver _driver)
        {
            IList<IWebElement> eleList = _driver.FindElements(By.XPath("//a[@class='addGlobal']"));
            return eleList;
        }


        // ****************************   Editing Form Template

        public void Edit_AddQuestionToStep(IWebDriver _driver)
        {
            AddQuestiontoStepPage AQS = new AddQuestiontoStepPage(_driver);

            IList<IWebElement> eleList = QuestionEleList(_driver);
            for (int i = 0; i < eleList.Count; i++)
            {
                IWebElement ele = eleList[i];
                if (_FormType == "Pre Application Form")
                {
                    AQS.AddQuestion(_driver, i, "FormTemplatesData", "Edit_PreApplicationFormLocalQue", (i + 1).ToString());
                }
                else
                {
                    AQS.AddQuestion(_driver, i, "FormTemplatesData", "Edit_AddQuestiontoStep", (i + 1).ToString());
                }
            }
        }

        public void Edit_Delete_FormTemplate(IWebDriver _driver)
        {
            string _EditFormName = eletxtFormName.GetAttribute("Value");
            LinkFormList();
            IWebElement ele = _driver.FindElement(By.XPath("//div[@class='tableBoundaries']/table/tbody[1]/tr[2]/td[5]/select"));
            BaseMethods.DdlSelectByText(ele, "All");
            BaseMethods.SleepTimeOut(4000);
            #region Edit the Form
            try
            {
                string _xpath = "//td[text()='" + _EditFormName + "']/../td[6]/span[1]";
                IWebElement EditLink = _driver.FindElement(By.XPath(_xpath));
                EditLink.Click();
                BaseMethods.InfoLogger("Clicked on Form Edit Link");
                _EditFormName = "Edit_" + _EditFormName;
                FormName(_EditFormName);
                SaveFormTemplate();

            }
            catch (NoSuchElementException ex)
            {
                ExtentReport.test.Log(LogStatus.Fatal, "Failed to Edit the Form.");
                Logger.log.Info(ex.Message);
            }
            #endregion

            #region Edit the Step
            try
            {
                IWebElement eleStepEdit = _driver.FindElement(By.XPath("(//div[@class='formStepHeader']/span)[2]/a"));
                eleStepEdit.Click();
                BaseMethods.InfoLogger("Clicked on Step Edit Link");
                StepTitle("Edit_Step_Title_Auto");
                BaseMethods.TinyMCEEditor(_driver, StepDescription(), "Entered Step Description");
                BaseMethods.PageScrollDown(_driver);
                QuestionLabelWidth(_driver, "System Default");
                SaveStepdetails();
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
                IWebElement EditQueEle = _driver.FindElement(By.XPath("//div[@class='formStepArea']/ul/li[1]/div[4]/span[1]"));
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
                IWebElement DeleteQueEleText = _driver.FindElement(By.XPath("//div[@class='formStepArea']/ul/li[1]/div[3]/strong"));
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
                IWebElement eleStepDelete = _driver.FindElement(By.XPath("(//div[@class='formStepHeader']/span)[3]/span/a"));
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

            #region Preview the Form Template
            try
            {
                string ParentWindow = _driver.CurrentWindowHandle;
                LinkFormList();
                IWebElement Preview = _driver.FindElement(By.XPath("//div[@class='tableBoundaries']/table/tbody[1]/tr[2]/td[5]/select"));
                BaseMethods.DdlSelectByText(Preview, "All");
                BaseMethods.SleepTimeOut(4000);
                string _Prexpath = "//td[text()='" + _EditFormName + "']/../td[6]/a";
                IWebElement PreviewLink = _driver.FindElement(By.XPath(_Prexpath));
                PreviewLink.Click();
                BaseMethods.InfoLogger("Clicked on Form Preview Link");
                IList<string> AllWindowHandles = _driver.WindowHandles;
                if (AllWindowHandles.Count > 1)
                {
                    BaseMethods.InfoLogger("Preview has been verified");
                }
                _driver.SwitchTo().Window(AllWindowHandles[1]);
                _driver.Close();
                _driver.SwitchTo().Window(ParentWindow);
            }
            catch (NoSuchWindowException ex)
            {
                ExtentReport.test.Log(LogStatus.Fatal, "Preview Form was not Displayed");
                Logger.log.Info(ex.Message);
            }
            #endregion

            #region Delete the Form Template
            try
            {
                //LinkFormList();
                IWebElement Delele = _driver.FindElement(By.XPath("//div[@class='tableBoundaries']/table/tbody[1]/tr[2]/td[5]/select"));
                BaseMethods.DdlSelectByText(Delele, "All");
                BaseMethods.SleepTimeOut(4000);
                string _Delxpath = "//td[text()='" + _EditFormName + "']/../td[6]/span[3]";
                IWebElement DeleteLink = _driver.FindElement(By.XPath(_Delxpath));
                DeleteLink.Click();
                BaseMethods.InfoLogger("Clicked on Form Delete Link");
                Delete();
                string FormDeleteExpectedMsg = "×\r\n>   The Form " + _EditFormName + " has been deleted.   ";
                string FormDeleteActualMsg = GetAlertMessage();
                BaseMethods.SoftAssertEqual(FormDeleteExpectedMsg, FormDeleteActualMsg);
                BaseMethods.InfoLogger("Step has been Successfully Deleted");
            }
            catch (NoSuchElementException ex)
            {
                ExtentReport.test.Log(LogStatus.Fatal, "Failed to Delete the Form.");
                Logger.log.Info(ex.Message);
            }
            #endregion
        }
    }
}
