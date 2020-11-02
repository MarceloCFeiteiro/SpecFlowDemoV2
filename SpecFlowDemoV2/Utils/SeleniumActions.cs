using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowNetCoreDemo.Drivers;
using System;

namespace SpecflowNetCoreDemo.Utils
{
    public class SeleniumActions
    {
        private readonly WebDriverBuilder _webDriverBuilder;
        private const int tempoDeEspera = 5;
        private WebDriverWait espera = null;

        public SeleniumActions(WebDriverBuilder webDriverBuilder)
        {
            _webDriverBuilder = webDriverBuilder;
        }

        /// <summary>
        /// Método responsável por clicar em um elemento.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento a ser clicado.</param>
        public void Clicar(By reference)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(reference);
            elementoCarregado.Click();
        }

        /// <summary>
        /// Método responsável por enviar um texto para o elemento.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento para onde o texto será enviado.</param>
        /// <param name="texto">Texto a ser inserido.</param>
        public void EnviarTexto(By referencia, string texto)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(referencia);

            if (!string.IsNullOrEmpty(elementoCarregado.GetAttribute("value")))
                LimparAtributoValueCampoInput(elementoCarregado);

            elementoCarregado.SendKeys(texto);
        }

        /// <summary>
        /// Método responsável por retornar validar se um elemento esta na tela
        /// </summary>
        /// <param name="referencia"></param>
        /// <returns>True caso elemento esteja na tela</returns>
        public bool EstaVisivel(By referencia)
        {
            var elementoCarregado = EsperaElementoFicarVisivel(referencia);
            return elementoCarregado.Displayed;
        }

        /// <summary>
        /// Método responsável por retornar o texto de um elemento.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento</param>
        /// <returns>Retorna o texto contido no atributo Text do elemento.</returns>
        public string RetornaTexto(By referencia, string texto)
        {
            var elementoCarregado = EsperaElementoFicarVisivel(referencia);

            var textoEstaVisivel = EsperaTextoEstarPresenteNoElemento(elementoCarregado, texto);

            if (textoEstaVisivel)
                return elementoCarregado.Text;
            return string.Empty;
        }

        /// <summary>
        /// Método responsável por validar se um elmento esta sendo exibido
        /// </summary>
        /// <param name="referencia"></param>
        /// <returns>True se o elemento esta sendo exibido. False se o contrário</returns>
        public bool ElementoEstaVisivel(By referencia)
        {
            var elemento = EsperaElementoFicarVisivel(referencia);
            return elemento.Displayed;
        }

        /// <summary>
        /// Método responsável por esperar elemento ficar clicável.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <returns>Retorna um elemento que pode ser clicado.</returns>
        private bool EsperaTextoEstarPresenteNoElemento(IWebElement elemento, string texto)
        {
            espera = new WebDriverWait(_webDriverBuilder.WebDriver, TimeSpan.FromSeconds(tempoDeEspera));
            return espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(elemento, texto));
        }

        /// <summary>
        /// Método responsável por esperar elemento ficar clicável.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <returns>Retorna um elemento que pode ser clicado.</returns>
        private IWebElement EsperaElementoFicarClicavel(By referencia)
        {
            espera = new WebDriverWait(_webDriverBuilder.WebDriver, TimeSpan.FromSeconds(tempoDeEspera));
            return espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(referencia));
        }

        /// <summary>
        /// Método responsável por esperar elemento ficar clicável.
        /// </summary>
        /// <param name="webDriver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <returns>Retorna um elemento que pode ser clicado.</returns>
        private IWebElement EsperaElementoFicarVisivel(By referencia)
        {
            espera = new WebDriverWait(_webDriverBuilder.WebDriver, TimeSpan.FromSeconds(tempoDeEspera));
            return espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(referencia));
        }

        /// <summary>
        /// Método responsável por limpar o atributo value de um campo input.
        /// </summary>
        /// <param name="elementoCarregado"></param>
        private void LimparAtributoValueCampoInput(IWebElement elementoCarregado)
        {
            elementoCarregado.Clear();
        }
    }
}