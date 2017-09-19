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
    public class _04_SearchGlobalQuestionPage
    {
        public _04_SearchGlobalQuestionPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.Name, Using = "Keywords1")]
        private IWebElement eletxtkeywords { get; set; }

        public void SearchKeyword(string Value)
        {
            eletxtkeywords.Clear();
            eletxtkeywords.SendKeys(Value);
            BaseMethods.InfoLogger("Global Question Search KeyWord : " + Value);
        }

        [FindsBy(How = How.XPath, Using = "(//input[@name='btn_Search'])[1]")]
        private IWebElement elebtnSearch { get; set; }

        public void Search()
        {
            elebtnSearch.Click();
            BaseMethods.InfoLogger("Clicked on Search Button");
        }

        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement elebtnCancel { get; set; }

        public void Cancel()
        {
            elebtnCancel.Click();
            BaseMethods.InfoLogger("Clicked on Cancel Button");
        }


        [FindsBy(How = How.Name, Using = "ctrlSelectAllInPage")]
        private IWebElement elebtnCheckBox { get; set; }

        public void ClickonCheckBox()
        {
            elebtnCheckBox.Click();
            BaseMethods.InfoLogger("Clicked on Check Box");
        }



        [FindsBy(How = How.LinkText, Using = "Show advanced search")]
        private IWebElement elebtnShowAdvanceSearch { get; set; }

        public void ShowAdvancedSearch()
        {
            elebtnShowAdvanceSearch.Click();
            BaseMethods.InfoLogger("Clicked on Show Advanced Search Button");
        }

        [FindsBy(How = How.Name, Using = "btn_Add")]
        private IWebElement elebtnadd { get; set; }

        public void AddGlobalQuestion()
        {
            elebtnadd.Click();
            BaseMethods.InfoLogger("Clicked on Add Button");
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-warning']")]
        private IWebElement eleSuccessMsg { get; set; }
        public string GetAlertMessage()
        {
            string msg = eleSuccessMsg.Text;
            BaseMethods.InfoLogger("Div Alert Message is: " + msg);
            return msg;
        }

        public IWebElement GlobalQueElement(IWebDriver _driver, string QuestionText)
        {
            IList<IWebElement> eleList = _driver.FindElements(By.XPath("//input[@name='itemID']"));

            for (int i = 0; i <= eleList.Count; i++)
            {
                string _tempXpath = "//input[@name='itemID']/../../../tr[" + (i + 1) + " ]/td[5]";
                try
                {
                    IWebElement ele = _driver.FindElement(By.XPath(_tempXpath));
                    if (ele != null)
                    {
                        string _QueText = ele.Text;
                        if (_QueText == QuestionText)
                        {
                            return eleList[i];
                        }
                    }
                }
                catch (NoSuchElementException ex)
                {
                    BaseMethods.InfoLogger("No Such Element exception. XPATH is " + _tempXpath);
                    Logger.log.Info(ex.Message);
                }
            }
            return null;
        }


        [FindsBy(How = How.Id, Using = "TB_iframeContent")]
        private IWebElement eleConfigComFrame { get; set; }

        [FindsBy(How = How.Id, Using = "TB_closeWindowButton")]
        private IWebElement eleConfigComFrameClose { get; set; }

        public void AddGlobalQuestion(IWebDriver _driver, int EleValue, string Key, string Sheet, string StepNum)
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
            Count = Count / 3;
            int j = 1;
            BaseMethods.PageScrollDown(_driver);
            for (int i = 1; i <= Count; i++)
            {
                BaseMethods.SleepTimeOut(3000);
                IList<IWebElement> elements = FormTempCreaPage.GlobalQuestionEleList(_driver);
                if (i == 1)
                    BaseMethods.PartialPageScrollDown(_driver);
                else
                    BaseMethods.PageScrollDown(_driver);
                BaseMethods.ScrollToView(_driver, elements[EleValue]);
                elements[EleValue].Click();
                BaseMethods.SleepTimeOut(2000);
                BaseMethods.InfoLogger("Add Global Question To Step Started");
                SearchKeyword(SingleRowData[j].ToString());
                Search();
                BaseMethods.PageScrollDown(_driver);
                IWebElement ele = GlobalQueElement(_driver, SingleRowData[j + 1].ToString());
                if (ele != null)
                {
                    ele.Click();
                    BaseMethods.InfoLogger("Selecting the Global Question");
                    AddGlobalQuestion();
                    BaseMethods.SleepTimeOut(3000);
                }
                else
                {
                    BaseMethods.InfoLogger("No results found. Global Question is not added");
                    Cancel();
                }
                j += 3;
            }
        }

    }
}










