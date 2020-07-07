#language: pt

Funcionalidade: Comprar produto na site da Submarino
    Como cliente da Submarino 
    Eu desejo realizar uma pesquisa por determinado produto
    Para que eu possa comprar ele

@Fluxos-Principal
Cenário: Acessar pagina inicial
    Dado que estou com o navegador aberto
    Quando digitar a URL da Submarino
    Então a pagina inicial deve abrir

@Fluxos-Principal
Cenário: Realizar Pesquisa de produto
    Dado que estou na pagina inicial 
    Quando eu clicar na barra de pesquisa
    E digitar o nome do produto
    Então ao acionar o ENTER no teclado, deve ser exibido o resultado dos produtos

@Fluxos-Principal
Cenário: Escolher produto pesquisado
    Dado que realizei a pesquisa
    Quando eu escolher o produto
    E clicar nele
    Então deve ser aberto a pagina do produto

@Fluxos-Principal
Cenário: Adicionar ao carrinho de compras
    Dado estou na tela do produto
    Quando eu clicar no botão COMPRAR
    Então devo ser redirecionado para a tela MINHA CESTA
 
@Fluxos-Alternativo
Cenário: Produto não encontrado
    Dado que estou na pagina inicial
    Quando eu pesquisar pelo produto
    E ele não constar no site
    Então o site deve exibir uma mensagem informando que não há este produto

@Fluxos-Alternativo
Cenário: Produto não disponivel
    Dado que estou na pagina inicial
    Quando eu pesquisar pelo produto
    E não há mais no estoque
    Então na tela de resultado, o site deve exibir uma mensagem informando que não há produto no estoque
