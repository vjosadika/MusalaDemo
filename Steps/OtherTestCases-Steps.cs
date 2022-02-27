using MusalaDemo.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MusalaDemo.Steps
{
    [Binding]
    public class OtherTestCases_Steps
    {
        private readonly ScenarioContext _scenarioContext;
        public IWebDriver _driver;
        private OtherTestCases_Page OtherTestCases_Page => new OtherTestCases_Page(_driver);

        public OtherTestCases_Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
        }

        [Given(@"I click Company tab")]
        public void GivenIClickCompanyTab()
        {
            OtherTestCases_Page.ClickCompanyTab();
        }

        [Given(@"I verify that the correct URL is loaded '(.*)'")]
        public void GivenIVerifyThatTheCorrectURLIsLoaded(string correctURL)
        {
            OtherTestCases_Page.VerifyCorrectURLCompanyTab(correctURL);
        }

        [Given(@"I verify that there is a Leadership section")]
        public void GivenIVerifyThatThereIsALeadershipSection()
        {
            OtherTestCases_Page.VerifyThereisALeadershipSection();
        }

        [When(@"I click on facebook link from footer")]
        public void WhenIClickOnFacebookLinkFromFooter()
        {
            OtherTestCases_Page.ClickFacebookLinkFooter();
        }

        [When(@"I verify that the correct URL is loaded '(.*)'")]
        public void WhenIVerifyThatTheCorrectURLIsLoaded(string correctURL)
        {
            OtherTestCases_Page.VerifyCorrectURLCompanyTab(correctURL);
        }

        [When(@"I verify that the Musala facebook image appears")]
        public void WhenIVerifyThatTheMusalaFacebookImageAppears()
        {
            OtherTestCases_Page.VerifyCompanyFacebookProfileAppears();
        }

        [Given(@"I click Careers tab")]
        public void GivenIClickCareersTab()
        {
            OtherTestCases_Page.ClickCareerTab();
        }

        [Given(@"I click Check our position button")]
        public void GivenIClickCheckOurPositionButton()
        {
            OtherTestCases_Page.CheckOpenPositions();
        }

        [Given(@"I filter '(.*)' location via dropdown")]
        public void GivenIFilterLocationViaDropdown(string filterValue)
        {
            OtherTestCases_Page.FilterLocationViaDropdown(filterValue);
        }

        [Given(@"I open position '(.*)' by name")]
        public void GivenIOpenPositionByName(string jobName)
        {
            OtherTestCases_Page.OpenJobPosByName(jobName);
        }

        [Given(@"I verify that one of four main sectors is shown: '(.*)'")]
        public void GivenIVerifyThatOneOfFourMainSectorsIsShown(string sector)
        {
            OtherTestCases_Page.VerifyMainSectorIsDisplayed(sector);
        }

        [Given(@"I verify that Apply button is present")]
        public void GivenIVerifyThatApplyButtonIsPresent()
        {
            OtherTestCases_Page.VerifyButtonIsDisplayed();
        }

        [When(@"I click Apply button")]
        public void WhenIClickApplyButton()
        {
            OtherTestCases_Page.ClickApplyButton();
        }

        [When(@"I insert invalid data, invalid email: '(.*)'")]
        public void WhenIInsertInvalidDataInvalidEmail(string invalidEmail)
        {
            OtherTestCases_Page.InsertInvalidData(invalidEmail);
        }

        [When(@"I click send button on the form")]
        public void WhenIClickSendButtonOnTheForm()
        {
            OtherTestCases_Page.ClickSendButton();
        }

        [Then(@"I should get an error message after clicking send button '(.*)'")]
        public void ThenIShouldGetAnErrorMessageAfterClickingSendButton(string errorMessage)
        {
            OtherTestCases_Page.ErrorMessageAfterSendButton(errorMessage);
        }

        [Then(@"I close popup message")]
        public void ThenIClosePopupMessage()
        {
            OtherTestCases_Page.ClosePopupMessage();
        }

        [Then(@"I should get an error message about missing fields '(.*)'")]
        public void ThenIShouldGetAnErrorMessageAboutMissingFields(string errorMessage)
        {
            OtherTestCases_Page.ValidateErrorMessageMissingRequiredFields(errorMessage);
        }

        [Given(@"I print the open positions by city")]
        public void GivenIPrintTheOpenPositionsByCity()
        {
            OtherTestCases_Page.PrintConsolePosInformation();
        }

    }
}
