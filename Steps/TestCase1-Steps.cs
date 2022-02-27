using MusalaDemo.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MusalaDemo.Steps
{
    [Binding]
    public class TestCase1_Steps
    {
        private readonly ScenarioContext _scenarioContext;
        public IWebDriver _driver;
        private TestCase1_Page TestCase1 => new TestCase1_Page(_driver);

        public TestCase1_Steps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
        }

        [Given(@"I open Musala webpage")]
        public void GivenIOpenMusalaWebpage()
        {
            TestCase1.NavigatoToMusalaWebPage();
        }


        [Given(@"I click Contact Us")]
        public void GivenIClickContactUs()
        {
            TestCase1.ScrollDown();
            TestCase1.ClickContactUs();
        }

        [Given(@"I fill an invalid email address as ""(.*)""")]
        public void GivenIFillAnInvalidEmailAddressAs(int indexEmailData)
        {
            TestCase1.FillInvalidEmailAddress(indexEmailData);
        }

        [Given(@"I fill the required information")]
        public void GivenIFillTheRequiredInformation()
        {
            TestCase1.FillRequiredInformation();
        }

        [When(@"I click send button")]
        public void WhenIClickSendButton()
        {
            TestCase1.ClickSendButton();
        }

        [Then(@"I should get an error message '(.*)'")]
        public void ThenIShouldGetAnErrorMessage(string errorMessage)
        {
            TestCase1.ValidateErrorMessageMissingEmail(errorMessage);
        }

    }
}
