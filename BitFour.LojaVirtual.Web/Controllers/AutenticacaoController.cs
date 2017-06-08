
using System.Web.Mvc;
using System.Web.Security;
using BitFour.LojaVirtual.Dominio.Entidades;
using BitFour.LojaVirtual.Dominio.Repositorio;

namespace BitFour.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio _repositorio;
        
     

        // GET: Autenticacao
        [HttpGet]
        public ActionResult Login(string returnUrl)

        {

            ViewBag.returnUrl = returnUrl;

            return View(new Administrador());
        }



        [HttpPost]  //estou recebendo um adinistrador e uma string url que vem pelo metodo get que quando voce accessa o login ela esta na url 
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            _repositorio = new AdministradoresRepositorio();
             

             if (ModelState.IsValid)
            {
               Administrador admin = _repositorio.ObterAdministrador(administrador);
                if (admin != null)
                {
                    if (!Equals(administrador.Senha, admin.Senha)) 
                    {
                        ModelState.AddModelError("", "Senha não confere!!!");
                    }
                    else
                    {
                        //validaçao do forms que passa o usuario com seu login e passa o parametro falando que o cookie nao é permanente, 
                        //entao se o usuario sair do sistema terá que passar as informaçoes novame
                        FormsAuthentication.SetAuthCookie(admin.Login,false);


                        //validando a url se ela for maior que 1 quer dizer que a url nao esta vazia
                        //se ela comecar com uma barra pq na url começa com uma barra
                        //se ela nao tiver 2 barras um uma barra e 2 barras invertidas
                        if (Url.IsLocalUrl(returnUrl) 
                           && returnUrl > 1
                           && returnUrl.StartsWith("/")
                           && !returnUrl.StartsWith("//")
                           && !returnUrl.StartsWith("/\\"))
                             
                            return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("","Administrador não localizado");
                    //Mensagem de Admin nao lcalizado
                }
            }
            return View(new Administrador());
        }
    }
}