using BitFour.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BitFour.LojaVirtual.Dominio.Repositorio
{
     public class ProdutosRepositorio
    {
        //cria uma variavel para referencia o entity 
        private readonly EfDbContext _context = new EfDbContext();



        //Lista todos os produtos
        public IEnumerable<Produto> Produtos
        {
            get
            {
                return _context.Produtos;
            }
        }   
        
        //Salva o produto e altera o produto no banco de dados
         public void Salvar(Produto produto)
         {

             //se o id vier zero ele salva
             if (produto.ProdutoId == 0)
             {
                 _context.Produtos.Add(produto);
             }
             else
             {
                //pesquisa pelo produto que esta recebendo e salva
                     Produto prod = _context.Produtos.Find(produto.ProdutoId);

                if (prod != null && prod.Imagem == null || produto.Imagem != null)
                {

                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;
                    prod.Imagem = produto.Imagem;
                    prod.ImagemMimeType = produto.ImagemMimeType;
                }
               
                else
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;
                }

            }
            _context.SaveChanges();
        }
     



         //Excluir produto
        public Produto Excluir(int produtoId)
         {

             Produto prod = _context.Produtos.Find(produtoId);
             if (prod != null)
             {
                 _context.Produtos.Remove(prod);
                 _context.SaveChanges();
             }
            return prod;
        }
        
    }
}
