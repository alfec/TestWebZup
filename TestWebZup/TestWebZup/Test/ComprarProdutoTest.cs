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
            ///O teste initialize est� funcionando para instanciar as variaveis que ser�o utlizadas nesse teste
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
            string Produto = "term�metro cl�nico digital";

            Resultado = HomePage.RealizarBusca(Produto);
            Assert.IsTrue(Resultado.Verificacao(Produto)); //Verifica se a pesquisa foi feita e se o nome pesquisado � oq est� exibido
            PaginaProduto = Resultado.EscolherProduto();
            Carrinho = PaginaProduto.ComprarProdutoEscolhido();
            Assert.IsTrue(Carrinho.Verificacao(Produto));
        }

        [TestMethod]
        [Priority(2)]
        public void VerificarDisponibilidadeProduto()
        {
            string ProdutoEmFalta = "Huggies Tripla Prote��o Fralda Infantil P C/11";
            Resultado = HomePage.RealizarBusca(ProdutoEmFalta);
            Assert.IsTrue(Resultado.Verificacao("ops! j� vendemos todo o estoque."));
        }

        [TestMethod]
        [Priority(3)]
        public void PesquisarProdutoQueNaoExisteNoSite()
        {
            string ProdutoInexistente = MetodosGenericos.GerarNome(5);
            Resultado = HomePage.RealizarBusca(ProdutoInexistente);
            Assert.IsTrue(Resultado.Verificacao("n�o encontramos nenhum resultado na sua busca."));
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
