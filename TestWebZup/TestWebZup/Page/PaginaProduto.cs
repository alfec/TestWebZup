using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestWebZup.Page
{
    public class PaginaProduto
    {
        private IWebDriver driver;

        public PaginaProduto(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement BtnComprar => driver.FindElement(By.Id("btn-buy"));

        public PaginaCarrinho ComprarProdutoEscolhido()
        {
            BtnComprar.Click();
            return new PaginaCarrinho(driver);
        }
    
    }
}
