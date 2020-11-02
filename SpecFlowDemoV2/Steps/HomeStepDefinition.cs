using SpecFlowDemoV2.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowDemoV2.Steps
{
    [Binding]
    public sealed class HomeStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private readonly string URL = "http://eaapp.somee.com/";

        private readonly ScenarioContext _scenarioContext;
        public readonly HomePage _homePage;

        public HomeStepDefinition(ScenarioContext scenarioContext, HomePage homePage)
        {
            _scenarioContext = scenarioContext;
            _homePage = homePage;
        }

        [Given(@"que o usuário acessa a url")]
        public void DadoQueOUsuarioAcessaAUrl()
        {
            _homePage.NavegaParaPagina(URL);
        }

        [When(@"clicar no link de login")]
        public void QuandoClicarNoLinkDeLogin()
        {
            _homePage.ClicarNolinkLogin();
        }
    }
}