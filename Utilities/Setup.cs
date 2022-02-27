using BoDi;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;


namespace MusalaDemo.Utilities
{
    [Binding]
    public class Setup
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        public IWebDriver Driver { get; set; }
        private readonly IObjectContainer _objectContainer;

        public Setup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        public static string Base64Decode(string base64EncodedData)
        {

            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Lenovo\Desktop\Musala\index.html");

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }


        [AfterTestRun]
        public static async System.Threading.Tasks.Task TearDownReportAsync()
        {
            extent.Flush();

            string fromMail = ConfigurationManager.AppSettings["fromEmail"];
            string password = Base64Decode(ConfigurationManager.AppSettings["passwordEmail"]);
            string toMail = ConfigurationManager.AppSettings["toEmail"];
            string subject = "Test of " + DateTime.UtcNow;

            MimeMessage message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(fromMail));
            message.To.Add(MailboxAddress.Parse(toMail));

            var builder = new BodyBuilder();

            builder.HtmlBody = string.Format(@"<h3>Test Mail</h3>");
            builder.Attachments.Add(@"C:\Users\Lenovo\Desktop\Musala\index.html");
            message.Body = builder.ToMessageBody();
            message.Subject = subject;

            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                await client.ConnectAsync("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(fromMail, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

        }


        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }


        [AfterStep]
        [Obsolete]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
        }


        [BeforeScenario]
        [Obsolete]
        public void DriverSetup()
        {
            Driver = new FirefoxDriver();
            //Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs(Driver);
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Dispose();
        }

    }
}
