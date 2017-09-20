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
    public class AddQuestiontoStepPage
    {
        static IWebDriver driver;
        public AddQuestiontoStepPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "QuestionReference")]
        private IWebElement eletxtQuestionReference { get; set; }

        /// <summary>
        /// Enter data in Reference Text Field
        /// </summary>
        /// <param name="value">Enter the Value</param>
        /// <param name="_date">True or False (If true, current system date will be added to the Value)</param>
        public void ReferenceText(string value, bool _date)
        {
            string CurrentDate = Convert.ToString(DateTime.Now);
            string ShortDate = CurrentDate.Replace("/", "_").Replace(":", "_").Replace(" ", "_");

            if (_date == true)
            {
                value += ShortDate;
                eletxtQuestionReference.SendKeys(value);
                BaseMethods.InfoLogger("Entered Refernce Text: " + value);
            }
            else
            {
                eletxtQuestionReference.SendKeys(value);
                BaseMethods.InfoLogger("Entered Refernce Text: " + value);
            }
        }

        [FindsBy(How = How.Id, Using = "ComponentTypeID")]
        private IWebElement eleddlQuestionType { get; set; }

        [FindsBy(How = How.Id, Using = "AnswerFormat")]
        private IWebElement eleddlAnswerformat { get; set; }

        [FindsBy(How = How.Id, Using = "DataType")]
        private IWebElement eleddldatatype { get; set; }

        [FindsBy(How = How.Id, Using = "MaxLength")]
        private IWebElement eletxtMaxLength { get; set; }

        public void EnterMaxLength(string value)
        {
            eletxtMaxLength.Clear();
            eletxtMaxLength.SendKeys(value);
            BaseMethods.InfoLogger("Entered Max Length: " + value);
        }

        [FindsBy(How = How.Id, Using = "MaxLengthType")]
        private IWebElement eleddlMaxLengthType { get; set; }

        [FindsBy(How = How.Id, Using = "componentValidationTypeID")]
        private IWebElement eleddlcomponentValidationTypeID { get; set; }

        [FindsBy(How = How.Id, Using = "QuestionLabel_ifr")]
        public IWebElement eletxtQuestion { get; set; }

        [FindsBy(How = How.Name, Using = "btn_Save")]
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
            BaseMethods.ExplicitWait(driver, "//div[@class='alert alert-warning']");
            string msg = eleSuccessMsg.Text;
            BaseMethods.InfoLogger("Div Alert Message is: " + msg);
            return msg;
        }

        public void AddQuestion(IWebDriver _driver, int EleValue, string Key, string Sheet, string StepNum)
        {
            _05_FormTemplateCreationPage FormTempCreaPage = new _05_FormTemplateCreationPage(_driver);
            ArrayList SingleRowData = null;
            if (Key == "UserDetailsFormData")
            {
                SingleRowData = ExcelData.GetData(Key, Sheet, "Execute", "Yes");
            }
            else
            {
                SingleRowData = ExcelData.GetData(Key, Sheet, "StepNumber", StepNum);
            }
            int Count = SingleRowData.Count;
            Count = Count / 8;
            int j = 1;
            BaseMethods.PageScrollDown(_driver);
            for (int i = 1; i <= Count; i++)
            {
                IList<IWebElement> elements = FormTempCreaPage.QuestionEleList(_driver);
                elements[EleValue].Click();
                BaseMethods.InfoLogger("Add Question To Step Started");
                if (Key == "RequisitionProcessTemplateData")
                {
                    ReferenceText(SingleRowData[j].ToString(), false);
                }
                else
                {
                    ReferenceText(SingleRowData[j].ToString(), true);
                }
                BaseMethods.DdlSelectByText(eleddlQuestionType, SingleRowData[j + 1].ToString());
                BaseMethods.InfoLogger("Question Type is: " + SingleRowData[j + 1].ToString());
                BaseMethods.SleepTimeOut(1000);
                BaseMethods.DdlSelectByText(eleddlAnswerformat, SingleRowData[j + 2].ToString());
                BaseMethods.InfoLogger("Answer Format is: " + SingleRowData[j + 2].ToString());
                BaseMethods.SleepTimeOut(1000);
                BaseMethods.DdlSelectByText(eleddldatatype, SingleRowData[j + 3].ToString());
                BaseMethods.InfoLogger("Data Type is: " + SingleRowData[j + 3].ToString());

                if (SingleRowData[j + 1].ToString() == "Free Text")
                {
                    EnterMaxLength(SingleRowData[j + 4].ToString());
                    BaseMethods.DdlSelectByText(eleddlMaxLengthType, SingleRowData[j + 5].ToString());
                    BaseMethods.InfoLogger("Max Length is: " + SingleRowData[j + 5].ToString());
                }
                BaseMethods.TinyMCEEditor(_driver, eletxtQuestion, SingleRowData[j + 6].ToString());
                Save();
                string ExpectedMsg = "×\r\n>   Question saved successfully.   ";
                string ActualMsg = GetAlertMessage();
                BaseMethods.SoftAssertEqual(ExpectedMsg, ActualMsg);

                BaseMethods.Navigate_Back(_driver);
                BaseMethods.Navigate_Back(_driver);
                j += 8;
            }
        }
    }
}
