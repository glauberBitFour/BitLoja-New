using BitFour.LojaVirtual.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace BitFour.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        ////testar adicionar itens ao carrinho
        #region Adionar

        [TestMethod]
        public void AdcionarAoCarrinho()
        {

            //Arrange significa a criaçao dos atributos que sao obrigatorios no metodo, nesse caso dos produtos
            Produto prod1 = new Produto
            {
                ProdutoId = 1,
                Nome = "SmartPhone samsung J5"
            };

            Produto prod2 = new Produto
            {
                ProdutoId = 2,
                Nome = "SmartPhone samsung J2"
            };


            Produto prod3 = new Produto
            {
                ProdutoId = 3,
                Nome = "SmartPhone samsung J3"
            };
            //Arrange Criaçao dos outros atributos obrigatorios no metodo de adicionar

            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 2);
            carrinho.AdcionarItem(prod2, 3);
            carrinho.AdcionarItem(prod3, 3);


            //act é a açao, passando todos os valores
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            
           



            ////Assert, esta testando se a quantidade de itens que tem no carrinho é igual a quantidade de itens criados, nesse caso 2
            Assert.AreEqual(itens.Length, 3);
           

            //esse assert verifica se o produto na posicao 0 é igual ao primeiro produto, e se o segundo produto na posicao 1 é igual ao segundo item que entrou na lista
            Assert.AreEqual(itens[0].Produto, prod1);
            Assert.AreEqual(itens[1].Produto, prod2);


        }

        #endregion


        [TestMethod]
        public void AdicionarProdutoExisteParaCarrinho()
        {


            //esse metodo esta testando, para ver se o carrinho está adcionando um produto existente
            Produto prod1 = new Produto
            {
                ProdutoId = 1,
                Nome = "J5 samsung"
            };

            Produto prod2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Samsung J2"
            };

          

            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 2);
            carrinho.AdcionarItem(prod2, 3);
            carrinho.AdcionarItem(prod1, 10);






            //ordenando os itens do carrinho por id
            ItemCarrinho[] resultado = carrinho.ItensCarrinho
                .OrderBy(c => c.Produto.ProdutoId).ToArray();

            //verifica quantos produtos tem no carrinho
            Assert.AreEqual(resultado.Length, 2);
             
            Assert.AreEqual(resultado[0].Quantidade,12);
            Assert.AreEqual(resultado[1].Quantidade,3);



        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {

            Produto prod1 = new Produto
            {
                ProdutoId = 1,
                Nome = "S7 1Edge"
            };

            Produto prod2 = new Produto
            {
                ProdutoId = 2,
                Nome = "S8 Plus"
            };




            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 2);
            carrinho.AdcionarItem(prod2, 3);
            carrinho.AdcionarItem(prod1, 1);

            carrinho.RemoverItem(prod1);
       


            //testa se o item foi removido do carrinnho, e se o produto 2 é igual a 0...
          //  Assert.AreEqual(carrinho.ItensCarrinho.Count(c => c.Produto == prod2),0);
            //Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == prod2).Count(), 0);

            //nesse teste verifica quantos itens há no carrinho
            Assert.AreEqual(carrinho.ItensCarrinho.Count(),1);


        }

        [TestMethod]
        public void CalcularValorTotal()
        {

            Produto prod1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "s8",
                Preco = 100M
            };

            Produto prod2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "s8 Plus",
                Preco = 100M
            };




            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 1);
            carrinho.AdcionarItem(prod2, 1);

            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado,200M);
          
            
       


        }

        [TestMethod]
        public void LimparItensCarrinho()
        {

            Produto prod1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "TEste 1",
                Preco = 100M
            };

            Produto prod2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "TEste 2",
                Preco = 100M
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 1);
            carrinho.AdcionarItem(prod2, 1);

            carrinho.LimparCarrinho();
            Assert.AreEqual(carrinho.ItensCarrinho.Count(),0);
            
        }


    }

   
}
