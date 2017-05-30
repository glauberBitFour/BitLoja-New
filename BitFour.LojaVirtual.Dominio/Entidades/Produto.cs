

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BitFour.LojaVirtual.Dominio.Entidades
{
     public class Produto
    {

        //escondendo o Id na View
        [HiddenInput(DisplayValue = false)]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
    }
}
