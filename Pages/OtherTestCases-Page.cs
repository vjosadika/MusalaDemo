using MusalaDemo.Utilities;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace MusalaDemo.Pages
{
    public class OtherTestCases_Page : Page
    {
        private WaitMethods WaitMethods => new WaitMethods(_driver);
        public OtherTestCases_Page(IWebDriver driver) : base(driver) { }


        public OtherTestCases_Page ClickCompanyTab()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement CompanyTab = _driver.FindElement(By.XPath("//*[@id='menu-main-nav-1']/li[1]/a"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", CompanyTab);
            System.Threading.Thread.Sleep(5000);
            return this;
        }

        public OtherTestCases_Page VerifyCorrectURLCompanyTab(string correctURL)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string url = _driver.Url;

            Assert.AreEqual(correctURL, url);

            return this;

        }

        public OtherTestCases_Page VerifyThereisALeadershipSection()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            AcceptCookies.Click();
            var isDisplayed = LeadershipSection.Displayed;

            if (!isDisplayed)
            {
                throw new Exception("Element not found");
            }

            return this;
        }

        public OtherTestCases_Page ClickFacebookLinkFooter()
        {

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            IJavaScriptExecutor javaScript = (IJavaScriptExecutor)_driver;
            javaScript.ExecuteScript("window.scrollBy(0,850)", "");

            WaitMethods.WaitForElementToBePresent(By.XPath(FacebookIconFooterXpath))
            .WaitForElementToBeClickable(By.XPath(FacebookIconFooterXpath));

            FacebookIconFooter.Click();

            _driver.SwitchTo().Window(_driver.WindowHandles.Last());

            return this;
        }

        public OtherTestCases_Page VerifyCompanyFacebookProfileAppears()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var isDisplayed = FacebookCompanyProfile.Displayed;

            if (!isDisplayed)
            {
                throw new Exception("Element not found");
            }

            return this;

        }

        public OtherTestCases_Page ClickCareerTab()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement CareerTab = _driver.FindElement(By.XPath("(//a[contains(text(),'Careers')]) [1]"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", CareerTab);
            return this;
        }

        public OtherTestCases_Page CheckOpenPositions()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            CheckOpenPositionsButton.Click();
            return this;
        }

        public OtherTestCases_Page FilterLocationViaDropdown(string filterValue)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LocationsDropdown.Click();
            

            WaitMethods.WaitForElementToBePresent(By.XPath("//option[contains(text(),'" + filterValue + "')]"));
            _driver.FindElement(By.XPath("//option[contains(text(),'" + filterValue + "')]")).Click();

            System.Threading.Thread.Sleep(1000);

            return this;
        }

        public OtherTestCases_Page OpenJobPosByName(string jobName)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            AcceptCookies.Click();

            WaitMethods.WaitForElementToBePresent(By.XPath("//div[@class='front']/h2[@data-alt='" + jobName + "']")).
                WaitForElementToBeClickable(By.XPath("//div[@class='front']/h2[@data-alt='" + jobName + "']")); ;

            IWebElement JobPosition = _driver.FindElement(By.XPath("//div[@class='front']/h2[@data-alt='" + jobName + "']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", JobPosition);
            return this;
        }


        public OtherTestCases_Page VerifyMainSectorsAreDisplayed(string generalDescription, string requirements, string responsibilities, string offers)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IJavaScriptExecutor javaScript = (IJavaScriptExecutor)_driver;
            javaScript.ExecuteScript("window.scrollBy(0,250)", "");

            WaitMethods.WaitForElementToBePresent(By.XPath("//h2[contains(text(),'" + generalDescription + "')]"));
            WaitMethods.WaitForElementToBePresent(By.XPath("//h2[contains(text(),'" + requirements + "')]"));
            WaitMethods.WaitForElementToBePresent(By.XPath("//h2[contains(text(),'" + responsibilities + "')]"));
            WaitMethods.WaitForElementToBePresent(By.XPath("//h2[contains(text(),'" + offers + "')]"));

            return this;

        }

        public OtherTestCases_Page VerifyMainSectorIsDisplayed(string sector)
        {
            var isElementOneDisplayed = _driver.FindElement(By.XPath("//h2[contains(text(),'" + sector + "')]")).Displayed;

            if (!isElementOneDisplayed)
            {
                throw new Exception("Element not found");
            }

            return this;
        }

        public OtherTestCases_Page VerifyButtonIsDisplayed()
        {
            var isElementDisplayed = _driver.FindElement(By.XPath(ApplyButtonXpath)).Displayed;

            if (!isElementDisplayed)
            {
                throw new Exception("Element not found");
            }

            return this;
        }

        public OtherTestCases_Page ClickApplyButton()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IJavaScriptExecutor javaScript = (IJavaScriptExecutor)_driver;
            javaScript.ExecuteScript("window.scrollBy(0,850)", "");

            WaitMethods.WaitForElementToBePresent(By.XPath(ApplyButtonXpath));
            ApplyButton.Click();
            return this;
        }

        public OtherTestCases_Page InsertInvalidData(string invalidEmail)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WaitMethods.WaitForElementToBePresent(By.XPath(EmailFieldXpath))
            .WaitForElementToBeClickable(By.XPath(EmailFieldXpath));
            EmailField.SendKeys(invalidEmail);
            return this;
        }

        public OtherTestCases_Page ClickSendButton()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            AgreeCheckbox.Click();
            WaitMethods.WaitForElementToBePresent(By.XPath(SendButtonJobsXpath))
        .WaitForElementToBeClickable(By.XPath(SendButtonJobsXpath));
            SendButtonJobs.Click();
            return this;
        }

        public OtherTestCases_Page ErrorMessageAfterSendButton(string errorMessage)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string screenErrorMessage = _driver.FindElement(By.XPath(OneOrMoreFieldErrorXpath)).Text;

            Assert.AreEqual(screenErrorMessage, errorMessage);

            return this;
        }

        public OtherTestCases_Page ClosePopupMessage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WaitMethods.WaitForElementToBePresent(By.XPath(CloseBttnPopupMessageXpath))
                .WaitForElementToBeClickable(By.XPath(CloseBttnPopupMessageXpath));

            CloseBttnPopupMessage.Click();
            return this;

        }

        public OtherTestCases_Page ValidateErrorMessageMissingRequiredFields(string errorMessage)
        {
            string expectedMessage = ErrorMessageMissingRequiredFields.Text;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual(expectedMessage, errorMessage);
            return this;
        }

        public OtherTestCases_Page PrintConsolePosInformation()
        {
            IList<IWebElement> articles = _driver.FindElements(By.XPath("//*[@id='content']/section/div[2]/article"));

            var cityXpath = _driver.FindElement(By.XPath("//*[@id='get_location']/option[4]"));
            string city = cityXpath.Text;
            Console.WriteLine(city);

            foreach (var article in articles)
            {
                Console.WriteLine(article.FindElement(By.TagName("h2")).GetAttribute("data-alt"));
                Console.WriteLine(article.FindElement(By.TagName("a")).GetAttribute("href"));
                Console.WriteLine("-------------------");
            }
            return this;
        }
    }
}
