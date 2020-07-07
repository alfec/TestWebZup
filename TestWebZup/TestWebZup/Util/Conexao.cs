using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestWebZup.Util
{
    public class Conexao
    {
        private IWebDriver browser;

        public Conexao(IWebDriver driver)
        {
            this.browser = driver;
        }

        public IWebDriver ConectarIWebDriver(IWebDriver driver)
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://www.submarino.com.br/");
            return browser;
        }
    }
}
