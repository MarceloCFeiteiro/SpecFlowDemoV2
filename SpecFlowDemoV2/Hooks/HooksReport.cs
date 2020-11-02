using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using SpecflowNetCoreDemo;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace SpecFlowDemoV2.Hooks
{
    [Binding]
    public sealed class HooksReport
    {
        private static ExtentTest _feature; // nodo para a Feature
        private static ExtentTest _scenario; // nodo para o Scenario
        private static ExtentReports _extent; // objeto do ExtentReports que será criado

                                              // aqui estou salvando na pasta bin/debug do projeto, o arquivo de relatório chamado ExtentReportAmazon.html
        private static readonly string dir = "C:";

        private static readonly string nomeDaPasta = "\\ReportSpecflow\\";

        [BeforeTestRun]
        public static void ConfigureReport()
        {
        }

        [BeforeFeature]
        public static void CreateFeature(FeatureContext featureContext)
        {
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(string.Concat(dir, nomeDaPasta, DateTime.Now.ToString("MM-yy"), "\\", featureContext.FeatureInfo.Title));
                var reporter = new ExtentHtmlReporter(di.FullName + "\\Test.html");
                // instancio o objeto ExtentReports
                _extent = new ExtentReports();

                // aqui dou attach no ExtentHtmlReporter
                _extent.AttachReporter(reporter);

                _feature = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [BeforeScenario]
        public static void CreateScenario(ScenarioContext scenarioContext)
        {
            // antes de iniciar um cenário, crie o meu nodo de Scenario
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var mm = scenarioContext.StepContext.StepInfo.StepInstance.StepDefinitionType;
            // aqui vou verificar o tipo de passos que nosso teste automatizado terá
            // por padrão temos o 3 principais: Given, When e Then que podem ser acompanhados de And
            switch (scenarioContext.StepContext.StepInfo.StepInstance.StepDefinitionType)
            {
                case StepDefinitionType.Given:
                    _scenario.StepDefinitionGiven(scenarioContext); // extension method
                    break;

                case StepDefinitionType.Then:
                    _scenario.StepDefinitionThen(scenarioContext); // extension method
                    break;

                case StepDefinitionType.When:
                    _scenario.StepDefinitionWhen(scenarioContext); // extension method
                    break;
            }
        }

        [AfterTestRun]
        public static void FlushExtent()
        {
            // depois de rodar os testes, finalize o objeto do ExtentReports
            // essa função destrói o objeto e cria o arquivo html

            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {

                throw;
            }

            // aqui abro o arquivo HTML após criá-lo
            // System.Diagnostics.Process.Start(PathReport);
        }
    }
}