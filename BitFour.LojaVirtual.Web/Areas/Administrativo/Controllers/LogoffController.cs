using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BitFour.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class LogoffController : Controller
    {
        // GET: Administrativo/Logoff
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            
            return Redirect("/Vitrine/ListaProdutos");
        }
    }
}