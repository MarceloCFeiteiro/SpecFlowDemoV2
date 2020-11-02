using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace SpecflowNetCoreDemo
{
    public static class ScenarioExtensionMethod
    {
        // aqui é um método para criar um Scenario passando o tipo de Step
        private static ExtentTest CreateScenario(ExtentTest extent, StepDefinitionType stepDefinitionType, ScenarioContext scenarioContext)
        {
            // o SpecFlow nos permite pegar o nome do Step usando o ScenarioStepContext.Current
            var scenarioStepContext = scenarioContext.StepContext.StepInfo.Text;

            return stepDefinitionType switch
            {
                StepDefinitionType.Given => extent.CreateNode<Given>(scenarioStepContext),// cria o nodo para Given
                StepDefinitionType.Then => extent.CreateNode<Then>(scenarioStepContext),// cria o nodo para Then
                StepDefinitionType.When => extent.CreateNode<When>(scenarioStepContext),// cria o nodo para When
                _ => throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null),
            };
        }

        // aqui temos um método para criar um novo de falha ou erro
        private static void CreateScenarioFailOrError(ExtentTest extent, StepDefinitionType stepDefinitionType, ScenarioContext scenarioContext)
        {
            var error = scenarioContext.TestError;

            // se não existir exception então pega a mensagem de erro do ScenarioContext.Current
            if (error.InnerException == null)
            {
                CreateScenario(extent, stepDefinitionType, scenarioContext).Error(error.Message);
            }
            else
            {
                // senão cria uma falha passando a exception
                CreateScenario(extent, stepDefinitionType, scenarioContext).Fail(error.InnerException);
            }
        }

        // os métodos abaixo só facilitei as chamadas para Given, When e Then
        public static void StepDefinitionGiven(this ExtentTest extent, ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError == null)
                CreateScenario(extent, StepDefinitionType.Given, scenarioContext);
            else
                CreateScenarioFailOrError(extent, StepDefinitionType.Given, scenarioContext);
        }

        public static void StepDefinitionWhen(this ExtentTest extent, ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError == null)
                CreateScenario(extent, StepDefinitionType.When, scenarioContext);
            else
                CreateScenarioFailOrError(extent, StepDefinitionType.When, scenarioContext);
        }

        public static void StepDefinitionThen(this ExtentTest extent, ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError == null)
                CreateScenario(extent, StepDefinitionType.Then, scenarioContext);
            else
                CreateScenarioFailOrError(extent, StepDefinitionType.Then, scenarioContext);
        }
    }
}