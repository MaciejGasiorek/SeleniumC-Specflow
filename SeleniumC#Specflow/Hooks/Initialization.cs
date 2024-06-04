using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow.Bindings;
using SeleniumCsharpSpecflow.Driver;
using System.Text.RegularExpressions;
using AventStack.ExtentReports.Model;


namespace SeleniumCsharpSpecflow.Hooks
{
    [Binding]
    public class Initialization
    {
        private static ExtentReports _extentReports;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private ExtentTest _scenario;
        private readonly IDriverFixture _driverFixture;

        public Initialization(ScenarioContext scenarioContext, FeatureContext featureContext, IDriverFixture driverFixture)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _driverFixture = driverFixture;
        }

        [BeforeTestRun]
        public static void InitializeExtentReports() 
        {
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string reportsPath = Path.Combine(solutionDirectory, "Reports");
            var extentReport = reportsPath + "/extentreport.html";
         
            _extentReports = new ExtentReports();
            var spark = new ExtentSparkReporter(extentReport);
            _extentReports.AttachReporter(spark);
        }

        [BeforeScenario]
        public void BeforeScenario() 
        {
            var feature = _extentReports.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _scenario = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            var fileName = $"{_featureContext.FeatureInfo.Title.Trim()}-{Regex.Replace(_scenarioContext.ScenarioInfo.Title, @"\s", "_")}";

            if(_scenarioContext.TestError == null)
            switch(_scenarioContext.StepContext.StepInfo.StepDefinitionType)
            {
                case StepDefinitionType.Given:
                    _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                    break;
                case StepDefinitionType.When:
                    _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                    break;
                case StepDefinitionType.Then:
                    _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            else
            {
               
                switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text)
                        .Fail(_scenarioContext.TestError.Message, new ScreenCapture()
                        {
                            Path = _driverFixture.TakeScreenshotAsPath(fileName),
                            Title = "Error screenshot"
                        }); ;
                        break;
                    case StepDefinitionType.When:
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text)
                            .Fail(_scenarioContext.TestError.Message, new ScreenCapture()
                            {
                                Path = _driverFixture.TakeScreenshotAsPath(fileName),
                                Title = "Error screenshot"
                            }); ;
                        break;
                    case StepDefinitionType.Then:
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text)
                            .Fail(_scenarioContext.TestError.Message, new ScreenCapture()
                            {
                                Path = _driverFixture.TakeScreenshotAsPath(fileName),
                                Title = "Error screenshot"
                            });;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extentReports.Flush();
        }
    }
}
