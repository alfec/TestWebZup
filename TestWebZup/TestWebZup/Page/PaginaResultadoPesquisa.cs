using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestWebZup.Page
{
    public class PaginaResultadoPesquisa
    {
        private IWebDriver driver;

        public PaginaResultadoPesquisa(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SelecionarProduto => driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/div[1]/div/div[2]/div[6]/div/div/div/div[1]/div[1]/div"));
        public IWebElement MensagemProduto => driver.FindElement(By.Id("section-wrapper")); 

        public PaginaProduto EscolherProduto()
        {
            SelecionarProduto.Click();
            return new PaginaProduto(driver);
        }

        public bool Verificacao(string TextoParaVerificar)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div/div/div/div[3]/div/div[1]/div/div[2]/div[6]")));

            bool TextoIgual = false;

            if (MensagemProduto.Displayed)
            {
                string texto = MensagemProduto.Text.ToLower();

                if (texto.Contains(TextoParaVerificar))
                {
                    return TextoIgual = true;
                }
                else
                {
                    return TextoIgual;
                }
                
            }
            return TextoIgual;
        }



    }
}
