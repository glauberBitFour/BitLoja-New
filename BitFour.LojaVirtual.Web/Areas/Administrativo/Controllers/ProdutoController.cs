using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using BitFour.LojaVirtual.Dominio.Entidades;
using BitFour.LojaVirtual.Dominio.Repositorio;

namespace BitFour.LojaVirtual.Web.Areas.Administrativo.Controllers
{

    //essa classe é responsavel por fazer tod o gerenciamento de produtos do sistema

    [Authorize]
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

        //para receber a imagem é necessario assinar no metodo 
        //com o tipo Httppostedfilebase para imagem e ela pode ser nula ou nao...
        [HttpPost]
        public ActionResult Alterar(Produto produto, HttpPostedFileBase imagem = null)
{
            //Model state verifica no modelo, na classe de produto se algum campo é obrigatorio
            if (ModelState.IsValid)
            {

                if (imagem != null)
                {
                    produto.ImagemMimeType = imagem.ContentType;
                    produto.Imagem = new byte[imagem.ContentLength];
                    imagem.InputStream.Read(produto.Imagem, 0, imagem.ContentLength);
                }
                _repositorio = new ProdutosRepositorio();
                _repositorio.Salvar(produto);
                //Manda essa mesnagem pra layoutadministrativo
                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso", produto.Nome);
                 return RedirectToAction("Index");

            }
            return View(produto);
        }


        //para nao precisar criar uma nova view Novo produto, entao 
        public ViewResult NovoProduto()
        {
            return View("Alterar", new Produto());
        }


        //[HttpPost]
        //public ActionResult Excluir(int produtoId)
        //{
        //    _repositorio = new ProdutosRepositorio();
        //    Produto prod = _repositorio.Excluir(produtoId);

        //    if (prod != null)
        //    {
        //        TempData["mensagem"] = string.Format("{0} excluido com sucesso", prod.Nome);
        //    }
        //    return RedirectToAction("Index");
        //}



            //criando Modal de confirmaçao de exlcusao do Bootstrap para excluir um produto


        [HttpPost]
        public JsonResult Excluir(int produtoId)
        {
            string mensagem = string.Empty;
            _repositorio = new ProdutosRepositorio();
            Produto prod = _repositorio.Excluir(produtoId);

            if (prod != null)
            {
                mensagem = string.Format("{0} excluído com sucesso", prod.Nome);
            }
            return Json(mensagem,JsonRequestBehavior.AllowGet);
        }


        public FileContentResult ObterImagem(int produtoId)
        {
            _repositorio = new ProdutosRepositorio();
            Produto prod = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (prod != null)
            {
                return File(prod.Imagem, prod.ImagemMimeType);
            }
            return null;
        }

    }
}