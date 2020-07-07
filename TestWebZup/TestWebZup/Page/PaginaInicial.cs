using TestWebZup.Util;
using OpenQA.Selenium;

namespace TestWebZup.Page
{
    public class PaginaInicial
    {
        private IWebDriver driver;

        public PaginaInicial(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CampoPesquisar => driver.FindElement(By.Id("h_search-input"));

        public PaginaResultadoPesquisa RealizarBusca(string Produto)
        {
            CampoPesquisar.Click(); 
            CampoPesquisar.SendKeys(Produto);
            CampoPesquisar.SendKeys(Keys.Enter);
            return new PaginaResultadoPesquisa(driver);
        }

    }
}
