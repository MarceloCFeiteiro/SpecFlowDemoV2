using NUnit.Framework;
using SpecFlowDemoV2.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowDemoV2.Steps
{
    [Binding]
    public sealed class LoginStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public readonly LoginPage _loginPage;

        public LoginStepDefinition(ScenarioContext scenarioContext, LoginPage loginPage)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
        }

        [When(@"clicar no botão de log in")]
        public void QuandoClicarNoBotaoDeLogIn()
        {
            _loginPage.ClicarNoBotaoLogin();
        }

        [Then(@"o link de Employee Details é exibido")]
        public void EntaoOLinkDeEmployeeDetailsEExibido()
        {
            bool estaVisivel = _loginPage.ValidaExibicaoLinkEmployeeDetails();

            Assert.True(estaVisivel);
        }

        [When(@"preencher campos obrigatórios com (.*) e (.*)")]
        public void QuandoPreencherCamposObrigatoriosComE(string usuario, string senha)
        {
            _loginPage.PreencherCamposLoginPassword(usuario, senha);
        }

        [Then(@"a mensagem de erro (.*) é exibida")]
        public void EntaoAMensagemDeErroEExibida(string mensagem)
        {
            var msg = _loginPage.MensagemErro(mensagem);

            Assert.AreEqual(msg, mensagem);
        }
    }
}