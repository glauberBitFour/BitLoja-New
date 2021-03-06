﻿using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using BitFour.LojaVirtual.Dominio.Entidades;
using BitFour.LojaVirtual.Dominio.Repositorio;
using BitFour.LojaVirtual.Web.Models;

namespace BitFour.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {

        //acessando o banco
        private ProdutosRepositorio _repositorio;




        //
        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produto != null)
            {
                ObterCarrinho().AdcionarItem(produto, 1);
            }
            return RedirectToAction("CarrinhoIndex", new { returnUrl });
        }





        //guardo o estado do carrinho
        private Carrinho ObterCarrinho()
        {

            //cria uma sessao para para o carrinho
            Carrinho carrinho = (Carrinho)Session["Carrinho"];

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }





        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {

            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("CarrinhoIndex", new { returnUrl });
        }





        public ActionResult CarrinhoIndex(string returnurl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnurl
            });
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        public ViewResult FecharPedido()
        {

            return View( new Pedido());
        }




        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            Carrinho carrinho = ObterCarrinho();

            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")

            };
            EmailProcessarPedido processapedido = new EmailProcessarPedido(email);
            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("","Não foi possivel concluir o seu pedido, seu carrinho está vazio");
            }
            if (ModelState.IsValid)
            {
                processapedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }

    }
}

