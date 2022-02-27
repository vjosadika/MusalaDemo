using MusalaDemo.Utilities;
using OpenQA.Selenium;
using System;
using System.Configuration;
using CsvHelper;
using System.IO;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace MusalaDemo.Pages
{
    public class TestCase1_Page : Page
    {
        private WaitMethods WaitMethods => new WaitMethods(_driver);
        public TestCase1_Page(IWebDriver driver) : base(driver) { }

        private CsvReader csvReader;

        public TestCase1_Page NavigatoToMusalaWebPage()
        {
            var applicationUrl = new Uri(ConfigurationManager.AppSettings.Get("MusalaURL"));

            _driver.Navigate().GoToUrl(applicationUrl);

            return this;
        }

        public TestCase1_Page ScrollDown()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IJavaScriptExecutor javaScript = (IJavaScriptExecutor)_driver;
            javaScript.ExecuteScript("window.scrollBy(0,750)", "");

            return this;
        }

        public TestCase1_Page ClickContactUs()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ContactUsButton.Click();

            return this;

        }

        public TestCase1_Page FillInvalidEmailAddress(int indexEmailData)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string currentDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string filePath = currentDirectory + @"\Desktop\Musala\Utilities\invalidEmailData.csv";
            var streamReader = new StreamReader(filePath);
            csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
            csvReader.Read();
            var invalidEmail = csvReader.GetField(indexEmailData);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            EmailField.SendKeys(invalidEmail);
            return this;
        }

        public TestCase1_Page FillRequiredInformation()
        {
            string nameValue = ConfigurationManager.AppSettings["nameValue"];
            string mobileValue = ConfigurationManager.AppSettings["mobileValue"];
            string subjectValue = ConfigurationManager.AppSettings["subjectValue"];
            string messageValue = ConfigurationManager.AppSettings["messageValue"];
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            WaitMethods.WaitForElementToBePresent(By.XPath(MobileFieldXpath));
            NameField.SendKeys(nameValue);

            WaitMethods.WaitForElementToBePresent(By.XPath(MobileFieldXpath));
            MobileField.SendKeys(mobileValue);

            WaitMethods.WaitForElementToBePresent(By.XPath(SubjectFieldXpath));
            SubjectField.SendKeys(subjectValue);

            WaitMethods.WaitForElementToBePresent(By.XPath(MessageFieldXpath));
            MessageField.SendKeys(messageValue);

            return this;
        }

        public TestCase1_Page ClickSendButton()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SendButton.Click();
            return this;
        }

        public TestCase1_Page ValidateErrorMessageMissingEmail(string errorMessage)
        {

            string expectedMessage = ErrorMessageMissingEmail.Text;

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Assert.AreEqual(expectedMessage, errorMessage);
            System.Threading.Thread.Sleep(1000);
            return this;

        }


    }
}
