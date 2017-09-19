using eRecruit.Library.Extent_Reports;
using eRecruit.Library.Log4Net;
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
    public class _04_GlobalQtnListPage
    {
        public _04_GlobalQtnListPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Create New Global Question')]")]
        private IWebElement elelnkCreateNewGlbQtn { get; set; }

        public void CreateNewGlbQtn()
        {
            elelnkCreateNewGlbQtn.Click();
            Logger.log.Info("Clicked on Create New Global Question Link button");
            ExtentReport.test.Log(LogStatus.Info, "Manage Global question page opened");
        }

        [FindsBy(How = How.Name, Using = "Keywords1")]
        private IWebElement eletxtkeywords1 { get; set; }

        public void SearchKeyword(string Value)
        {
            eletxtkeywords1.Clear();
            eletxtkeywords1.SendKeys(Value);
            Logger.log.Info("Global Question Search KeyWord : " + Value);
            ExtentReport.test.Log(LogStatus.Info, "Global Question Search KeyWord : " + Value);
        }

        [FindsBy(How = How.Name, Using = "Keywords2")]
        private IWebElement eletxtkeywords2 { get; set; }

        public void SecondSearchKeyword(string Value)
        {
            eletxtkeywords2.Clear();
            eletxtkeywords2.SendKeys(Value);
            Logger.log.Info("Global Question Second Search KeyWord : " + Value);
            ExtentReport.test.Log(LogStatus.Info, "Global Question Second Search KeyWord : " + Value);
        }

        [FindsBy(How = How.Name, Using = "Keywords3")]
        private IWebElement eletxtkeywords3 { get; set; }

        public void ThirdSearchKeyword(string Value)
        {
            eletxtkeywords3.Clear();
            eletxtkeywords3.SendKeys(Value);
            Logger.log.Info("Global Question Third Search KeyWord : " + Value);
            ExtentReport.test.Log(LogStatus.Info, "Global Question Third Search KeyWord : " + Value);
        }

        [FindsBy(How = How.XPath, Using = "(//input[@name='btn_Search'])[1]")]
        private IWebElement elebtnSearch { get; set; }

        public void Search()
        {
            elebtnSearch.Click();
            Logger.log.Info("Clicked on Search Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked on Search Button");
        }

        [FindsBy(How = How.XPath, Using = " //div[@id='rowCountBar']/div/div/div[2]/strong")]
        private IWebElement eleRecordsFoundResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='rowCountBar']/div/div/div[2]/strong[3]")]
        private IWebElement eleRecordsFound { get; set; }

        public int RecordsFound()
        {
            if (eleRecordsFoundResult.Displayed && eleRecordsFound.Text == "No records to display")
            {
                Logger.log.Info("No records to display");
                ExtentReport.test.Log(LogStatus.Info, "No records to display");
            }
            else
            {
                int Count = Convert.ToInt32(eleRecordsFound.Text);
                Logger.log.Info("Search Records Found: " + eleRecordsFound.Text);
                ExtentReport.test.Log(LogStatus.Info, "Search Records Found: " + eleRecordsFound.Text);
                return Count;
            }
            return 0;
        }

        [FindsBy(How = How.Name, Using = "Type")]
        public IWebElement eleDdlType { get; set; }

        [FindsBy(How = How.Name, Using = "IsActive")]
        public IWebElement eleDdlIsActive { get; set; }


        /// <summary>
        /// Gets the Global Question Search results
        /// </summary>
        /// <param name="_driver">IWebDriver</param>
        /// <param name="ReferenceText">Question Reference Text</param>
        /// <param name="QuestionText">Question Text</param>
        /// <param name="Type">Question Type</param>
        /// <param name="Date">Question Created Date</param>
        /// <param name="Active">Question IsActive</param>
        /// <returns>List of Question Details (ArrayList)</returns>
        public ArrayList GlobalQueElementResults(IWebDriver _driver, string ReferenceText, string QuestionText, string Type, string Date, string Active)
        {
            bool flag = false;
            string _Mxpath = string.Empty;
            IList<IWebElement> eleList;
            int RCount = RecordsFound();
            if (RCount > 1)
            {
                eleList = _driver.FindElements(By.XPath("//div[@class='tableBoundaries']/table/tbody[2]/tr/td[1]/span/../../td[1]"));
                _Mxpath = "//div[@class='tableBoundaries']/table/tbody[2]/tr";
                flag = true;
            }
            else
            {
                eleList = _driver.FindElements(By.XPath("//div[@class='tableBoundaries']/table/tbody/tr/td[1]/span/../../td[1]"));
                _Mxpath = "//div[@class='tableBoundaries']/table/tbody/tr/";
            }
            for (int i = 0; i < eleList.Count; i++)
            {
                string _Mainxpath;
                if (flag == true)
                {
                    _Mainxpath = _Mxpath + "[" + (i + 1) + "] /";
                }
                else
                {
                    _Mainxpath = _Mxpath;
                }

                ArrayList list = new ArrayList();
                string _tempXpath = _Mainxpath + "td[1]/span/../../td[1]";
                try
                {
                    IWebElement ele = _driver.FindElement(By.XPath(_tempXpath));
                    if (ele != null)
                    {
                        string _ReferenceText = ele.Text;
                        if (_ReferenceText == ReferenceText)
                        {
                            string _tempXpath01 = _Mainxpath + "td[1]/span/../../td[2]";
                            IWebElement ele01 = _driver.FindElement(By.XPath(_tempXpath01));
                            if (ele01 != null)
                            {
                                string _QueText = ele01.Text;
                                if (_QueText == QuestionText)
                                {
                                    string _tempXpath02 = _Mainxpath + "td[1]/span/../../td[3]";
                                    IWebElement ele02 = _driver.FindElement(By.XPath(_tempXpath02));
                                    if (ele02 != null)
                                    {
                                        string _QueType = ele02.Text;
                                        if (_QueType == Type)
                                        {
                                            string _tempXpath03 = _Mainxpath + "td[1]/span/../../td[4]";
                                            IWebElement ele03 = _driver.FindElement(By.XPath(_tempXpath03));
                                            string _QueCreated = ele03.Text;
                                            if (_QueCreated == Date)
                                            {
                                                string _tempXpath04 = _Mainxpath + "td[1]/span/../../td[5]";
                                                IWebElement ele04 = _driver.FindElement(By.XPath(_tempXpath04));
                                                if (ele04 != null)
                                                {
                                                    string _QueActive = ele04.Text;
                                                    if (_QueActive == Active)
                                                    {
                                                        list.Add(_ReferenceText);
                                                        list.Add(_QueText);
                                                        list.Add(_QueType);
                                                        list.Add(_QueCreated);
                                                        list.Add(_QueActive);
                                                        return list;
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                catch (NoSuchElementException ex)
                {
                    Logger.log.Info("No Such Element exception. XPATH is " + _tempXpath);
                    Logger.log.Info("Exception Message: " + ex.Message);
                }
            }
            return null;
        }



    }
}
