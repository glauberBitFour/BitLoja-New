

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BitFour.LojaVirtual.Dominio.Entidades
{
    public class Produto
    {

        //Hidden input quer duzer que esta escondendo o Id na View
        [HiddenInput(DisplayValue = false)]
        public int ProdutoId { get; set; }


        [Required(ErrorMessage = "O nome do produto é obrigatorio =)")]
        public string Nome { get; set; }


        //definindo o tipo e alterando os valores das linhas da descricao
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "A descriçao do produto é obrigatoria =)")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "O preço do produto é obrigatorio =)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal Preco { get; set; }


        [Required(ErrorMessage = "Definir a categoria é obrigatorio =D")]
        public string Categoria { get; set; }

        public byte[] Imagem { get; set; }

        public string ImagemMimeType { get; set; }
    }
}
