﻿    using BitFour.LojaVirtual.Dominio.Repositorio;
using BitFour.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitFour.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 15;


        // GET: Vitrine
        //lista de produtos adicionando a paginaçao
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

           

            ProdutosViewModel model = new ProdutosViewModel{

                
                  Produtos = _repositorio.Produtos
                 .Where(p=> categoria == null || p.Categoria == categoria)
                .OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina),

                 

                Paginacao = new Paginacao{
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = categoria == null ? _repositorio.Produtos.Count()
                    : _repositorio.Produtos.Count(e => e.Categoria == categoria)

                },
                CategoriaAtual = categoria
            };





            return View(model);
        }
    }
}