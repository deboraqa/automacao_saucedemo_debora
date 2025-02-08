using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces; // ✅ Importação correta para TestStatus
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;

namespace CSharpSeleniumExtentReportNetCoreTemplate.Helpers
{
    public class ExtentReportHelpers
    {
        public static AventStack.ExtentReports.ExtentReports EXTENT_REPORT = null;
        public static ExtentTest TEST;
        static string reportName = "TestReport_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
        static string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", reportName);
        static string fileName = reportName + ".html";
        static string fullReportFilePath = Path.Combine(reportPath, fileName);

        public static void CreateReport()
        {
            if (EXTENT_REPORT == null)
            {
                Directory.CreateDirectory(reportPath); // Garante que a pasta existe
                var htmlReporter = new ExtentHtmlReporter(fullReportFilePath);
                EXTENT_REPORT = new AventStack.ExtentReports.ExtentReports();
                EXTENT_REPORT.AttachReporter(htmlReporter);
            }
        }

        public static void AddTestResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status; // ✅ TestStatus agora reconhecido!
            var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? "" : TestContext.CurrentContext.Result.Message;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : TestContext.CurrentContext.Result.StackTrace;

            switch (status)
            {
                case TestStatus.Failed:
                    TEST.Log(Status.Fail, "Test Failed: " + message + "\n" + stacktrace);
                    break;
                case TestStatus.Inconclusive:
                    TEST.Log(Status.Warning, "Test Inconclusive: " + message + "\n" + stacktrace);
                    break;
                case TestStatus.Skipped:
                    TEST.Log(Status.Skip, "Test Skipped: " + message);
                    break;
                default:
                    TEST.Log(Status.Pass, "Test Passed");
                    break;
            }
        }
    }
}
