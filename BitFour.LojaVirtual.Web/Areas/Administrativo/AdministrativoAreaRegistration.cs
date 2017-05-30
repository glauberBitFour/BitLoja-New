using System.Web.Mvc;

namespace BitFour.LojaVirtual.Web.Areas.Administrativo
{
    public class AdministrativoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            //para nao ter problema de ter 2 Index no projeto
            context.MapRoute(
                "Administrativo_default",
                "Administrativo/{controller}/{action}/{id}", defaults: new
                {
                    controller="Produto", action = "Index", id = UrlParameter.Optional
                }, namespaces: new [] { "BitFour.LojaVirtual.Web.Areas.Administrativo.Controllers" }
            );
        }
    }
}