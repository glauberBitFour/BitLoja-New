using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitFour.LojaVirtual.Dominio.Entidades;
using BitFour.LojaVirtual.Dominio.Repositorio;

namespace BitFour.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class ProdutoController : Controller
    {

        private ProdutosRepositorio _repositorio;


        // GET: Administrativo/Produto
        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();
            var produtos = _repositorio.Produtos;
            return View(produtos);
        }


        [HttpGet]
        public ActionResult Alterar(int produtoId)
        {
            _repositorio= new ProdutosRepositorio();
            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            return View(produto);

        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)

        {
            //Model state verifica no modelo, na classe de produto se algum campo é obrigatorio
            if (ModelState.IsValid)
            {
                _repositorio = new ProdutosRepositorio();
                _repositorio.Salvar(produto);
                //Manda essa mesnagem pra layoutadministrativo
                TempData["Mensagem"] = string.Format("{0} Foi salvo com sucesso", produto.Nome);
                return RedirectToAction("Index");

            }
            return View(produto);
        }


    }
}