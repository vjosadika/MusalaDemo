using OpenQA.Selenium;

namespace MusalaDemo.Utilities
{
    public class Page
    {
        internal IWebDriver _driver;
        public Page(IWebDriver driver) { _driver = driver; }

        public const string ContactUsButtonXpath = "//button[. = 'Contact us']";
        public IWebElement ContactUsButton => _driver.FindElement(By.XPath(ContactUsButtonXpath));

        public const string NameFieldXpath = "//input[@id='cf-1']";
        public IWebElement NameField => _driver.FindElement(By.XPath(NameFieldXpath));

        public const string EmailFieldXpath = "//input[@id='cf-2']";
        public IWebElement EmailField => _driver.FindElement(By.XPath(EmailFieldXpath));

        public const string MobileFieldXpath = "//input[@id='cf-3']";
        public IWebElement MobileField => _driver.FindElement(By.XPath(MobileFieldXpath));

        public const string SubjectFieldXpath = "//input[@id='cf-4']";
        public IWebElement SubjectField => _driver.FindElement(By.XPath(SubjectFieldXpath));

        public const string MessageFieldXpath = "//textarea[@id='cf-5']";
        public IWebElement MessageField => _driver.FindElement(By.XPath(MessageFieldXpath));

        public const string SendButtonXpath = "//*[@id='wpcf7-f875-o1']/form/div[2]/p/input";
        public IWebElement SendButton => _driver.FindElement(By.XPath(SendButtonXpath));

        public const string ErrorMessageMissingEmailXpath = "//span/span[. = 'The e-mail address entered is invalid.']";
        public IWebElement ErrorMessageMissingEmail => _driver.FindElement(By.XPath(ErrorMessageMissingEmailXpath));

        public const string ErrorMessageMissingRequiredFieldsXpath = "//span[contains(text(),'The field is required.')]";
        public IWebElement ErrorMessageMissingRequiredFields => _driver.FindElement(By.XPath(ErrorMessageMissingRequiredFieldsXpath));

        public const string CompanyTabXpath = "//*[@id='menu-main-nav-1']/li[1]/a";
        public IWebElement CompanyTab => _driver.FindElement(By.XPath(CompanyTabXpath));

        public const string LeadershipSectionXpath = "//section[@class='company-members']//div[@class='cm-content']/h2[contains(text(),'Leadership')]";
        public IWebElement LeadershipSection => _driver.FindElement(By.XPath(LeadershipSectionXpath));

        public const string FacebookIconFooterXpath = "//span[@class='musala musala-icon-facebook']";
        public IWebElement FacebookIconFooter => _driver.FindElement(By.XPath(FacebookIconFooterXpath));

        public const string AcceptCookiesXpath = "(//a[contains(text(),'ACCEPT')]) ";
        public IWebElement AcceptCookies => _driver.FindElement(By.XPath(AcceptCookiesXpath));

        public const string FacebookCompanyProfileXpath = "//a[@aria-label='Musala Soft profile photo']";
        public IWebElement FacebookCompanyProfile => _driver.FindElement(By.XPath(FacebookCompanyProfileXpath));

        public const string CareerTabXpath = "(//a[contains(text(),'Careers')]) [1]";
        public IWebElement CareerTab => _driver.FindElement(By.XPath(CareerTabXpath));

        public const string CheckOpenPositionsButtonXpath = "//button[. = 'Check our open positions']";
        public IWebElement CheckOpenPositionsButton => _driver.FindElement(By.XPath(CheckOpenPositionsButtonXpath));

        public const string LocationsDropdownXpath = "//select[@id='get_location']";
        public IWebElement LocationsDropdown => _driver.FindElement(By.XPath(LocationsDropdownXpath));

        public const string GeneralDescriptionSector = "//div[@class='content-title']/h2[contains(text(),'General description')]";

        public const string ApplyButtonXpath = "/html/body/main/div/div/section/article/div/div[2]/div[2]/a/input";
        public IWebElement ApplyButton => _driver.FindElement(By.XPath(ApplyButtonXpath));

        public const string AgreeCheckboxXpath = "//input[@id='adConsentChx']";
        public IWebElement AgreeCheckbox => _driver.FindElement(By.XPath(AgreeCheckboxXpath));

        public const string SendButtonJobsXpath = "//input[@value='Send']";
        public IWebElement SendButtonJobs => _driver.FindElement(By.XPath(SendButtonJobsXpath));

        public const string OneOrMoreFieldErrorXpath = "//div[contains(text(),'One or more fields have an error. Please check and try again.')]";
        public IWebElement OneOrMoreFieldError => _driver.FindElement(By.XPath(OneOrMoreFieldErrorXpath));

        public const string CloseBttnPopupMessageXpath = "//button[contains(text(),'Close')]";
        public IWebElement CloseBttnPopupMessage => _driver.FindElement(By.XPath(CloseBttnPopupMessageXpath));

        public const string UploadCVFieldXpath = "//input[@id='uploadtextfield']";
        public IWebElement UploadCVField => _driver.FindElement(By.XPath(UploadCVFieldXpath));

        //public const string JobPositionsXpath = "//div[@class='card-container']";
        //public IWebElement JobPositions => _driver.FindElements(By.XPath(JobPositionsXpath));
    }
}
