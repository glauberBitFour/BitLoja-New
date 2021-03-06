﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BitFour.LojaVirtual.Web
{
    public class RouteConfig
    {
        //testando sss
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapMvcAttributeRoutes();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //1 -rota inical da busca de produtos todas as  categorias /
            routes.MapRoute(null, "", new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null, pagina = 1 });
            //--------------------------------------------------------------------------------------------------------------------





            //segunda rota  lista as paginas, PAgina1,Pagina2 etc
            routes.MapRoute(null, "Pagina{pagina}", new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null }, new { pagina = @"\d+" });

            //----------------------------------------------------------------------------------------------------------------------------------------------


            //routes.MapRoute(null, new {controller = "Autenticacao", action = "Logoff", }.ToString());
            //routes.MapRoute(name: null, url: "", defaults: new { controller = "Autenticacao", action = "Logoff" });

       
       
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Autenticacao", action = "Logoff", id = UrlParameter.Optional }
            );
        


        //terceira rota somente a os produtos da categoria ex /Futebol
        routes.MapRoute(null, "{categoria}", new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 });

            //----------------------------------------------------------------------------------------------------------






            //trás todas as paginas da categoria /Futebol/Pagina2
            routes.MapRoute(null, "{categoria}/Pagina{pagina}", new { controller = "Vitrine", action = "ListaProdutos" }, new { pagina = @"\d+" });

            //-------------------------------------------------------------------------------------------------------------------------------






            //criando Url amigavel de rotaPagina
            routes.MapRoute(name: null, url: "Pagina{pagina}", defaults: new { controller = "Vitrine", action = "ListaProdutos" });



          

            routes.MapRoute(null, "{controller}/{action}");


        }
    }
}
