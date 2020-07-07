using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestWebZup.Page
{
    public class PaginaCarrinho
    {
        private IWebDriver driver;

        public PaginaCarrinho(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement RemoverItem => driver.FindElement(By.XPath("/html/body/div[4]/section/section/div[1]/section/ul/li[2]/div[2]/div[2]/div[2]"));
        public IWebElement CampoCEP => driver.FindElement(By.Id("cep"));
        public IWebElement BtnOKCep => driver.FindElement(By.CssSelector("freightForm-okBtn btn btn-default btn-xs nowrap"));
        public IWebElement BtnContinuar => driver.FindElement(By.Id("buy-button"));
        public IWebElement VerificarNomeProduto => driver.FindElement(By.XPath("/html/body/div[4]/section/section/div[1]/section/ul"));//xpath da div que engloba todos os produtos dentro do carrinho


        public void RemoverItemDoCarrinho()
        {
            RemoverItem.Click();
        }

        public void ConfirmarCEP(string CEP)
        {
            CampoCEP.Click();
            CampoCEP.SendKeys(CEP);
            BtnOKCep.Click();
        }

        public void FinalizarCompras()
        {
            BtnContinuar.Click();
        }

        public bool Verificacao(string TextoParaVerificar)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("app")));

            bool TextoIgual = false;

            if (VerificarNomeProduto.Displayed)
            {
                string texto = VerificarNomeProduto.Text.ToLower();

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
