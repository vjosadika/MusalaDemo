using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MusalaDemo.Utilities
{
    public class WaitMethods
    {
        public IWebDriver _driver;

        public WaitMethods(IWebDriver driver) => _driver = driver;

        public WaitMethods WaitForElementToBePresent(By elementBy)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(elementBy));

            return this;
        }

        public WaitMethods WaitForElementToBeClickable(By elementBy)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(c => c.FindElement(elementBy).Displayed && c.FindElement(elementBy).Enabled);

            return this;
        }

    }
}
