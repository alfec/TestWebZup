using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestWebZup.Page;
using TestWebZup.Util;

namespace TestWebZup
{
    [TestClass]
    public class ComprarProdutoTest
    {
        private static IWebDriver driver;
        private Conexao Conexao = new Conexao(driver);
        private PaginaInicial HomePage;
        private PaginaResultadoPesquisa Resultado;
        private PaginaProduto PaginaProduto;
        private PaginaCarrinho Carrinho;


        [TestInitialize]
        public void ConfiguracaoInicial()
        {
            ///<summary>
            ///TestInitialize funciona como o Before
            ///O teste initialize está funcionando para instanciar as variaveis que serão utlizadas nesse teste
            /// </summary>
            driver = Conexao.ConectarIWebDriver(driver);
            Carrinho = new PaginaCarrinho(driver);
            HomePage = new PaginaInicial(driver);
            PaginaProduto = new PaginaProduto(driver);
            Resultado = new PaginaResultadoPesquisa(driver);
            
        }

        [TestMethod]
        [Priority(1)]
        public void ReazlizarCompraDeProduto()
        {
            string Produto = "termômetro clínico digital";

            Resultado = HomePage.RealizarBusca(Produto);
            Assert.IsTrue(Resultado.Verificacao(Produto)); //Verifica se a pesquisa foi feita e se o nome pesquisado é oq está exibido
            PaginaProduto = Resultado.EscolherProduto();
            Carrinho = PaginaProduto.ComprarProdutoEscolhido();
            Assert.IsTrue(Carrinho.Verificacao(Produto));
        }

        [TestMethod]
        [Priority(2)]
        public void VerificarDisponibilidadeProduto()
        {
            string ProdutoEmFalta = "Huggies Tripla Proteção Fralda Infantil P C/11";
            Resultado = HomePage.RealizarBusca(ProdutoEmFalta);
            Assert.IsTrue(Resultado.Verificacao("ops! já vendemos todo o estoque."));
        }

        [TestMethod]
        [Priority(3)]
        public void PesquisarProdutoQueNaoExisteNoSite()
        {
            string ProdutoInexistente = MetodosGenericos.GerarNome(5);
            Resultado = HomePage.RealizarBusca(ProdutoInexistente);
            Assert.IsTrue(Resultado.Verificacao("não encontramos nenhum resultado na sua busca."));
        }

        [TestCleanup]
        public void EncerrarTeste()
        {
            //TestCleanup funciona como o After
            driver.Close();
            driver.Quit();
        }

    }
}
