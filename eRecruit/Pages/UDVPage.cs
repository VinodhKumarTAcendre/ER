using eRecruit.Library.Extent_Reports;
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


namespace eRecruit.Pages
{
    public class UDVPage
    {
        public UDVPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//button[@type='button'])[2]")]
        private IWebElement elecloseFeedBackWindow { get; set; }

        public void CloseFeedBack()
        {
            elecloseFeedBackWindow.Click();
            Logger.log.Info("Clicked On Feddback Close Icon");
            ExtentReport.test.Log(LogStatus.Info, "Clicked On Feddback Close Icon");

        }

        [FindsBy(How = How.Name, Using = "UDViewTypeID")]
        private IWebElement eleDropDownNewUserDefinedType { get; set; }

        public IWebElement UdvType()
        {
            return eleDropDownNewUserDefinedType;
        }

        [FindsBy(How = How.Name, Using = "btn_Go")]
        private IWebElement eleBtnGo { get; set; }

        private void ButtonGo()
        {
            eleBtnGo.Click();
            Logger.log.Info("Clicked on Go Button");
            ExtentReport.test.Log(LogStatus.Info, "C;licked On Go Button");

        }

        [FindsBy(How = How.Name, Using = "UDViewName")]
        private IWebElement eletxtName { get; set; }


        /// <summary>
        /// UDV  Name
        /// </summary>
        /// <param name="Value">Name</param>
        public void FormName(string Value)
        {
            eletxtName.SendKeys(Value);
            Logger.log.Info("Entered UDV Name: " + Value);
            ExtentReport.test.Log(LogStatus.Info, "Entered UDV Name: " + Value);
        }


        
        [FindsBy(How = How.Id, Using = "isActive")]
        private IWebElement eleBtnActive { get; set; }
        public void UdvStatus(bool Value)
        {
            string boolValue = null;
            eletxtName.SendKeys(boolValue);
            Logger.log.Info("Entered UDV status");
            ExtentReport.test.Log(LogStatus.Info, "Entered UDV status" );
        }



        [FindsBy(How = How.Name, Using = "btn_Save")]
        private IWebElement eleBtnSave { get; set; }

        public void SaveBtn()
        {
            eleBtnSave.Click();
            Logger.log.Info("Clicked On Save Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked On Save Button");


        }



        [FindsBy(How = How.Name, Using = "Cancel")]
        private IWebElement eleBtnCancel { get; set; }

        public void CancelBtn()
        {
            eleBtnCancel.Click();
            Logger.log.Info("Clicked On Cancel Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked On Cancel Button");


        }


        [FindsBy(How = How.Name, Using = "UDViewElementUsed")]
        private IWebElement eleBtnCheckbox { get; set; }

        public void CheckBtn()
        {
            eleBtnCheckbox.Click();
            Logger.log.Info("Clicked On Check box Button");
            ExtentReport.test.Log(LogStatus.Info, "Clicked On Check box Button");


        }


    }
}