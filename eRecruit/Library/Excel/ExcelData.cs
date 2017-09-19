using eRecruit.Library.Extent_Reports;
using eRecruit.Library.Log4Net;
using RelevantCodes.ExtentReports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRecruit.Library.Excel
{
    public class ExcelData
    {
        /// <summary>
        /// Get Data from Excel sheet
        /// </summary>
        /// <param name="ConfigKey">Mention the Configurtion Key defined in the App.config file</param>
        /// <param name="SheetName">Excel Sheet Name</param>
        /// <param name="ConditionKey">Key value to get the Data from Sheet</param>
        /// <param name="ConditionValue">Value to filter/get the Data</param>
        /// <returns>List of Values</returns>
        public static ArrayList GetData(string ConfigKey, string SheetName, string ConditionKey, string ConditionValue)
        {
            var _ExcelSheetName = ConfigurationManager.AppSettings[ConfigKey];
            string _path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string _actualPath = _path.Substring(0, _path.LastIndexOf("bin"));
            string _projectPath = new Uri(_actualPath).LocalPath;
            string _ExcelFolderPath = _projectPath + "Library\\Excel\\DataFiles\\";
            string fileName = _ExcelFolderPath + _ExcelSheetName;

            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);

            using (var connection = new OleDbConnection(con))
            {
                connection.Open();
                var query = string.Empty;
                ArrayList list = new ArrayList();
                try
                {
                    query = string.Format("select * from [" + SheetName + "$] where " + ConditionKey + "='{0}'", ConditionValue);
                    OleDbCommand oledbCmd = new OleDbCommand(query, connection);
                    OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
                    while (oledbReader.Read())
                    {
                        for (int i = 0; i < oledbReader.VisibleFieldCount; i++)
                        {
                            var data = oledbReader[i].ToString();
                            list.Add(data.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.log.Fatal("Select Command Failed to Execute.. Query is: " + query + " Exception message: " + ex.Message);
                    ExtentReport.test.Log(LogStatus.Error, "Select Command Failed to Execute.. Query is: " + query + " Exception message: " + ex.Message);

                }
                connection.Close();
                return list;
            }
        }

        /// <summary>
        /// Get Data from Excel sheet
        /// </summary>
        /// <param name="ConfigKey">Mention the Configurtion Key defined in the App.config file</param>
        /// <param name="SheetName">Excel Sheet Name</param>
        /// /// <returns>List of Values</returns>
        public static ArrayList GetData(string ConfigKey, string SheetName)
        {
            var _ExcelSheetName = ConfigurationManager.AppSettings[ConfigKey];
            string _path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string _actualPath = _path.Substring(0, _path.LastIndexOf("bin"));
            string _projectPath = new Uri(_actualPath).LocalPath;
            string _ExcelFolderPath = _projectPath + "Library\\Excel\\DataFiles\\";
            string fileName = _ExcelFolderPath + _ExcelSheetName;
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);

            using (var connection = new OleDbConnection(con))
            {
                connection.Open();
                var query = string.Empty;
                ArrayList list = new ArrayList();
                try
                {
                    query = string.Format("select * from [" + SheetName + "$]");
                    OleDbCommand oledbCmd = new OleDbCommand(query, connection);
                    OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
                    while (oledbReader.Read())
                    {
                        for (int i = 0; i < oledbReader.VisibleFieldCount; i++)
                        {
                            var data = oledbReader[i].ToString();
                            list.Add(data.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.log.Fatal("Select Command Failed to Execute.. Query is: " + query + " Exception message: " + ex.Message);
                    ExtentReport.test.Log(LogStatus.Error, "Select Command Failed to Execute.. Query is: " + query + " Exception message: " + ex.Message);

                }
                connection.Close();
                return list;
            }
        }

        /// <summary>
        /// Insert Data into Excel Sheet
        /// </summary>
        /// <param name="ConfigKey">Mention the Configurtion Key defined in the App.config file</param>
        /// <param name="SheetName">Excel Sheet Name</param>
        /// <param name="Fields">Field Names</param>
        /// <param name="InsertiontionValue">Value to be inserted</param>
        /// <returns>List of Values</returns>
        public static void InsertData(string ConfigKey, string SheetName, string Fields, string InsertiontionValue)
        {
            var _ExcelSheetName = ConfigurationManager.AppSettings[ConfigKey];
            string _path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string _actualPath = _path.Substring(0, _path.LastIndexOf("bin"));
            string _projectPath = new Uri(_actualPath).LocalPath;
            string _ExcelFolderPath = _projectPath + "Library\\Excel\\DataFiles\\";
            string fileName = _ExcelFolderPath + _ExcelSheetName;

            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);

            using (var connection = new OleDbConnection(con))
            {
                connection.Open();
                var query = string.Empty;
                try
                {
                    query = string.Format("insert into [" + SheetName + "$] " + "(" + (Fields) + ") " + "values (" + "'{0}'" + ")", InsertiontionValue);
                    OleDbCommand oledbCmd = new OleDbCommand(query, connection);
                    OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Logger.log.Fatal("Insert Command Failed to Execute.. Query is: " + query + " Exception message: " + ex.Message);
                    ExtentReport.test.Log(LogStatus.Error, "Insert Command Failed to Execute.. Query is: " + query + " Exception message: " + ex.Message);

                }
                connection.Close();
            }

        }

        /// <summary>
        /// Update Data in Excel Sheet
        /// </summary>
        /// <param name="ConfigKey">Mention the Configurtion Key defined in the App.config file</param>
        /// <param name="SheetName">Excel Sheet Name</param>
        /// <param name="SetKey">Updation Field Name</param>
        /// <param name="SetValue">Updation Field Value</param>
        /// <param name="ConditionKey">Key value to filter the Data from Sheet</param>
        /// <param name="ConditionValue">Value to filter the Data</param>
        public static void UpdateData(string ConfigKey, string SheetName, string SetKey, string SetValue, string ConditionKey, string ConditionValue)
        {
            var _ExcelSheetName = ConfigurationManager.AppSettings[ConfigKey];
            string _path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string _actualPath = _path.Substring(0, _path.LastIndexOf("bin"));
            string _projectPath = new Uri(_actualPath).LocalPath;
            string _ExcelFolderPath = _projectPath + "Library\\Excel\\DataFiles\\";
            string fileName = _ExcelFolderPath + _ExcelSheetName;

            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);

            using (var connection = new OleDbConnection(con))
            {
                connection.Open();
                var query = string.Empty;
                try
                {
                    query = string.Format("update [" + SheetName + "$] set " + SetKey + " = '{0}' where [" + ConditionKey + "]='{1}'", SetValue, ConditionValue);
                    OleDbCommand oledbCmd = new OleDbCommand(query, connection);
                    OleDbDataReader oledbReader = oledbCmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Logger.log.Fatal("Update Command Failed to Execute.. Query is: " + query + " Exception message: " + ex.Message);
                    ExtentReport.test.Log(LogStatus.Error, "Delete Command Failed to Execute.. Query is: " + query + " Exception message: " + ex.Message);

                }
                connection.Close();
            }

        }
    }
}
