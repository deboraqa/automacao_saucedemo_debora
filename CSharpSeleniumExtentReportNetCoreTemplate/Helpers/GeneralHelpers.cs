using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Drawing.Imaging; // Necessário para salvar capturas de tela
//using OpenQA.Selenium;



namespace CSharpSeleniumExtentReportNetCoreTemplate.Helpers
{
    public class GeneralHelpers
    {
        public static string ReturnStringWithRandomCharacters(int size)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string ReturnStringWithRandomNumbers(int size)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static IEnumerable ReturnCSVData(string csvPath)
        {
            using (StreamReader sr = new StreamReader(csvPath, CodePagesEncodingProvider.Instance.GetEncoding(1252)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ArrayList result = new ArrayList();
                    result.AddRange(line.Split(';'));
                    yield return result;
                }
            }
        }

        public static string GetScreenshot(string path, IWebDriver driver)
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            string date = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "-");

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string filePathAndName = $"{path}/{testName}_{date}.png";
            screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);



            return filePathAndName;
        }

        public static string GetProjectPath()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            return new Uri(actualPath).LocalPath;
        }

        public static string GetProjectBinDebugPath()
        {
            return GetProjectPath() + "bin//Debug//netcoreapp3.1";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMethodNameByLevel(int level)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(level);
            return sf.GetMethod().Name;
        }

        public static string GetRandomIDNumber()
        {
            return Guid.NewGuid().ToString();
        }

        public static void EnsureDirectoryExists(string fullReportFilePath)
        {
            var directory = Path.GetDirectoryName(fullReportFilePath);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }

        public static string ReplaceValueInFile(string file, string currentValue, string newValue)
        {
            string text = File.ReadAllText(file);
            text = text.Replace(currentValue, newValue);
            return text;
        }
    }
}
